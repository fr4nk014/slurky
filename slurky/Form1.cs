using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Runtime;

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

        bool CanFillWarps = true;

        string CurrentBuild;

        List<UInt64> FrozenAddresses;
        List<string> LevelAOBList;
        List<byte[]> LevelAOBs;
        public UInt64 LevelAmt;

        public float CoordAdjustAmt = 200f;

        public static byte?[] CheckBytesEE { get; private set; } = new byte?[]
        { 0x01, 0x80, 0x1A, 0x3C, null, null, 0x59, 0xFF, 0x00, 0x68, 0x19, 0x40,
        0x01, 0x80, 0x1A, 0x3C, 0x7C, 0x00, 0x39, 0x33, 0x21, 0xD0, 0x59, 0x03, null,
        null, null, 0x8F, 0x01, 0x80, 0x19, 0x3C, 0x08, 0x00, 0x40, 0x03, null, null, 0x39, 0xDF };


        public static UInt64 LevelAOBStart;
        
        public class GlobalAddresses
        {
            public static UInt64 ActChar;
            public static UInt64 Reload;
            public static UInt64 CurrentLevelAOB;
            public static UInt64 CurrentLvlEntrance;
            public static UInt64 ResetCamera;
            public static UInt64 LevelID;

            //engine
            public static UInt64 CameraSpeed;
            public static UInt64 DrawDist;
            public static UInt64 FOV;
            public static UInt64 Clock;
            public static UInt64 Loading;

            public static UInt64 UnlockGadgets, UnlockGadgets2;



            
        }
        public class ActCharPtrs
        {
            public static UInt64 Sly2NTSC = 0x2DE2F0;
            public static UInt64 Sly2PAL = 0x2E55A0;
            public static UInt64 Sly2July11 = 0x2F9CF0;

            public static UInt64 Sly3NTSC = 0x36F84C;
            public static UInt64 Sly3PAL = 0x3702CC;
        }

        public class CharStructPtrs
        {
            public static UInt64 Sly;
            public static UInt64 Bentley;
            public static UInt64 Murray;
        }

        public static class CharacterNames
        {
            public const string Sly = "Sly";
            public const string Bentley = "Bentley";
            public const string Murray = "Murray";
            public const string Carmelita = "Carmelita";
            public const string Guru = "Guru";
            public const string PandaKing = "Panda King";
            public const string Penelope = "Penelope";
            public const string RCCar = "Penelope's RC-Car";
            public const string Biplane = "Sly's Biplane";
        }

        public static class BuildNames
        {
            public const string Sly2NTSC = "Sly 2 NTSC";
            public const string Sly2PAL = "Sly 2 PAL";
            public const string Sly2July11 = "Sly 2 Prototype (July 11)";

            public const string Sly3NTSC = "Sly 3 NTSC";
            public const string Sly3PAL = "Sly 3 PAL";
        }
        

        UInt64 CurrentCharStruct;
        public class EntityStruct
        {
            public static UInt64 ID;
            public static UInt64 God;
            public static UInt64 Undetectable;
            public static UInt64 InfJumps;
            public static UInt64 TransformComponent;
            public static UInt64 DetectionComponent;
        }


        public string GetCharacterName(UInt64 id)
        {
            if (CurrentBuild.StartsWith("Sly 2"))
            {
                switch (id)
                {
                    default:
                        return "-";
                    case 7:
                        return CharacterNames.Sly;
                    case 8:
                        return CharacterNames.Bentley;
                    case 9:
                        return CharacterNames.Murray;
                }
            }
            else if (CurrentBuild.StartsWith("Sly 3"))
            {
                switch (id)
                {
                    default:
                        return "-";
                    case 24:
                        return CharacterNames.Sly;
                    case 25:
                        return CharacterNames.Bentley;
                    case 26:
                        return CharacterNames.Murray;
                    case 28:
                        return CharacterNames.Carmelita;
                    case 29:
                        return CharacterNames.Guru;
                    case 30:
                        return CharacterNames.PandaKing;
                    case 31:
                        return CharacterNames.Penelope;
                    case 15063:
                        return CharacterNames.RCCar;
                    case 16018:
                        return CharacterNames.Biplane;
                }
            }



            return "-";

        }
        public void FillActChar(string build)
        {
            if(build == BuildNames.Sly2NTSC || build == BuildNames.Sly2PAL)
            {
                EntityStruct.ID = 0x18;
                EntityStruct.God = 0x298;
                EntityStruct.Undetectable = 0x11AC;
                EntityStruct.InfJumps = 0x2E8;
                EntityStruct.TransformComponent = 0x58;
                Funs.Lankyness = 0x2400;

                if (build == BuildNames.Sly2NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2NTSC;
                    GlobalAddresses.ActChar = 0x3D4A6C;
                    GlobalAddresses.Reload = 0x3E1080; //aob = +8
                    GlobalAddresses.CurrentLevelAOB = 0x3E1088;
                    GlobalAddresses.ResetCamera = 0x2DE240;
                    GlobalAddresses.LevelID = 0x3E1110;
                    GlobalAddresses.Loading = 0x3D3980;

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x2DDEDC;
                    GlobalAddresses.DrawDist = 0x2DDF5C;
                    GlobalAddresses.FOV = 0x2DDF60;

                    LevelAOBStart = 0x3E1C40;
                    LevelAmt = 44;

                    CharStructPtrs.Sly = 0x2E1E40;
                    CharStructPtrs.Bentley = 0x2DD5BC;
                    CharStructPtrs.Murray = 0x2F7900;
                }
                else if (build == BuildNames.Sly2PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2PAL; 
                    GlobalAddresses.ActChar = 0x3DC26C;
                    GlobalAddresses.Reload = 0x3E8880;
                    GlobalAddresses.ResetCamera = 0x2E5640;
                    GlobalAddresses.LevelID = 0x3E8910;

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x2E52DC;
                    GlobalAddresses.DrawDist = 0x2E535C;
                    GlobalAddresses.FOV = 0x2E5360;

                    CharStructPtrs.Sly = 0x2E9240;
                    CharStructPtrs.Bentley = 0x2E49BC;
                    CharStructPtrs.Murray = 0x2FF110;
                }
            }
            else if (build == BuildNames.Sly3NTSC || build == BuildNames.Sly3PAL)
            {
                EntityStruct.ID = 0x18;
                EntityStruct.God = 0x180;
                EntityStruct.Undetectable = 0x11AC;                // unassigned
                EntityStruct.TransformComponent = 0x48;            // unassigned
                EntityStruct.DetectionComponent = 0x1160;

                cb_infjmp.Invoke((MethodInvoker)delegate
                {
                    cb_infjmp.Enabled = false;
                });
                cb_fun_lanky.Invoke((MethodInvoker)delegate
                {
                    cb_fun_lanky.Enabled = false;
                });


                if (build == BuildNames.Sly3NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3NTSC;
                    GlobalAddresses.ActChar = 0x36C710;
                    GlobalAddresses.Reload = 0x4797C4; //aob = +8
                    GlobalAddresses.CurrentLevelAOB = 0x4797CC;
                    GlobalAddresses.ResetCamera = 0x2DE240;         // unassigned
                    GlobalAddresses.LevelID = 0x47989C;
                    GlobalAddresses.Loading = 0x467B00;
                    GlobalAddresses.UnlockGadgets = 0x468DCC;
                    GlobalAddresses.UnlockGadgets2 = 0x468DD0;

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x2DDEDC;         // unassigned
                    GlobalAddresses.DrawDist = 0x2DDF5C;            // unassigned
                    GlobalAddresses.FOV = 0x2DDF60;                 // unassigned

                    LevelAOBStart = 0x2EDFD8;
                    LevelAmt = 35;

                    CharStructPtrs.Sly = 0x370AC0;
                    CharStructPtrs.Bentley = 0x36B250;
                    CharStructPtrs.Murray = 0x38AE90;
                }
                else if (build == BuildNames.Sly3PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3PAL;
                    GlobalAddresses.ActChar = 0x3DC26C;
                    GlobalAddresses.Reload = 0x3E8880;              // unassigned
                    GlobalAddresses.ResetCamera = 0x2E5640;         // unassigned
                    GlobalAddresses.LevelID = 0x3E8910;             // unassigned

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x2E52DC;         // unassigned
                    GlobalAddresses.DrawDist = 0x2E535C;            // unassigned
                    GlobalAddresses.FOV = 0x2E5360;                 // unassigned

                    CharStructPtrs.Sly = 0x3702CC;
                    CharStructPtrs.Bentley = 0x38C550;
                    CharStructPtrs.Murray = 0x36BCD0;
                }
            }
        }
        
        
        public void GetLevelAOBs()
        {
            if(CurrentBuild.StartsWith("Sly 3"))
            {
                GetLevelAOBs_SLY3METHOD();
                return;
            }

            LevelAOBList = new List<string>();
            LevelAOBs = new List<byte[]>();

            LevelAOBList.Clear();
            UInt64 offset = 0x0;
            for (UInt64 i = 0; i <= LevelAmt; i++)
            {
                offset = i * 0x40;
                byte[] bytes = m.ReadBytes((BaseAddress + LevelAOBStart).ToString("X") + "," + (BaseAddress + offset).ToString("X"), 0x40);

                string hexString = BitConverter.ToString(bytes);
                hexString = hexString.Replace("-", " ");

                Console.WriteLine(i + ": " + hexString);

                LevelAOBList.Add(hexString);
                LevelAOBs.Add(bytes);
            }

            FillLevelDropdown();
        }

        public void GetLevelAOBs_SLY3METHOD()
        {
            LevelAOBList = new List<string>();
            LevelAOBs = new List<byte[]>();

            LevelAOBList.Clear();
            UInt64 offset = 0x0;
            for (UInt64 i = 0; i <= LevelAmt; i++)
            {
                offset = i * 0x40;
                byte[] bytes = m.ReadBytes(((BaseAddress + LevelAOBStart + offset)).ToString("X"), 0x40);

                string hexString = BitConverter.ToString(bytes);
                hexString = hexString.Replace("-", " ");

                Console.WriteLine(i + ": " + hexString);

                LevelAOBList.Add(hexString);
                LevelAOBs.Add(bytes);
            }

            FillLevelDropdown();
        }

        void FillLevelDropdown()
        {
            string b = GetBuildName();
            List<string> list = new List<string>();
            if(b.StartsWith("Sly 2"))
            {
                list.Add("Cairo Museum"); list.Add("DVD Menu"); list.Add("Paris Hub"); list.Add("   Wine Cellar");
                list.Add("   Nightclub"); list.Add("   Print Room"); list.Add("   Theater"); list.Add("   Aqua Pump Room");
                list.Add("India Palace Hub"); list.Add("   Guesthouse"); list.Add("   Basement"); list.Add("   Ballroom");
                list.Add("India Jungle Hub"); list.Add("   Spice Grinder"); list.Add("Prague Jail Hub");
                list.Add("   Jail"); list.Add("   Vault Room"); list.Add("Prague Fortress Hub");
                list.Add("Monaco Hub"); list.Add("   Crypt 3"); list.Add("   Crypts 1 & 2"); list.Add("   Ghost Capture Crypt");
                list.Add("   Re-education Tower & Crypt Hack"); list.Add("   Mojo Crypt 1"); list.Add("   Mojo Crypt 3");
                list.Add("   Mojo Crypt 2"); list.Add("   Mojo Crypt 4"); list.Add("Canada Hub"); list.Add("   Cabins");
                list.Add("   Train (Aerial Ass.)"); list.Add("   Train (Operation)"); list.Add("   Train (Ride the Iron Horse)");
                list.Add("Canada 2 Hub"); list.Add("   RC Combat Club"); list.Add("   Sawmill"); list.Add("   Lighthouse");
                list.Add("   Bear Cave"); list.Add("   Sawmill (Boss)"); list.Add("Blimp Hub"); list.Add("   Blimp HQ");
                list.Add("   Engine Room (Bentley & Murray)"); list.Add("   Engine Room (Sly & Bentley)"); 
                list.Add("   Engine Room (Murray & Sly)"); list.Add("   Paris (Clock-la)");
            }
            else if (b.StartsWith("Sly 3"))
            {
                list.Add("DVD Menu"); list.Add("Sampler Menu"); list.Add("Hazard Room"); list.Add("Venice Hub"); list.Add("   Canal");
                list.Add("   Coffeehouses"); list.Add("   Gauntlet / Opera House"); list.Add("   Police HQ"); list.Add("Outback Hub");
                list.Add("   Quarry / Ayers Rock"); list.Add("   Oil Field"); list.Add("   Cave (Sly)"); list.Add("   Cave (Guru)");
                list.Add("   Lemonade Bar"); list.Add("   Cave (Murray)"); list.Add("Holland Hub"); list.Add("   Hotel");
                list.Add("   Hangar (Team Iceland)"); list.Add("   Hangar (Team Black Baron)"); list.Add("   Hangar (Team Cooper)");
                list.Add("   Sewers");
                list.Add("   Dogfight / Biplane Battlefield"); list.Add("2P Hackathon"); list.Add("China Hub"); list.Add("(China Intro)");
                list.Add("   Flashback Arena"); list.Add("   Tsao's Battleground"); list.Add("   Panda King Apartment"); 
                list.Add("   Hall A (Grapplecam)"); list.Add("   Hall B (Tsao's Palace)"); list.Add("   Tilted Hall (Tsao's Treasure Temple)");
                list.Add("Bloodbath Bay / Pirate Hub"); list.Add("   Sailing Map"); list.Add("   Underwater Shipwreck"); list.Add("   Dagger Island");
                list.Add("Kaine Island"); list.Add("   Vault (Entrance)"); list.Add("   Vault (Gauntlet)"); list.Add("   Dr. M's Arena");
            }


            cb_loadlvl.Invoke((MethodInvoker)delegate
            {
                foreach (string s in list) cb_loadlvl.Items.Add(s);
            });
        }
        public void FillWarpLocations(UInt64 id)
        {
            cb_warps.Invoke((MethodInvoker)delegate
            {
                cb_warps.Items.Clear();
            });
            List<string> list = new List<string>();
            string nametouse = "";

            if (id == 2)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//paris hub
                {
                    nametouse = "Paris Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Nightclub (Door)");
                    list.Add("Nightclub (Window)");
                    list.Add("Nightclub (Top)");
                    list.Add("Dimitri's Boat");
                    list.Add("Courtyard");
                    list.Add("Tower");
                    list.Add("Hotel");
                }
            }
            else if (id == 3)
            {
                if(CurrentBuild.StartsWith("Sly 2"))//wine cellar
                {
                    nametouse = "Wine Cellar";
                    list.Add("Entrance");
                    list.Add("Lasers");
                    list.Add("Office");
                    list.Add("Music Room");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//venice hub
                {
                    nametouse = "Venice Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Police HQ");
                }
            }
            else if (id == 4)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//nightclub
                {
                    nametouse = "Nightclub";
                    list.Add("Entrance (Door)");
                    list.Add("Entrance (Window)");
                    list.Add("Dancefloor");
                    list.Add("Dimitri's Office");
                }
            }
            else if (id == 5)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//print room
                {
                    nametouse = "Print Room";
                    list.Add("Entrance (Recon)");
                    list.Add("Bottom Floor");
                    list.Add("Money Printer");
                    list.Add("Top Floor");
                }
            }
            else if (id == 6)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//theater
                {
                    nametouse = "Theater";
                    list.Add("Entrance");
                    list.Add("Fan Control");
                    list.Add("ZzZzZz (TV Guard)");
                    list.Add("Spotlight Control");
                }
            }
            else if (id == 7)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//aqua
                {
                    nametouse = "Aqua Pump Room";
                    list.Add("Entrance");
                    list.Add("Fireplace");
                    list.Add("Aqua Pump");
                }
            }
            else if (id == 8)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//india hub
                {
                    nametouse = "India Palace Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Inside)");
                    list.Add("Palace (Door)");
                    list.Add("Guesthouse (Top)");
                    list.Add("Cobra Statue");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//australia hub
                {
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Crane");
                    list.Add("Truck");
                }
            }
            else if (id == 12)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//india2 hub
                {
                    nametouse = "India Palace HUB";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Inside)");
                    list.Add("Palace (Door)");
                    list.Add("Guesthouse (Top)");
                    list.Add("Cobra Statue");
                }
            }
            else if (id == 15)
            {
                if (CurrentBuild.StartsWith("Sly 3"))//holland hub
                {
                    list.Add("Safehouse");
                    list.Add("Baron's Hangar");
                }
            }

            list.Sort();    //alphabetical
            cb_warps.Invoke((MethodInvoker)delegate
            {
                foreach(string s in list) cb_warps.Items.Add(s);
            });
            DelegateThisShit(label_curlev, nametouse);
        }
        public class TransformComponent
        {
            public static UInt64 Scale = 0x0; 
            public static UInt64 Position = 0x30;
            public static UInt64 Freeze = 0x94;
            public static UInt64 Warp0 = 0x98;
        }
        public class DetectionComponent
        {
            public static UInt64 DisableGuardAttacks = 0x1C;
        }

        public class Funs
        {
            public static UInt64 Lankyness;
        }

        public SlurkyTrainer()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
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
                        DelegateThisShit(label_base, "emu base = 0x" + BaseAddress.ToString("X"));
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

            GetLevelAOBs();
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
                    //FillWarpLocations(1);
                    UInt64 loadstate = GetGlobalValue(GlobalAddresses.Loading);
                    if(loadstate == 2)
                    {
                        CanFillWarps = true;
                    }
                    if(CanFillWarps && loadstate == 3)
                    {
                        FillWarpLocations(GetGlobalValue(GlobalAddresses.LevelID));
                        CanFillWarps = false;
                    }

                    //Debug.WriteLine(GetGlobalValue(GlobalAddresses.LevelID).ToString());
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
            UInt64 index = 0;
            Color colorToUse = Color.Gray;


            //index = GetGlobalValue(GlobalAddresses.ActChar);
            index = GetActiveCharacterData(EntityStruct.ID);

            toWrite = GetCharacterName(index);

            switch (toWrite)    //cosmetic
            {
                case CharacterNames.Sly:
                    colorToUse = Color.DarkBlue;
                    break;
                case CharacterNames.Bentley:
                    colorToUse = Color.DarkGreen;
                    break;
                case CharacterNames.Murray:
                    colorToUse = Color.DeepPink;
                    break;
                case CharacterNames.Carmelita:
                    colorToUse = Color.OrangeRed;
                    break;
                case CharacterNames.Guru:
                    colorToUse = Color.MediumPurple;
                    break;
                case CharacterNames.PandaKing:
                    colorToUse = Color.IndianRed;
                    break;
                case CharacterNames.Penelope:
                    colorToUse = Color.HotPink;
                    break;
                case CharacterNames.RCCar:
                    colorToUse = Color.Orchid;
                    break;
                case CharacterNames.Biplane:
                    colorToUse = Color.SlateBlue;
                    break;
                default:
                    break;
            }


            actEntName.Invoke((MethodInvoker)delegate
            {
                actEntName.Text = toWrite + " (" + index.ToString() + ")" ;
                actEntName.ForeColor = colorToUse;
            });

            UInt64 godStatus = GetActiveCharacterData(EntityStruct.God);
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

            UInt64 undetecStatus = GetActiveCharacterData(EntityStruct.Undetectable);
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

            UInt64 disguardatt = GetActiveCharacterInt(EntityStruct.DetectionComponent, DetectionComponent.DisableGuardAttacks);
            if (disguardatt == 1)
            {
                cb_atttarg.Invoke((MethodInvoker)delegate
                {
                    cb_atttarg.Checked = true;
                });
            }
            else if (disguardatt == 0)
            {
                cb_atttarg.Invoke((MethodInvoker)delegate
                {
                    cb_atttarg.Checked = false;
                });
            }

            UInt64 help = 0x0;
            float tempX = 0, tempY = 0, tempZ = 0;
            while (true)
            {
                float tempPos = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Position + help);
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

            float tempScale = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Scale);
            DelegateThisShit(actScale, tempScale.ToString("f5"));


            


        }

        void WarpSelectedCharacter(float x = 0, float y = 0, float z = 0, bool offsetting = false, float xoff = 0, float yoff = 0, float zoff = 0)
        {
            if(offsetting)
            {
                float currX = m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position).ToString("X"));
                float currY = m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x4).ToString("X"));
                float currZ= m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x8).ToString("X"));


                x = currX + xoff;
                y = currY + yoff;
                z = currZ + zoff;
            }
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position).ToString("X"), type: "float", write: x.ToString("f3"));
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x4).ToString("X"), type: "float", write: y.ToString("f3"));
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x8).ToString("X"), type: "float", write: z.ToString("f3"));


        }
        UInt64 GetGlobalValue(UInt64 offset)
        {
            return m.ReadUInt((BaseAddress + offset).ToString("X"));
        }
        void SetGlobalValue(UInt64 offset, string type, string towrite)
        {
            m.WriteMemory((BaseAddress + offset).ToString("X"), type, towrite);
        }
        UInt64 GetActiveCharacterData(UInt64 offset)
        {
            // thanks niv
            return m.ReadUInt((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X"));
        }


        UInt64 GetActiveCharacterInt(UInt64 offset, UInt64 offset2)
        {
            return m.ReadUInt((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2).ToString("X"));
        }


        float GetActiveCharacterData(UInt64 offset, UInt64 offset2)
        {
            return m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2).ToString("X"), round: false);
        }

        void SetActiveCharacterData(UInt64 offset, int setTo, bool freeze = false, bool unfreeze = false)
        {
            if(freeze)
            {
                if(!unfreeze)
                {
                    m.FreezeValue((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X"), "int", setTo.ToString());
                    return;
                }

                m.UnfreezeValue((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X"));
                return;
            }
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X"), "int", setTo.ToString());
        }

        void SetActiveCharacterData(UInt64 offset, UInt64 offset2, string setTo, bool vec3 = false, string writeType = "float")
        {
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2).ToString("X"), writeType, setTo);
            
            if(vec3)
            {
                UInt64 toAdd = 0x14;
                while(true)
                {
                    m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2 + toAdd).ToString("X"), type: writeType, write: setTo);
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
                SetActiveCharacterData(EntityStruct.God, 1);
                return;
            }
            SetActiveCharacterData(EntityStruct.God, 0);
        }

        private void cb_ignore_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ignore.Checked) 
            {
                SetActiveCharacterData(EntityStruct.Undetectable, 1);
                return;
            }
            SetActiveCharacterData(EntityStruct.Undetectable, 0);
        }

        private void cb_atttarg_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_atttarg.Checked)
            {
                SetActiveCharacterData(offset: EntityStruct.DetectionComponent, offset2: DetectionComponent.DisableGuardAttacks, setTo: "1");
                return;
            }
            SetActiveCharacterData(offset: EntityStruct.DetectionComponent, offset2: DetectionComponent.DisableGuardAttacks, setTo: "0");
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

        private void btn_0act_Click(object sender, EventArgs e)
        {
            SetActiveCharacterData(offset: EntityStruct.TransformComponent, offset2: TransformComponent.Warp0, setTo: 4.ToString(), writeType: "int");
        }

        private void btn_freezeAct_Click(object sender, EventArgs e)
        {
            UInt64 towrite;
            UInt64 temp = GetActiveCharacterInt(offset: EntityStruct.TransformComponent, TransformComponent.Freeze);
            Console.WriteLine(temp.ToString("X"));
            if (temp != 0) towrite = 0;
            else towrite = 1;
            SetActiveCharacterData(offset: EntityStruct.TransformComponent, offset2: TransformComponent.Freeze, setTo: towrite.ToString(), writeType: "int");
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            SetGlobalValue(GlobalAddresses.Reload, "int", "1");
        }

        private void btn_warp_Click(object sender, EventArgs e)
        {
            string txt = cb_warps.Text;
            if(txt != "")
            {
                UInt64 mapid = GetGlobalValue(GlobalAddresses.LevelID);
                float x = 0, y = 0, z = 0;
                if (CurrentBuild.StartsWith("Sly 2"))
                {
                    if (mapid == 2) //paris hub
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -1800; y = -4100; z = 535; break;
                            case "Safehouse (Top)":
                                x = -2665; y = -3640; z = 1256; break;
                            case "Nightclub (Door)":
                                x = -1645; y = 5655; z = 60; break;
                            case "Nightclub (Window)":
                                x = -3455; y = 5510; z = 1100; break;
                            case "Nightclub (Top)":
                                x = 0; y = 0; z = 5000; break;
                            case "Dimitri's Boat":
                                x = -7090; y = -6320; z = -30; break;
                            case "Courtyard":
                                x = 1860; y = 5630; z = -50; break;
                            case "Tower":
                                x = 8600; y = 2080; z = 2070; break;
                            case "Hotel":
                                x = 4430; y = -8000; z = 2420; break;
                        }
                    }
                    else if (mapid == 3) //wine cellar
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 14500; y = -6700; z = 470; break;
                            case "Lasers":
                                x = 10340; y = -3900; z = 60; break;
                            case "Office":
                                x = 5800; y = -2900; z = -150; break;
                            case "Music Room":
                                x = 95; y = 2850; z = 125; break;
                        }
                    }
                    else if (mapid == 4) //night club
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance (Door)":
                                x = -2670; y = 5880; z = -540; break;
                            case "Entrance (Window)":
                                x = -7780; y = 1440; z = 810; break;
                            case "Dancefloor":
                                x = -7030; y = 8845; z = -1000; break;
                            case "Dimitri's Office":
                                x = -3800; y = 6460; z = 200; break;
                        }
                    }
                    else if (mapid == 5) //print room
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance (Recon)":
                                x = -1100; y = 4180; z = 1470; break;
                            case "Bottom Floor":
                                x = 0; y = 0; z = -50; break;
                            case "Money Printer":
                                x = 0; y = 900; z = 740; break;
                            case "Top Floor":
                                x = 0; y = 1800; z = 1570; break;
                        }
                    }
                    else if (mapid == 6) //theater
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -40; y = 4220; z = 910; break;
                            case "Fan Control":
                                x = 7000; y = 5110; z = 730; break;
                            case "ZzZzZz (TV Guard)":
                                x = 3800; y = 8490; z = 895; break;
                            case "Spotlight Control":
                                x = 2560; y = 5820; z = 1560; break;
                        }
                    }
                    else if (mapid == 7) //aqua
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -13060; y = 6580; z = -170; break;
                            case "Fireplace":
                                x = -9670; y = 2470; z = -540; break;
                            case "Aqua Pump":
                                x = -5560; y = 3850; z = 130; break;
                        }
                    }
                    else if (mapid == 8) //india 1
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -4600; y = 2180; z = 460; break;
                            case "Safehouse (Inside)":
                                x = -6670; y = -1470; z = 2270; break;
                            case "Palace (Door)":
                                x = 10000; y = 2100; z = 1690; break;
                            case "Guesthouse (Top)":
                                x = 3160; y = -10420; z = 1770; break;
                            case "Cobra Statue":
                                x = 6950; y = 8680; z = 1770; break;
                        }
                    }

                }
                else if(CurrentBuild.StartsWith("Sly 3"))
                {
                    if(mapid == 3)
                    {
                        switch(txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 200; y = -2090; z = 173; break;
                            case "Safehouse (Top)":
                                x = 863; y = -1420; z = 1266; break;
                            case "Police HQ":
                                x = -7570; y = 1670; z = 1962; break;
                        }
                    }
                    else if (mapid == 8)
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -4570; y = -7190; z = 1525; break;
                            case "Safehouse (Top)":
                                x = -4590; y = -7820; z = 2650; break;
                            case "Crane":
                                x = -700; y = -1290; z = 4320; break;
                            case "Truck":
                                x = 9820; y = -550; z = 1240; break;
                        }
                    }
                }

                WarpSelectedCharacter(x, y, z+100);
                SetGlobalValue(GlobalAddresses.ResetCamera, "int", "1");    //  reset cam when warpin
            }
            
        }

        private void cb_character_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = cb_character.Text;
            string b = GetBuildName();
            if (sel == "Active")
            {
                if(b == BuildNames.Sly2NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2NTSC;
                }
                else if (b == BuildNames.Sly2PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2PAL;
                }
                else if (b == BuildNames.Sly3NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3NTSC;
                }
                else if (b == BuildNames.Sly3PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3PAL;
                }
            }
            else if (sel == CharacterNames.Sly)
            {
                CurrentCharStruct = CharStructPtrs.Sly;
            }
            else if (sel == CharacterNames.Bentley)
            {
                CurrentCharStruct = CharStructPtrs.Bentley;
            }
            else if (sel == CharacterNames.Murray)
            {
                CurrentCharStruct = CharStructPtrs.Murray;
            }

        }

        private void btn_loadlvl_Click(object sender, EventArgs e)
        {
            if(cb_loadlvl.Text != "")
            {
                m.WriteBytes((BaseAddress + GlobalAddresses.CurrentLevelAOB).ToString("X"), LevelAOBs[cb_loadlvl.SelectedIndex]);
                SetGlobalValue(GlobalAddresses.Reload, "int", "1");
            }
        }

        private void cb_fun_lanky_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_fun_lanky.Checked)
            {
                m.FreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness).ToString("X"), "float", "0.4");
                
                m.FreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness+0x14).ToString("X"), "float", "0.4");
                
                m.FreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x28).ToString("X"), "float", "0.4");
            }
            else
            {
                m.UnfreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness).ToString("X"));
                
                m.UnfreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x14).ToString("X"));

                m.UnfreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x28).ToString("X"));



                m.WriteMemory((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness).ToString("X"), "float", "1");

                m.WriteMemory((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x14).ToString("X"), "float", "1");

                m.WriteMemory((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x28).ToString("X"), "float", "1");
            }
        }

        private void btn_allgadgets_Click(object sender, EventArgs e)
        {
            SetGlobalValue(GlobalAddresses.UnlockGadgets, "int", "-1");
            SetGlobalValue(GlobalAddresses.UnlockGadgets2, "int", "-1");
        }

        private void btn_decX_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, xoff: -CoordAdjustAmt);
        }

        private void btn_incX_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, xoff: CoordAdjustAmt);
        }

        private void btn_decY_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, yoff: -CoordAdjustAmt);
        }

        private void btn_incY_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, yoff: CoordAdjustAmt);
        }

        private void btn_decZ_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, zoff: -CoordAdjustAmt);
        }

        private void btn_incZ_Click(object sender, EventArgs e)
        {
            WarpSelectedCharacter(offsetting: true, zoff: CoordAdjustAmt);
        }

        private void tbar_coordmag_ValueChanged(object sender, EventArgs e)
        {
            CoordAdjustAmt = tbar_coordmag.Value;
        }

        string GetBuildName()
        {
            if (!GoodBase) return "-";      //  fallback

            
            if (m.ReadString((BaseAddress + 0x2C46D8).ToString("X")) == "0813.0032") return BuildNames.Sly2NTSC;
            else if (m.ReadString((BaseAddress + 0x2CBB08).ToString("X")) == "0914.1846") return BuildNames.Sly2PAL;
            else if (m.ReadString((BaseAddress + 0x2C6470).ToString("X")) == "0711.1656") return BuildNames.Sly2July11;
            else if (m.ReadString((BaseAddress + 0x34A2F8).ToString("X")) == "0828.0212") return BuildNames.Sly3NTSC;



            else return "-";
        }
    }
}
