using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace slurky
{
    public partial class SlurkyTrainer : Form
    {
        static Mem m = new Mem();
        public static long emuBase;
        bool OpenPhrog;
        bool GoodBase, ScanningBase;
        ulong BaseAddress = 0;
        

        public static byte?[] CheckBytesEE { get; private set; } = new byte?[]
        { 0x01, 0x80, 0x1A, 0x3C, null, null, 0x59, 0xFF, 0x00, 0x68, 0x19, 0x40,
        0x01, 0x80, 0x1A, 0x3C, 0x7C, 0x00, 0x39, 0x33, 0x21, 0xD0, 0x59, 0x03, null,
        null, null, 0x8F, 0x01, 0x80, 0x19, 0x3C, 0x08, 0x00, 0x40, 0x03, null, null, 0x39, 0xDF };

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
        public static void DelgeateThisShit(Label Label, string text)
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
            string tempPhrog = GetPhrogName();                  //  phrog = process 

            if (tempPhrog == "nophrog") return;

            Thread.Sleep(500);

            while (true)
            {
                int pID = m.GetProcIdFromName(tempPhrog);       //  get process ID
                OpenPhrog = false;                              //  is process running?

                if (pID > 0)
                {
                    OpenPhrog = m.OpenProcess(pID);
                }
                if (OpenPhrog) break;
                
                Thread.Sleep(1000);
            }

            while(true)                                         //  finding the base (luminar's method)
            {
                CurrentProcessBaseFinder();
                if(BaseAddress > 0)
                {
                    Console.WriteLine(BaseAddress.ToString("X"));
                    processStatuslabel.Invoke((MethodInvoker)delegate
                    {
                        processStatuslabel.Text = "found base address: (0x" + BaseAddress.ToString("X") + ").";
                        processStatuslabel.ForeColor = Color.Black;
                    });
                    break;
                }
                Thread.Sleep(50);
            }

            while (true)
            {
                if (OpenPhrog)
                {

                }
                Thread.Sleep(50);
            }


        }

        public static async void FindEmuBase()      //  obsolete
        {
            IEnumerable<long> AOBResults = await m.AoBScan(0x0, 0xFFFFFFFFFFFF,
            "01 80 1A 3C ?? ?? 59 FF 00 68 19 40 01 80 1A 3C 7C 00 39 33", true, false);

            long firstAOB = AOBResults.FirstOrDefault();

            foreach (long res in AOBResults)
            {
                Console.WriteLine(res.ToString("X"));
            }

            if (firstAOB != 0)
            {
                long tempResult = firstAOB; //- 0x2396EF0;     //  offset that for some reason works on all builds
                emuBase = tempResult;
                Console.WriteLine("found base address " + tempResult.ToString("X"));
            }
            else
            {
                Console.WriteLine("no base");
            }
        }

        public string GetPhrogName()                //  phrog = process
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
            processStatuslabel.Invoke((MethodInvoker)delegate
            {
                processStatuslabel.Text = "no pcsx2, rescanning.";
                processStatuslabel.ForeColor = Color.Red;
            });
            return "nophrog";
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

                ulong start = 0;

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
    }
}
