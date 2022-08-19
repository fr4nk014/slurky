using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace slurky
{
    public partial class SlurkyTrainer : Form
    {
        static Mem m = new Mem();
        public static long emuBase;
        bool OpenPhrog;
        bool GoodBase, ScanningBase;
        UInt64 BaseAddress = 0;
        string BaseString;
        int bgProcessID;

        string CurrentBuild;

        List<UInt64> FrozenAddresses;


        public static byte?[] CheckBytesEE { get; private set; } = new byte?[]
        { 0x01, 0x80, 0x1A, 0x3C, null, null, 0x59, 0xFF, 0x00, 0x68, 0x19, 0x40,
        0x01, 0x80, 0x1A, 0x3C, 0x7C, 0x00, 0x39, 0x33, 0x21, 0xD0, 0x59, 0x03, null,
        null, null, 0x8F, 0x01, 0x80, 0x19, 0x3C, 0x08, 0x00, 0x40, 0x03, null, null, 0x39, 0xDF };


        public class ActCharOffsets
        {
            public static UInt64 Sly2NTSC = 0x2DE2F0;
            public static UInt64 Sly2PAL = 0x2E55A0;
        }
        UInt64 ActCharOffset = 0x0;
        public class EntityStruct
        {
            public static UInt64 ID;
            public static UInt64 God;
            public static UInt64 Undetectable;
            public static UInt64 InfJumps;
            public static UInt64 TransformComponent;
        }

        public class CurrEntStruct : EntityStruct{}

        public void FillActChar(string build)
        {
            if(build.StartsWith("Sly 2"))
            {
                CurrEntStruct.ID = 0x18;
                CurrEntStruct.God = 0x298;
                CurrEntStruct.Undetectable = 0x11AC;
                CurrEntStruct.InfJumps = 0x2E8;
                CurrEntStruct.TransformComponent = 0x58;

                if(build == "Sly 2 NTSC") ActCharOffset = ActCharOffsets.Sly2NTSC;
                else if (build == "Sly 2 PAL") ActCharOffset = ActCharOffsets.Sly2PAL;
            }
        }

        public class TransformComponent
        {
            public static UInt64 Scale = 0x0;
            public static UInt64 Position = 0x30;
        }

        public SlurkyTrainer()
        {
            InitializeComponent();
        }

        // Niv's delegate stuff
        public static void DelegateThisShit(TextBox TextBox, float value)
        {
            TextBox.Invoke((MethodInvoker)delegate
            {
                TextBox.Text = value.ToString("f5");
            });
        }
        public static void DelegateThisShit(Label Label, float value)
        {
            Label.Invoke((MethodInvoker)delegate
            {
                Label.Text = value.ToString("f5");
            });
        }
        public static void DelegateThisShit(Label Label, string text)
        {
            Label.Invoke((MethodInvoker)delegate
            {
                Label.Text = text;
            });
            
        }



        private void SlurkyTrainer_Load(object sender, EventArgs e)
        {
            if (!bgworker.IsBusy) bgworker.RunWorkerAsync();
        }




        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("test");
            string tempPhrog = GetPhrogName();                  //  phrog = process 

            
            Thread.Sleep(500);
            
            while (true)
            {
                int pID = m.GetProcIdFromName(tempPhrog);       //  get process ID
                OpenPhrog = false;

                if (pID > 0)                                    //  is process running?
                {
                    OpenPhrog = m.OpenProcess(pID);
                }
                if (OpenPhrog)
                {
                    bgProcessID = pID;
                    break;
                }

                Thread.Sleep(1000);
            }

            while (true)     //  finding the base (luminar's method)
            {
                if (!ScanningBase)
                {
                    CurrentProcessBaseFinder();
                    if (BaseAddress > 0)
                    {
                        Console.WriteLine(BaseAddress.ToString("X"));
                        processStatuslabel.Invoke((MethodInvoker)delegate
                        {
                            processStatuslabel.Text = "found base address: (0x" + BaseAddress.ToString("X") + ").";
                            processStatuslabel.ForeColor = Color.Black;
                        });
                        break;
                    }
                }
                Thread.Sleep(50);
            }

            while (true)     //  get build name
            {
                CurrentBuild = GetBuildName();
                if (CurrentBuild == "-")
                {
                    processStatuslabel.Invoke((MethodInvoker)delegate
                    {
                        processStatuslabel.Text = "no game.";
                        processStatuslabel.ForeColor = Color.Red;
                    });
                }
                else
                {
                    FillActChar(CurrentBuild);
                    processStatuslabel.Invoke((MethodInvoker)delegate
                    {
                        processStatuslabel.Text = CurrentBuild;
                        processStatuslabel.ForeColor = Color.Black;
                    });
                    break;
                }
            }

            while (true)    //main loop
            {
                OpenPhrog = m.OpenProcess(bgProcessID);
                if (OpenPhrog)
                {
                    string tb = CurrentBuild;   //  temp
                    string ab = GetBuildName(); //  actual
                    if (tb != ab)
                    {
                        Application.Restart();
                    }
                    GetSetActiveCharacter();

                }
                else
                {
                    Application.Restart();
                }
                Thread.Sleep(50);
            }


        }

        void GetSetActiveCharacter()
        {
            tabControl1.Invoke((MethodInvoker)delegate
            {
                if (tabControl1.SelectedIndex != 0) return;      //processor saver
            });
            
            string toWrite = "-";
            UInt64 index = 1;
            Color colorToUse = Color.Gray;

            if (CurrentBuild == "Sly 2 NTSC")
            {
                index = GetActiveCharacterData(CurrEntStruct.ID);
            }


            switch (index)
            {
                default:
                    toWrite = "no active character";
                    colorToUse = Color.Red;
                    break;

                case 7:
                    toWrite = "sy";
                    colorToUse = Color.Blue;
                    break;

                case 8:
                    toWrite = "benlo";
                    colorToUse = Color.Green;
                    break;

                case 9:
                    toWrite = "THE Murphy";
                    colorToUse = Color.DeepPink;
                    break;
            }


            actEntName.Invoke((MethodInvoker)delegate
            {
                actEntName.Text = toWrite + " (" + index.ToString() + ")" ;
                actEntName.ForeColor = colorToUse;
            });

            UInt64 godStatus = GetActiveCharacterData(CurrEntStruct.God);
            if (godStatus == 1)
            {
                cb_god.Invoke((MethodInvoker)delegate
                {
                    cb_god.Checked = true;
                });
            }
            else if (godStatus == 0)
            {
                cb_god.Invoke((MethodInvoker)delegate
                {
                    cb_god.Checked = false;
                });
            }

            UInt64 undetecStatus = GetActiveCharacterData(CurrEntStruct.Undetectable);
            if (undetecStatus == 1)
            {
                cb_ignore.Invoke((MethodInvoker)delegate
                {
                    cb_ignore.Checked = true;
                });
            }
            else if (undetecStatus == 0)
            {
                cb_ignore.Invoke((MethodInvoker)delegate
                {
                    cb_ignore.Checked = false;
                });
            }

            UInt64 help = 0x0;
            float tempX = 0, tempY = 0, tempZ = 0;
            while (true)
            {
                float tempPos = GetActiveCharacterData(CurrEntStruct.TransformComponent, TransformComponent.Position + help);
                help += 4;
                if(help == 0x4)
                {
                    tempX = tempPos;
                }
                else if (help == 0x8)
                {
                    tempY = tempPos;
                }
                else
                {
                    tempZ = tempPos;
                }
                if(help > 0x8)
                {
                    break;
                }
            }

            DelegateThisShit(actCoordX, tempX.ToString("f5"));
            DelegateThisShit(actCoordY, tempY.ToString("f5"));
            DelegateThisShit(actCoordZ, tempZ.ToString("f5"));

            float tempScale = GetActiveCharacterData(CurrEntStruct.TransformComponent, TransformComponent.Scale);
            DelegateThisShit(actScale, tempScale.ToString("f5"));


        }

        UInt64 GetActiveCharacterData(UInt64 offset)
        {
            // thanks niv
            return m.ReadUInt((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8"));
        }

        

        float GetActiveCharacterData(UInt64 offset, UInt64 offset2)
        {
            return m.ReadFloat((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8") + "," + (BaseAddress + offset2).ToString("X8"), round: false);
        }
        void SetActiveCharacterData(UInt64 offset, int setTo, bool freeze = false, bool unfreeze = false)
        {
            if(freeze)
            {
                if(!unfreeze)
                {
                    m.FreezeValue((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8"), "int", setTo.ToString());
                    return;
                }

                m.UnfreezeValue((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8"));
                return;
            }
            m.WriteMemory((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8"), "int", setTo.ToString());
        }

        void SetActiveCharacterData(UInt64 offset, UInt64 offset2, string setTo, bool vec3 = false, string writeType = "float")
        {
            m.WriteMemory((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8") + "," + (BaseAddress + offset2).ToString("X8"), writeType, setTo);
            
            if(vec3)
            {
                UInt64 toAdd = 0x14;
                while(true)
                {
                    m.WriteMemory((BaseAddress + ActCharOffset).ToString("X8") + "," + (BaseAddress + offset).ToString("X8") + "," + (BaseAddress + offset2 + toAdd).ToString("X8"), type: writeType, write: setTo);
                    toAdd+=0x14;
                    if(toAdd > 0x28)
                    {
                        break;
                    }
                }
            }
        }

        public string GetPhrogName()                //  phrog = process
        {
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (p.ProcessName.StartsWith("pcsx2"))
                    {
                        Console.WriteLine(p.ProcessName);
                        processStatuslabel.Invoke((MethodInvoker)delegate
                        {
                            processStatuslabel.Text = "found process: " + p.ProcessName;
                            processStatuslabel.ForeColor = Color.Black;
                        });
                        return p.ProcessName;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void CurrentProcessBaseFinder()      //luminar method
        {
            if (!GoodBase)
            {
                ScanningBase = true;

                List<byte?> checkBytes = new List<byte?>();

                for (int i = 0; i < CheckBytesEE.Length; i++)
                {
                    checkBytes.Add(CheckBytesEE[i]);
                }

                UInt64 start = 0;

                while (start < 0x800000000000)
                {
                    bool good = true;

                    for (int i = 0; i < checkBytes.Count; i += 4)
                    {
                        if (checkBytes[i] == null) continue;

                        byte[] helpByteArr = new byte[]
                        {
                            (byte)checkBytes[i],
                            (byte)checkBytes[i+1],
                            (byte)checkBytes[i+2],
                            (byte)checkBytes[i+3]
                        };

                        int val = BitConverter.ToInt32(helpByteArr, 0);

                        if (m.ReadUIntPtr((UIntPtr)start + i) != val)
                        {
                            good = false;
                            break;
                        }
                    }

                    if (!OpenPhrog)      //  fallback if scan successful but process is lost
                    {
                        ScanningBase = false;
                        GoodBase = false;
                        return;
                    }

                    if (!good)
                    {
                        start += 0x10000000;
                        continue;
                    }

                    if (start == BaseAddress)
                    {
                        ScanningBase = false;
                        GoodBase = true;
                        return;
                    }

                    BaseAddress = (UInt64)start;
                    BaseString = "0x" + BaseAddress.ToString("X");
                    Debug.WriteLine(BaseString);

                    ScanningBase = false;
                    GoodBase = true;
                    return;
                }
                Thread.Sleep(1000);
                ScanningBase = false;
                GoodBase = false;
                return;
            }
        }

        private void cb_god_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_god.Checked) 
            {
                SetActiveCharacterData(CurrEntStruct.God, 1);
                return;
            }
            SetActiveCharacterData(CurrEntStruct.God, 0);
        }

        private void cb_ignore_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ignore.Checked) 
            {
                SetActiveCharacterData(CurrEntStruct.Undetectable, 1);
                return;
            }
            SetActiveCharacterData(CurrEntStruct.Undetectable, 0);
        }

        private void actCoordX_Click(object sender, EventArgs e)
        {
            
        }
        private void actCoordY_Click(object sender, EventArgs e)
        {

        }
        private void actCoordZ_Click(object sender, EventArgs e)
        {

        }

        private void cb_infjmp_CheckedChanged(object sender, EventArgs e)//broken!!!
        {
            bool shouldfreeze = cb_infjmp.Checked;
            SetActiveCharacterData(EntityStruct.InfJumps, 1, freeze: true, unfreeze: shouldfreeze);
        }

        private void tbar_scale_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)tbar_scale.Value / 10;
            Console.WriteLine(val.ToString("f5"));
            SetActiveCharacterData(offset: EntityStruct.TransformComponent, offset2: TransformComponent.Scale, setTo: val.ToString("f5"), vec3: true, writeType: "float");
        }

        string GetBuildName()
        {
            if (!GoodBase) return "-";      //  fallback


            if (m.ReadString((BaseAddress + 0x2C46D8).ToString("X")) == "0813.0032") return "Sly 2 NTSC";
            else if (m.ReadString((BaseAddress + 0x2CBB08).ToString("X")) == "0914.1846") return "Sly 2 PAL";
            else if (m.ReadString((BaseAddress + 0x34A2F8).ToString("X")) == "0828.0212") return "Sly 3 NTSC";



            else return "-";
        }
    }
}
