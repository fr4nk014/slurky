using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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


        bool CanFillWarps = true;

        string CurrentBuild;

        List<UInt64> FrozenAddresses;
        List<string> LevelAOBList;
        List<byte[]> LevelAOBs;
        public UInt64 LevelAmt;

        public float CoordAdjustAmt = 200f;

        string LoadToLevelAs = "Active";

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
            public static UInt64 GuardAI;

            public static UInt64 UnlockGadgets;


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
            public static UInt64 Carmelita;
            public static UInt64 Guru;
            public static UInt64 Penelope;

            public static UInt64 ClueBottle;
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
            public static UInt64 ColliderPtr;
        }

        public class CameraStuff
        {
            //sly 3 specific bullshittery
            public static UInt64 Cam0Ptr;
            public static UInt64 CamReset;
        }

        public class MiscPtrs
        {
            public static UInt64 ClueSpawns = 0x3E051C; //  spawn locations
            public static UInt64 FirstClue = 0x90;
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

            cb_character.Invoke((MethodInvoker)delegate
            {
                cb_character.Items.Add("Active");
                cb_character.Items.Add(CharacterNames.Sly);
                cb_character.Items.Add(CharacterNames.Bentley);
                cb_character.Items.Add(CharacterNames.Murray);
            });

            if (build == BuildNames.Sly2NTSC || build == BuildNames.Sly2PAL)
            {
                EntityStruct.ID = 0x18;
                EntityStruct.God = 0x298;
                EntityStruct.Undetectable = 0x11AC;
                EntityStruct.InfJumps = 0x2E8;
                EntityStruct.TransformComponent = 0x58;
                Funs.Lankyness = 0x2400;

                cb_loadas.Invoke((MethodInvoker)delegate
                {
                    cb_loadas.Items.Clear();
                    cb_loadas.Items.Add(CharacterNames.Sly);
                    cb_loadas.Items.Add(CharacterNames.Bentley);
                    cb_loadas.Items.Add(CharacterNames.Murray);
                });
                LevelAmt = 44;

                if (build == BuildNames.Sly2NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2NTSC;
                    GlobalAddresses.ActChar = 0x3D4A6C;
                    GlobalAddresses.Reload = 0x3E1080; //aob = +8
                    GlobalAddresses.CurrentLevelAOB = 0x3E1088;
                    GlobalAddresses.ResetCamera = 0x2DE240;
                    GlobalAddresses.LevelID = 0x3E1110;
                    GlobalAddresses.Loading = 0x3D3980;
                    GlobalAddresses.UnlockGadgets = 0x3D4AF8;

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x2DDEDC;
                    GlobalAddresses.DrawDist = 0x2DDF5C;
                    GlobalAddresses.FOV = 0x2DDF64; //-0x4 = currentfov

                    LevelAOBStart = 0x3E1C40;
                    

                    CharStructPtrs.Sly = 0x2E1E40;
                    CharStructPtrs.Bentley = 0x2DD5BC;
                    CharStructPtrs.Murray = 0x2F7900;

                    CharStructPtrs.ClueBottle = 0x3E093C;
                }
                else if (build == BuildNames.Sly2PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly2PAL;
                    GlobalAddresses.ActChar = 0x3DC26C;
                    GlobalAddresses.Reload = 0x3E8880;
                    GlobalAddresses.ResetCamera = 0x2E5640;
                    GlobalAddresses.LevelID = 0x3E8910;

                    GlobalAddresses.UnlockGadgets = 0x3DC2F8;

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
                EntityStruct.Undetectable = 0x1280;
                EntityStruct.TransformComponent = 0x48;
                EntityStruct.DetectionComponent = 0x1160;
                EntityStruct.ColliderPtr = 0xD8;

                cb_infjmp.Invoke((MethodInvoker)delegate
                {
                    cb_infjmp.Enabled = false;
                });
                cb_fun_lanky.Invoke((MethodInvoker)delegate
                {
                    cb_fun_lanky.Enabled = false;
                });
                cb_character.Invoke((MethodInvoker)delegate
                {
                    cb_character.Items.Add(CharacterNames.Carmelita);
                    cb_character.Items.Add(CharacterNames.Guru);
                    cb_character.Items.Add(CharacterNames.Penelope);
                });

                cb_loadas.Invoke((MethodInvoker)delegate
                {
                    cb_loadas.Items.Clear();
                    cb_loadas.Items.Add(CharacterNames.Sly);
                    cb_loadas.Items.Add(CharacterNames.Bentley);
                    cb_loadas.Items.Add(CharacterNames.Murray);
                    cb_loadas.Items.Add(CharacterNames.Guru);
                    cb_loadas.Items.Add(CharacterNames.PandaKing);
                    cb_loadas.Items.Add(CharacterNames.Penelope);
                });
                LevelAmt = 39;

                if (build == BuildNames.Sly3NTSC)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3NTSC;
                    GlobalAddresses.ActChar = 0x36C710;
                    GlobalAddresses.Reload = 0x4797C4; //aob = +8
                    GlobalAddresses.CurrentLevelAOB = 0x4797CC;
                    //GlobalAddresses.ResetCamera = 0xD40384;
                    GlobalAddresses.LevelID = 0x47989C;
                    GlobalAddresses.Loading = 0x467B00;
                    GlobalAddresses.UnlockGadgets = 0x468DCC;

                    GlobalAddresses.GuardAI = 0x370a8c;

                    //engine stuffs
                    GlobalAddresses.CameraSpeed = 0x36BBA4;
                    GlobalAddresses.DrawDist = 0x2DDF5C;            // unassigned
                    GlobalAddresses.FOV = 0x2DDF60;                 // unassigned

                    LevelAOBStart = 0x2EDFD8;
                    

                    CharStructPtrs.Sly = 0x370AC0;
                    CharStructPtrs.Bentley = 0x36B250;
                    CharStructPtrs.Murray = 0x38AE90;

                    CameraStuff.Cam0Ptr = 0x47933C;
                    CameraStuff.CamReset = 0x2F4;
                }
                else if (build == BuildNames.Sly3PAL)
                {
                    CurrentCharStruct = ActCharPtrs.Sly3PAL;
                    GlobalAddresses.ActChar = 0x3DC26C;
                    GlobalAddresses.Reload = 0x3E8880;              // unassigned
                    //GlobalAddresses.ResetCamera = 0xC68824;         
                    GlobalAddresses.LevelID = 0x3E8910;             // unassigned

                    GlobalAddresses.GuardAI = 0x37150c;


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
            if (CurrentBuild.StartsWith("Sly 3"))
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

                if (bytes == null)
                {
                    return;
                }

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
            if (b.StartsWith("Sly 2"))
            {
                list.Add("Cairo Museum"); list.Add("DVD Menu"); list.Add("Paris Hub"); list.Add("   Wine Cellar");
                list.Add("   Nightclub"); list.Add("   Print Room"); list.Add("   Theater"); list.Add("   Aqua Pump Room");
                list.Add("India Palace Hub"); list.Add("   Guesthouse"); list.Add("   Basement"); list.Add("   Ballroom");
                list.Add("India Jungle Hub"); list.Add("   Spice Grinder"); list.Add("Prague Jail Hub");
                list.Add("   Jail"); list.Add("   Vault Room"); list.Add("Prague Fortress Hub");
                list.Add("Monaco Hub"); list.Add("   Crypt 3"); list.Add("   Crypts 1 & 2"); list.Add("   Ghost Capture Crypt");
                list.Add("   Re-education Tower & Crypt Hack"); list.Add("   Mojo Crypt 1"); list.Add("   Mojo Crypt 3");
                list.Add("   Mojo Crypt 2"); list.Add("   Mojo Crypt 4"); list.Add("Canada Hub"); list.Add("   Cabins");
                list.Add("   Train (Aerial Ass. / Theft On Rails)"); list.Add("   Train (Operation)"); list.Add("   Train (Ride the Iron Horse)");
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
                list.Add("Kaine Island"); list.Add("   Underwater"); list.Add("   Vault (Entrance)"); list.Add("   Vault (Gauntlet)"); list.Add("   Dr. M's Arena");
            }


            cb_loadlvl.Invoke((MethodInvoker)delegate
            {
                foreach (string s in list) cb_loadlvl.Items.Add(s);
            });
        }
        void FillJobDropdown()
        {
            List<string> list = new List<string>();
            if (CurrentBuild == ("Sly 2 NTSC") || CurrentBuild == ("Sly 2 PAL"))
            {
                list.Add("Spawn");
            }
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
                            processStatuslabel.ForeColor = Color.MidnightBlue;
                        });
                        DelegateThisShit(label_base, "EE Base Address = 0x" + BaseAddress.ToString("X"));
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
                    if (loadstate == 2)
                    {
                        CanFillWarps = true;
                    }
                    if (CanFillWarps && loadstate == 3)
                    {
                        FillWarpLocations(GetGlobalValue(GlobalAddresses.LevelID));
                        //   moved this elsewhere   GetEntityList();
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
                actEntName.Text = toWrite + " (" + index.ToString() + ")";
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

            float tempX = 0, tempY = 0, tempZ = 0;
            tempX = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Position);
            tempY = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Position + 0x4);
            tempZ = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Position + 0x8);

            DelegateThisShit(actCoordX, tempX.ToString("f5"));
            DelegateThisShit(actCoordY, tempY.ToString("f5"));
            DelegateThisShit(actCoordZ, tempZ.ToString("f5"));

            float tempScale = GetActiveCharacterData(EntityStruct.TransformComponent, TransformComponent.Scale);
            DelegateThisShit(actScale, tempScale.ToString("f5"));
        }

        bool ValidateCharacter() // safety check to avoid sly 3 crashes on load
        {
            if(GetGlobalValue(GlobalAddresses.Loading) != 3)
            {
                Console.WriteLine("validate fail, load");
                return false;
            }
            UInt64 actid = GetGlobalValue(GlobalAddresses.ActChar);
            if (actid < 7) return false;
            if (actid > 100) return false;
            return true;
        }

        void WarpSelectedCharacter(float x = 0, float y = 0, float z = 0, bool offsetting = false, float xoff = 0, float yoff = 0, float zoff = 0, bool resetCam = true)
        {
            //if (!ValidateCharacter()) return;

            string tempColPtr = m.ReadUInt((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.ColliderPtr).ToString("X")).ToString();
            if (Convert.ToInt64(tempColPtr) == 0x0) 
            {
                MessageBox.Show("Collider pointer missing. Risk of permanent loss of collider.", "Collider Pointer Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            Console.WriteLine(tempColPtr);
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.ColliderPtr).ToString("X"), "int", "0");
            Thread.Sleep(10);
            if (offsetting)
            {
                float currX = m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position).ToString("X"));
                float currY = m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x4).ToString("X"));
                float currZ = m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x8).ToString("X"));


                x = currX + xoff;
                y = currY + yoff;
                z = currZ + zoff;
            }


            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position).ToString("X"), type: "float", write: x.ToString("f3"));
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x4).ToString("X"), type: "float", write: y.ToString("f3"));
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") + "," + (BaseAddress + TransformComponent.Position + 0x8).ToString("X"), type: "float", write: z.ToString("f3"));
            Thread.Sleep(10);
            SetActiveCharacterData(offset: EntityStruct.TransformComponent, offset2: TransformComponent.Warp0, setTo: "2", writeType: "int");
            if(resetCam)
            {
                if(CurrentBuild.StartsWith("Sly 2"))
                {
                    SetGlobalValue(GlobalAddresses.ResetCamera, "int", "1");
                }
                else
                {
                    m.WriteMemory((BaseAddress + CameraStuff.Cam0Ptr).ToString("X") + "," + (BaseAddress + CameraStuff.CamReset).ToString("X"), "int", "1");
                }
            }
            m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + EntityStruct.ColliderPtr).ToString("X"), "int", tempColPtr); //re enable col ptr
            
        }
        UInt64 GetGlobalValue(UInt64 offset)
        {
            return m.ReadUInt((BaseAddress + offset).ToString("X"));
        }
        void SetGlobalValue(UInt64 offset, string type, string towrite, bool freeze = false)
        {
            if (freeze)
            {
                m.FreezeValue((BaseAddress + offset).ToString("X"), type, towrite);
                return;
            }
            m.UnfreezeValue((BaseAddress + offset).ToString("X"));
            m.WriteMemory((BaseAddress + offset).ToString("X"), type, towrite);
        }
        UInt64 GetActiveCharacterData(UInt64 offset)
        {
            // thanks niv
            return m.ReadUInt((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X"));
        }


        UInt64 GetActiveCharacterInt(UInt64 offset, UInt64 offset2)
        {
            if (!ValidateCharacter()) return 0;
            UInt64 temp = 0; // weird crash
            temp = m.ReadUInt((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2).ToString("X"));
            return temp;
        }


        float GetActiveCharacterData(UInt64 offset, UInt64 offset2)
        {
            return m.ReadFloat((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2).ToString("X"), round: false);
        }

        void SetActiveCharacterData(UInt64 offset, int setTo, bool freeze = false, bool unfreeze = false)
        {
            if (freeze)
            {
                if (!unfreeze)
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

            if (vec3)    //  youre welcome niv
            {
                m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2 + 0x14).ToString("X"), type: writeType, write: setTo);
                m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2 + 0x28).ToString("X"), type: writeType, write: setTo);
                m.WriteMemory((BaseAddress + CurrentCharStruct).ToString("X") + "," + (BaseAddress + offset).ToString("X") + "," + (BaseAddress + offset2 + 0x42).ToString("X"), type: writeType, write: setTo);
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

        public void CurrentProcessBaseFinder()      //luminar's method
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
            if (cb_god.Checked)
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
            bool shouldfreeze = !cb_infjmp.Checked;
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

        public void FillWarpLocations(UInt64 id)
        {
            cb_warps.Invoke((MethodInvoker)delegate
            {
                cb_warps.Items.Clear();
            });
            List<string> list = new List<string>();
            string nametouse = "N/A";

            if (id == 0)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//cairo
                {
                    nametouse = "Cairo Museum";
                    list.Add("Spawn");
                    list.Add("Balcony 1");
                    list.Add("Balcony 2");
                    list.Add("Murray Rendezvous");
                    list.Add("Warehouse");
                    list.Add("Chase Start");
                    list.Add("Pickup Point");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//dvd
                {
                    nametouse = "DVD Menu";
                }
            }
            else if (id == 1)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//dvd
                {
                    nametouse = "DVD Menu";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//e3
                {
                    nametouse = "Sampler Menu";
                }
            }
            else if (id == 2)
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
                else if (CurrentBuild.StartsWith("Sly 3"))//hazard
                {
                    nametouse = "Hazard Room";
                    list.Add("Center");
                    list.Add("Top");
                    list.Add("Safehouse");
                }
            }
            else if (id == 3)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//wine cellar
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
                    list.Add("Ferris Wheel");
                    list.Add("Stage");
                    list.Add("Fountain");
                    list.Add("Aquarium");
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
                else if (CurrentBuild.StartsWith("Sly 3"))//canal
                {
                    nametouse = "Canals";
                    list.Add("Boat");
                    list.Add("Intersection 1");
                    list.Add("Intersection 2");
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
                else if (CurrentBuild.StartsWith("Sly 3"))//coffeehouses
                {
                    nametouse = "Coffeehouses";
                    list.Add("Entrance 1");
                    list.Add("Entrance 2");
                    list.Add("Entrance 3");
                    list.Add("Safe 1");
                    list.Add("Safe 2");
                    list.Add("Safe 3");
                    list.Add("'Roof'");
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
                else if (CurrentBuild.StartsWith("Sly 3"))//opera gauntlet
                {
                    nametouse = "Opera House";
                    list.Add("Main Entrance");
                    list.Add("Basement Entrance");
                    list.Add("Pump Room");
                    list.Add("Worlitzer-700");
                    list.Add("Underground Canal");
                    list.Add("Overlook");
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
                else if (CurrentBuild.StartsWith("Sly 3"))//police hq
                {
                    nametouse = "Police Headquarters";
                    list.Add("Dimitri's Cell");
                    list.Add("Cell Key");
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
                    list.Add("Drain Pipe (Basement Entrance)");
                    list.Add("Drawbridge Control");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//australia hub
                {
                    nametouse = "Outback Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Crane");
                    list.Add("Truck");
                    list.Add("Guru's Hut");
                    list.Add("Guru's Cell");
                    list.Add("Treeline");
                    list.Add("Plateau");
                }
            }
            else if (id == 9)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//guesthouse
                {
                    nametouse = "Guesthouse";
                    list.Add("Entrance");
                    list.Add("Room 101");
                    list.Add("Room 102");
                    list.Add("Room 103");
                    list.Add("Room 104");
                    list.Add("Room 105");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//ayers rock
                {
                    nametouse = "Ayers Rock";
                    list.Add("Drill Controls");
                    list.Add("Drill Controls (Top)");
                    list.Add("Truck Spawn");
                    list.Add("Mine Entrance");
                    list.Add("Clifftop");
                }
            }
            else if (id == 10)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//palace basement
                {
                    nametouse = "Palace Basement";
                    list.Add("Entrance");
                    list.Add("Vault");
                    list.Add("Boardroom");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//Oilfield
                {
                    nametouse = "Oil Field";
                    list.Add("The Claw");
                    list.Add("Catapult");
                    list.Add("Drill Platform");
                }
            }
            else if (id == 11)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//ballroom
                {
                    nametouse = "Ballroom";
                    list.Add("Entrance");
                    list.Add("Dance Floor");
                    list.Add("Guests (Left)");
                    list.Add("Guests (Right)");

                }
                else if (CurrentBuild.StartsWith("Sly 3"))//cave moonstone
                {
                    nametouse = "Moonstone Cave";
                    list.Add("Entrance");
                    list.Add("Safe");
                    list.Add("Drills");
                }
            }
            else if (id == 12)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//india2 hub
                {
                    nametouse = "India Jungle Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Tilting Temple");
                    list.Add("Temple Entrance");
                    list.Add("Waterfall");
                    list.Add("Top of Dam");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//cave staff
                {
                    nametouse = "Staff Cave";
                    list.Add("Entrance");
                    list.Add("Safe");
                    list.Add("Hook Conveyor Belt");
                }
            }
            else if (id == 13)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//spice fac
                {
                    nametouse = "Spice Factory";
                    list.Add("Factory Entrance");
                    list.Add("Factory Entrance (Top)");
                    list.Add("Factory Recon Area");
                    list.Add("Spice Grinder");
                    list.Add("Spice Grinder Entrance");
                    list.Add("Rajan's Office");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//lemonade
                {
                    nametouse = "Lemonade Bar";
                }
            }
            else if (id == 14)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//prague 1
                {
                    nametouse = "Prague Jail Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Bridge");
                    list.Add("Prison (Center)");
                    list.Add("Prison (Sly)");
                    list.Add("Rooftop 1");
                    list.Add("Rooftop 2");
                    list.Add("Weird House");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//cave mur
                {
                    nametouse = "Spelunking Cave";
                    list.Add("Entrance");
                    list.Add("Piston");
                    list.Add("Triple Piston");
                    list.Add("Drilling Area");
                }
            }
            else if (id == 15)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//prague 1 jail
                {
                    nametouse = "Jail";
                    list.Add("Entrance");
                    list.Add("Murray's Cell");
                    list.Add("Hypno Arena");
                    list.Add("Control Room");

                }
                else if (CurrentBuild.StartsWith("Sly 3"))//holland hub
                {
                    nametouse = "Holland Hub";
                    list.Add("Safehouse");
                    list.Add("Baron's Hangar");
                    list.Add("Ramp");
                    list.Add("Forest");
                    list.Add("Barn");
                    list.Add("Well");
                }
            }
            else if (id == 16)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//vault room weird lights
                {
                    nametouse = "Scuffed Vault Room";
                    list.Add("Entrance");
                    list.Add("Behind the Wall");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//hotel
                {
                    nametouse = "Hotel";
                    list.Add("'Safehouse Entrance'");
                    list.Add("Ham");
                    list.Add("Viking Helmet");
                    list.Add("'Outside'");
                }
            }
            else if (id == 17)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//prague 2
                {
                    nametouse = "Prague Fortress Hub";
                    list.Add("Safehouse");
                    list.Add("Sewer");
                    list.Add("Graveyard");
                    list.Add("Castle Top 1");
                    list.Add("Castle Top 2");
                    list.Add("Castle Top 3");
                    list.Add("Guillotine");
                    list.Add("Re-education Tower (Entrance)");
                    list.Add("Re-education Tower (Balcony)");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Hangar (Team Iceland)";
                }
            }
            else if (id == 18)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//prague 2
                {
                    nametouse = "Monaco Hub";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Black Baron's Hangar";
                }
            }
            else if (id == 19)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//crypt3
                {
                    nametouse = "Crypt 3";
                    list.Add("Entrance");
                    list.Add("End");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//cooper hangar
                {
                    nametouse = "Hangar (Team Cooper)";
                    list.Add("Center");
                    list.Add("Control Room");
                    list.Add("Truck");
                }
            }
            else if (id == 20)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//crypt12
                {
                    nametouse = "Crypts 1 + 2";
                    list.Add("Entrance (Crypt 1)");
                    list.Add("Vault (Crypt 1)");
                    list.Add("Entrance (Crypt 2)");
                    list.Add("End (Crypt 2)");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))//sew
                {
                    nametouse = "Sewer";
                    list.Add("Entrance");
                    list.Add("Iceland Hotel Path");
                    list.Add("Exit to Surface");
                    list.Add("Iceland Hotel Entrance");
                }
            }
            else if (id == 21)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//crypt ghost cap
                {
                    nametouse = "Ghost Capture Crypt";
                    list.Add("Entrance");
                    list.Add("Tomb");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Biplane Battlefield";
                    list.Add("Barn");
                    list.Add("Crop Squares");
                    list.Add("Bridge 1");
                    list.Add("Bridge 2");
                    list.Add("Bridge 3");
                    list.Add("Boss Arena");
                }
            }
            else if (id == 22)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//re edu
                {
                    nametouse = "Re.education Tower / Crypt Hack";
                    list.Add("Entrance (Re-education Tower)");
                    list.Add("Re-education Cell");
                    list.Add("Entrance (Hack)");
                    list.Add("End (Hack)");
                    list.Add("Unused Area 1");
                    list.Add("Unused Area 2");
                    list.Add("Unused Area 3");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Hackathon";
                }
            }
            else if (id == 23)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//mojo1
                {
                    nametouse = "Mojo Crypt 1";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "China Hub";
                    list.Add("Safehouse");
                    list.Add("Turret Tower");
                    list.Add("Walk Across the Heavens");
                    list.Add("Graveyard");
                    list.Add("Statue");
                    list.Add("Palace");
                }
            }
            else if (id == 24)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//mojo3
                {
                    nametouse = "Mojo Crypt 3";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "China Intro Mountains";
                    list.Add("Start Platform");
                    list.Add("Panda King's Perch");
                    list.Add("House");
                    list.Add("Clifftop");
                }
            }
            else if (id == 25)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//mojo2
                {
                    nametouse = "Mojo Crypt 2";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Flashback Arena";
                }
            }
            else if (id == 26)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//mojo4
                {
                    nametouse = "Mojo Crypt 4";
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Tsao's Battleground";
                    list.Add("Entrance Platform");
                    list.Add("Ground Level");
                    list.Add("Overlook");
                }
            }
            else if (id == 27)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//canada hub
                {
                    nametouse = "Canada 1 Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Cabin 1");
                    list.Add("Cabin 2");
                    list.Add("Cabin 3");
                    list.Add("Satellite Dish");
                    list.Add("Plane");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Panda King's Apartment";
                    list.Add("Yang");
                    list.Add("Yin");
                }
            }
            else if (id == 28)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//cabins
                {
                    nametouse = "Cabins";
                    list.Add("Cabin 1");
                    list.Add("Cabin 2");
                    list.Add("Cabin 3");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Hall A (Grapplecam)";
                    list.Add("Laser Wall");
                    list.Add("Second Floor");
                    list.Add("Computer");
                    list.Add("'Outside'");
                    list.Add("Overlook");
                }
            }
            else if (id == 29)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//train aerial theft
                {
                    nametouse = "Train (Aerial Ass. / Theft on Rails)";
                    list.Add("Back");
                    list.Add("Front");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Hall B (Palace)";
                    list.Add("Vases");
                    list.Add("Computer");
                    list.Add("Jing King's Room");
                    list.Add("Drill Site");
                }
            }
            else if (id == 30)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//train op
                {
                    nametouse = "Train (Operation)";
                    list.Add("Back");
                    list.Add("Front");
                    list.Add("Jean Bison");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Treasure Temple";
                    list.Add("Entrance");
                    list.Add("Treasure Area");
                    list.Add("Crawlspace");
                }
            }
            else if (id == 31)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//train iron horse
                {
                    nametouse = "Train (Iron Horse)";
                    list.Add("Back");
                    list.Add("Front");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Bloodbath Bay Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Skull Keep (Top)");
                    list.Add("Waterfall (Top)");
                    list.Add("Fireplace");
                    list.Add("Monkeys?");
                    list.Add("Cooper Gang Ship");
                    list.Add("Archipelago");
                }
            }
            else if (id == 32)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//canada 2
                {
                    nametouse = "Canada 2 Hub";
                    list.Add("Safehouse");
                    list.Add("Van");
                    list.Add("Sawmill 1");
                    list.Add("Sawmill 2");
                    list.Add("Sawmill 3 / RC Combat Club");
                    list.Add("Bomb Fishing Spot");
                    list.Add("Battery Silo");
                    list.Add("Lighthouse");
                    list.Add("Lighthouse (Top)");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                }
            }
            else if (id == 33)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//rc comb
                {
                    nametouse = "RC Combat Club";
                    list.Add("Moose Head");
                    list.Add("Sawblade Crawl");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Underwater Shipwreck";
                    list.Add("Spawn");
                    list.Add("Ship (Top)");
                    list.Add("Shipwreck");
                    list.Add("Depths");
                    list.Add("Ocean Current");
                }
            }
            else if (id == 34)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//sawmill
                {
                    nametouse = "Sawmill";
                    list.Add("Vault");
                    list.Add("Lasers");
                    list.Add("Lever");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Dagger Island";
                    list.Add("Cooper Gang Ship");
                    list.Add("Palm Tree Circle");
                    list.Add("Flipped Ship");
                    list.Add("Pirate Ship");
                    list.Add("Mountain Peak");
                }
            }
            else if (id == 35)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//lighthouse
                {
                    nametouse = "Lighthouse";
                    list.Add("Top Entrance");
                    list.Add("Bottom");
                    list.Add("Recon");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Kaine Island";
                    list.Add("Spawn");
                    list.Add("Wall Sneak (Top)");
                    list.Add("Ventilation Shaft");
                    list.Add("Vault Entrance");
                    list.Add("Ship Dock");
                    list.Add("Cooper Gang Ship");
                    list.Add("RC Car Track");
                    list.Add("Random Rope");
                    list.Add("Rock Formation");
                }
            }
            else if (id == 36)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//bearcave
                {
                    nametouse = "Bear Cave";
                    list.Add("Entrance");
                    list.Add("Large Ice Wall");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Underwater";
                    list.Add("Spawn");
                    list.Add("Water Tube");
                    list.Add("Boss Area");
                }
            }
            else if (id == 37)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//saw boss
                {
                    nametouse = "Sawmill (Boss)";
                    list.Add("Arena");
                    list.Add("Control Room");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Vault (Entrance)";
                    list.Add("Center");
                    list.Add("Entrance Door");
                }
            }
            else if (id == 38)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//blimp
                {
                    nametouse = "Blimp Hub";
                    list.Add("Safehouse");
                    list.Add("Safehouse (Top)");
                    list.Add("Balloon 1");
                    list.Add("Balloon 2");
                    list.Add("Engine 1");
                    list.Add("Engine 2");
                    list.Add("Center");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Vault (Gauntlet)";
                    list.Add("Slytunkhamen II");
                    list.Add("Sir Galleth Cooper");
                    list.Add("Salim Al-Kupar");
                    list.Add("Slaigh MacCooper");
                    list.Add("Rioichi Cooper");
                    list.Add("Henriette Cooper");
                    list.Add("Tennesee 'Kid' Cooper");
                    list.Add("Thaddeus Winslow Cooper III");
                    list.Add("Otto Van Cooper");
                    list.Add("Conner Cooper");
                    list.Add("Inner Sanctum Entrance");
                }
            }
            else if (id == 39)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//blimp HQ
                {
                    nametouse = "Blimp Headquarters";
                    list.Add("Entrance");
                    list.Add("Clockwerk");
                    list.Add("Center");
                    list.Add("Neyla");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    nametouse = "Vault (Inner Sanctum)";
                    list.Add("Center");
                    list.Add("Top Platform");
                }
            }
            else if (id == 40)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//engine b m
                {
                    nametouse = "Engine Room (Bentley + Murray)";
                    list.Add("Entrance");
                    list.Add("Control Room");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                }
            }
            else if (id == 41)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//engine s b
                {
                    nametouse = "Engine Room (Sly + Bentley)";
                    list.Add("Entrance");
                    list.Add("Control Room");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                }
            }
            else if (id == 42)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//engine m s
                {
                    nametouse = "Engine Room (Murray + Sly)";
                    list.Add("Entrance");
                    list.Add("Control Room");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                }
            }
            else if (id == 43)
            {
                if (CurrentBuild.StartsWith("Sly 2"))//paris wreckage
                {
                    nametouse = "Paris (Clock-la)";
                    list.Add("Spawn (Sky)");
                    list.Add("Clock-la (Sky)");
                    list.Add("Ground Level");
                    list.Add("Destroyed Walkway");
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                }
            }

            list.Sort();    //alphabetical
            cb_warps.Invoke((MethodInvoker)delegate
            {
                foreach (string s in list) cb_warps.Items.Add(s);
            });
            DelegateThisShit(label_curlev, nametouse);
        }

        private void btn_warp_Click(object sender, EventArgs e)
        {
            string txt = cb_warps.Text;
            if (txt != "")
            {
                UInt64 mapid = GetGlobalValue(GlobalAddresses.LevelID);
                float x = 0, y = 0, z = 0;
                if (CurrentBuild.StartsWith("Sly 2"))
                {
                    if (mapid == 0) //cairo
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Spawn":
                                x = 4910; y = -5210; z = 580; break;
                            case "Balcony 1":
                                x = 11560; y = -1050; z = 1110; break;
                            case "Balcony 2":
                                x = -12870; y = 15500; z = 1370; break;
                            case "Murray Rendezvous":
                                x = 18790; y = 80; z = 1500; break;
                            case "Warehouse":
                                x = 12500; y = 5790; z = 1600; break;
                            case "Chase Start":
                                x = 10000; y = 8150; z = 1860; break;
                            case "Pickup Point":
                                x = -26400; y = 4350; z = 80; break;
                        }
                    }
                    else if (mapid == 2) //paris hub
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
                            case "Drain Pipe (Basement Entrance)":
                                x = 14150; y = 2160; z = 780; break;
                            case "Drawbridge Control":
                                x = 200; y = 1980; z = 960; break;
                        }
                    }
                    else if (mapid == 9) //india 1 guesthouse
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -80; y = 1800; z = -780; break;
                            case "Room 101":
                                x = -6400; y = -1700; z = 100; break;
                            case "Room 102":
                                x = -3300; y = 120; z = -170; break;
                            case "Room 103":
                                x = -110; y = -1540; z = -480; break;
                            case "Room 104":
                                x = 3320; y = 50; z = -170; break;
                            case "Room 105":
                                x = 6540; y = -1880; z = 110; break;
                        }
                    }
                    else if (mapid == 10) //palace basement
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 2470; y = -1850; z = 40; break;
                            case "Vault":
                                x = 2640; y = 0; z = 390; break;
                            case "Boardroom":
                                x = 1360; y = 0; z = 1170; break;
                        }
                    }
                    else if (mapid == 11) //ballroom
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 1160; y = 5380; z = 910; break;
                            case "Dance Floor":
                                x = 1460; y = 2600; z = 70; break;
                            case "Guests (Left)":
                                x = 3200; y = -1000; z = 1400; break;
                            case "Guests (Right)":
                                x = -500; y = -800; z = 1400; break;
                        }
                    }
                    else if (mapid == 12) //india jungle
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -2930; y = -5540; z = 1980; break;
                            case "Safehouse (Top)":
                                x = -2700; y = -5600; z = 3070; break;
                            case "Tilting Temple":
                                x = -9100; y = -1600; z = 2500; break;
                            case "Temple Entrance":
                                x = 0; y = 3400; z = 2040; break;
                            case "Waterfall":
                                x = -9040; y = 7430; z = 0; break;
                            case "Top of Dam":
                                x = 1390; y = 8200; z = 8010; break;
                        }
                    }
                    else if (mapid == 13) //spice fac
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Factory Entrance":
                                x = -10200; y = 9100; z = -30; break;
                            case "Factory Entrance (Top)":
                                x = -10000; y = 9880; z = 1600; break;
                            case "Factory Recon Area":
                                x = -14160; y = 12000; z = 2200; break;
                            case "Spice Grinder":
                                x = -7300; y = -4750; z = -940; break;
                            case "Spice Grinder Entrance":
                                x = -5700; y = 1760; z = -1290; break;
                            case "Rajan's Office":
                                x = 5100; y = 11260; z = 2200; break;
                        }
                    }
                    else if (mapid == 14) //prague 1
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -7100; y = -10500; z = 235; break;
                            case "Safehouse (Top)":
                                x = -7490; y = -11010; z = 1440; break;
                            case "Bridge":
                                x = 6120; y = -5800; z = 730; break;
                            case "Prison (Center)":
                                x = -1430; y = 1120; z = 3690; break;
                            case "Prison (Sly)":
                                x = 1930; y = -4480; z = 1960; break;
                            case "Rooftop 1":
                                x = -9060; y = 310; z = 1295; break;
                            case "Rooftop 2":
                                x = 2370; y = -12450; z = 850; break;
                            case "Weird House":
                                x = 6840; y = -890; z = 1770; break;
                        }
                    }
                    else if (mapid == 15) //prague 1 jail
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 540; y = -4040; z = 500; break;
                            case "Murray's Cell":
                                x = 7700; y = -2100; z = -1130; break;
                            case "Hypno Arena":
                                x = -3660; y = 1950; z = -320; break;
                            case "Control Room":
                                x = 700; y = -1300; z = 250; break;
                        }
                    }
                    else if (mapid == 16) //scuffed vault room
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -280; y = 390; z = 20; break;
                            case "Behind the Wall":
                                x = 1330; y = -1000; z = 490; break;
                        }
                    }
                    else if (mapid == 17) //prague 2
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 11560; y = 2350; z = 800; break;
                            case "Sewer":
                                x = 7980; y = 2270; z = -610; break;
                            case "Graveyard":
                                x = -2150; y = -7300; z = 420; break;
                            case "Castle Top 1":
                                x = -6690; y = -2720; z = 1300; break;
                            case "Castle Top 2":
                                x = -800; y = 4680; z = 2150; break;
                            case "Castle Top 3":
                                x = -3980; y = 1920; z = 4530; break;
                            case "Guillotine":
                                x = -6445; y = 4333; z = 180; break;
                            case "Re-education Tower (Entrance)":
                                x = -1025; y = -4400; z = 3330; break;
                            case "Re-education Tower (Balcony)":
                                x = -175; y = -4485; z = 4900; break;
                        }
                    }
                    else if (mapid == 19) //crypt 3
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -25200; y = -180; z = 75; break;
                            case "End":
                                x = -25220; y = -9320; z = 190; break;
                        }
                    }
                    else if (mapid == 20) //crypt 1n2
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance (Crypt 1)":
                                x = -16570; y = -11490; z = -380; break;
                            case "Vault (Crypt 1)":
                                x = -12270; y = -11550; z = -210; break;
                            case "Entrance (Crypt 2)":
                                x = -14750; y = 560; z = 540; break;
                            case "End (Crypt 2)":
                                x = -19480; y = 5450; z = 1180; break;
                        }
                    }
                    else if (mapid == 21) //crypt ghost cap
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 3530; y = -11640; z = -380; break;
                            case "Tomb":
                                x = 3040; y = -6300; z = -1180; break;
                        }
                    }
                    else if (mapid == 22) //re edu
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance (Re-education Tower)":
                                x = -16020; y = -11490; z = -40; break;
                            case "Re-education Cell":
                                x = -14300; y = -11720; z = -340; break;
                            case "Entrance (Hack)":
                                x = -6690; y = -4700; z = 470; break;
                            case "End (Hack)":
                                x = -1000; y = 8300; z = -380; break;
                            case "Unused Area 1":
                                x = 9050; y = -2630; z = 100; break;
                            case "Unused Area 2":
                                x = 10200; y = -7430; z = -400; break;
                            case "Unused Area 3":
                                x = 13330; y = -7390; z = -380; break;
                        }
                    }
                    else if (mapid == 27) //canada 1
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -1060; y = -11040; z = 30; break;
                            case "Safehouse (Top)":
                                x = -50; y = -10560; z = 1440; break;
                            case "Cabin 1":
                                x = -12220; y = -3630; z = 1960; break;
                            case "Cabin 2":
                                x = -3940; y = 6870; z = 2030; break;
                            case "Cabin 3":
                                x = 5960; y = 6275; z = 890; break;
                            case "Satellite Dish":
                                x = 660; y = 5330; z = 4740; break;
                            case "Plane":
                                x = -1840; y = 9260; z = 20; break;
                        }
                    }
                    else if (mapid == 28) //cabins
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Cabin 1":
                                x = -8820; y = -8470; z = 130; break;
                            case "Cabin 2":
                                x = 8370; y = -8500; z = 130; break;
                            case "Cabin 3":
                                x = 8370; y = 6260; z = 130; break;
                        }
                    }
                    else if (mapid == 29) //train ass
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Back":
                                x = 0; y = -8400; z = 120; break;
                            case "Front":
                                x = 40; y = 21300; z = 120; break;
                        }
                    }
                    else if (mapid == 30) //train op
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Back":
                                x = 0; y = -8400; z = 120; break;
                            case "Front":
                                x = 0; y = 25100; z = 120; break;
                            case "Jean Bison":
                                x = 0; y = 2380; z = 120; break;
                        }
                    }
                    else if (mapid == 31) //train iron horse
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Back":
                                x = 0; y = -8400; z = 120; break;
                            case "Front":
                                x = 0; y = 25100; z = 120; break;
                        }
                    }
                    else if (mapid == 32) //canada 2
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 2290; y = -3380; z = 560; break;
                            case "Van":
                                x = 8420; y = -970; z = -810; break;
                            case "Sawmill 1":
                                x = 520; y = 7270; z = 1825; break;
                            case "Sawmill 2":
                                x = -5140; y = 7200; z = 1470; break;
                            case "Sawmill 3 / RC Combat Club":
                                x = -5700; y = -6390; z = 1480; break;
                            case "Bomb Fishing Spot":
                                x = -4670; y = -1190; z = 920; break;
                            case "Battery Silo":
                                x = -9480; y = -3050; z = 1490; break;
                            case "Lighthouse":
                                x = -12750; y = -3500; z = -330; break;
                            case "Lighthouse (Top)":
                                x = -13700; y = -3850; z = 4060; break;
                        }
                    }
                    else if (mapid == 33) //rc combat
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Moose Head":
                                x = 19390; y = -1080; z = 1720; break;
                            case "Sawblade Crawl":
                                x = 22040; y = -2520; z = 1470; break;
                        }
                    }
                    else if (mapid == 34) //sawmill
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Vault":
                                x = 760; y = 20930; z = 880; break;
                            case "Lasers":
                                x = -268; y = 20348; z = 1828; break;
                            case "Lever":
                                x = 690; y = 22320; z = 1190; break;
                        }
                    }
                    else if (mapid == 35) //lighthouse
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Top Entrance":
                                x = -290; y = 375; z = 5845; break;
                            case "Bottom":
                                x = 0; y = 0; z = 960; break;
                            case "Recon":
                                x = 680; y = 1060; z = 1015; break;
                        }
                    }
                    else if (mapid == 36) //bear
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -2525; y = 2960; z = 30; break;
                            case "Large Ice Wall":
                                x = 1000; y = 5255; z = 165; break;
                        }
                    }
                    else if (mapid == 37) //sawmill boss
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Arena":
                                x =1140; y = -520; z = 75; break;
                            case "Control Room":
                                x = 620; y = 840; z = 1800; break;
                        }
                    }
                    else if (mapid == 38) //blimp
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 11400; y = -25; z = 960; break;
                            case "Safehouse (Top)":
                                x = 10840; y = -485; z = 3100; break;
                            case "Balloon 1":
                                x = 6540; y = -2710; z = 2360; break;
                            case "Balloon 2":
                                x = 6480; y = 2690; z = 2360; break;
                            case "Engine 1":
                                x = -10220; y = 4055; z = 3960; break;
                            case "Engine 2":
                                x = -10270; y = -4060; z = 3960; break;
                            case "Center":
                                x = 0; y = 0; z = 2810; break;
                        }
                    }
                    else if (mapid == 39) //blimp hq
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -3890; y = 0; z = 730; break;
                            case "Clockwerk":
                                x = 135; y = 0; z = 360; break;
                            case "Neyla":
                                x = 5160; y = 0; z = 100; break;
                            case "Center":
                                x = 0; y = 0; z = -670; break;
                        }
                    }
                    else if (mapid == 40) //engine room
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -2190; y = 130; z = 10; break;
                            case "Control Room":
                                x = -2250; y = -20; z = 710; break;
                        }
                    }
                    else if (mapid == 41) //engine room
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -2140; y = 140; z = 10; break;
                            case "Control Room":
                                x = -2250; y = -20; z = 710; break;
                        }
                    }
                    else if (mapid == 42) //engine room
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -2110; y = 430; z = 10; break;
                            case "Control Room":
                                x = -2250; y = -85; z = 710; break;
                        }
                    }
                    else if (mapid == 43) //paris wreckage
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Spawn (Sky)":
                                x = -12560; y = 580; z = 86720; break;
                            case "Clock-la (Sky)":
                                x = 22803; y = -1340; z = 76170; break;
                            case "Ground Level":
                                x = -100; y = -666; z = -130; break;
                            case "Destroyed Walkway":
                                x = 920; y = -7480; z = 1580; break;
                        }
                    }
                }
                else if (CurrentBuild.StartsWith("Sly 3"))
                {
                    if (mapid == 2)  //hazard
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Center":
                                x = 3550; y = 440; z = 100; break;
                            case "Top":
                                x = 3580; y = 630; z = 3440; break;
                            case "Safehouse":
                                x = 6640; y = 680; z = 90; break;
                        }
                    }
                    else if (mapid == 3)  //venice
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 200; y = -2090; z = 173; break;
                            case "Safehouse (Top)":
                                x = 863; y = -1420; z = 1266; break;
                            case "Police HQ":
                                x = -7570; y = 1670; z = 1962; break;
                            case "Ferris Wheel":
                                x = 6900; y = 1480; z = 160; break;
                            case "Stage":
                                x = 6250; y = 8210; z = 260; break;
                            case "Fountain":
                                x = -6670; y = 8550; z = 700; break;
                            case "Aquarium":
                                x = 8040; y = -4365; z = 160; break;
                        }
                    }
                    else if (mapid == 4)  //canals
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Boat":
                                x = 0; y = 0; z = 130; break;
                            case "Intersection 1":
                                x = 665; y = -12555; z = 140; break;
                            case "Intersection 2":
                                x = 27250; y = 28580; z = 140; break;
                        }
                    }
                    else if (mapid == 5)  //coffee
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance 1":
                                x = 710; y = -5000; z = 125; break;
                            case "Entrance 2":
                                x = 1070; y = 100; z = 125; break;
                            case "Entrance 3":
                                x = 1160; y = 5000; z = 125; break;
                            case "Safe 1":
                                x = -1710; y = -4990; z = 125; break;
                            case "Safe 2":
                                x = -1750; y = 10; z = 125; break;
                            case "Safe 3":
                                x = -3245; y = 4990; z = 125; break;
                            case "'Roof'":
                                x = -1780; y = -4540; z = 1175; break;
                        }
                    }
                    else if (mapid == 6)  //opera gauntlet
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Main Entrance":
                                x = -7130; y = -11340; z = 1030; break;
                            case "Basement Entrance":
                                x = 14440; y = -4000; z = 1015; break;
                            case "Pump Room":
                                x = -885; y = -2230; z = 180; break;
                            case "Worlitzer-700":
                                x = -2100; y = 4890; z = 630; break;
                            case "Underground Canal":
                                x = 8720; y = -6490; z = 75; break;
                            case "Overlook":
                                x = 8770; y = -5830; z = 1650; break;
                        }
                    }
                    else if (mapid == 7)  //police hq
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Dimitri's Cell":
                                x = -60; y = 7600; z = 120; break;
                            case "Cell Key":
                                x = -685; y = 3250; z = 125; break;
                        }
                    }
                    else if (mapid == 8) //aus
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
                            case "Guru's Hut":
                                x = -8230; y = 4365; z = 2760; break;
                            case "Guru's Cell":
                                x = 8665; y = 5620; z = 2820; break;
                            case "Treeline":
                                x = -8360; y = -3400; z = 5060; break;
                            case "Plateau":
                                x = 6360; y = 7645; z = 6930; break;
                        }
                    }
                    else if (mapid == 9) //ayers
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Drill Controls":
                                x = 270; y = 160; z = 240; break;
                            case "Drill Controls (Top)":
                                x = 420; y = 15; z = 2190; break;
                            case "Truck Spawn":
                                x = -16350; y = 8310; z = 4230; break;
                            case "Mine Entrance":
                                x = 3830; y = 13920; z = 70; break;
                            case "Clifftop":
                                x = 16260; y = 12890; z = 12660; break;
                        }
                    }
                    else if (mapid == 10) //oilfield
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "The Claw":
                                x = 320; y = 10000; z = 70; break;
                            case "Catapult":
                                x = 4820; y = -4470; z = 70; break;
                            case "Drill Platform":
                                x = -360; y = 620; z = 1235; break;
                        }
                    }
                    else if (mapid == 11) //cave moonst
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -9345; y = 330; z = 20; break;
                            case "Safe":
                                x = 6545; y = 125; z = 1111; break;
                            case "Drills":
                                x = -780; y = -3420; z = 1120; break;
                        }
                    }
                    else if (mapid == 12) //cave staff
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -8945; y = 370; z = -1860; break;
                            case "Safe":
                                x = -100; y = -4960; z = -610; break;
                            case "Hook Conveyor Belt":
                                x = -5970; y = -1800; z = -1335; break;
                        }
                    }
                    else if (mapid == 14) //cave spunky
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -10230; y = -1445; z = -1140; break;
                            case "Piston":
                                x = 3380; y = -1870; z = -1020; break;
                            case "Triple Piston":
                                x = -2300; y = -8000; z = 150; break;
                            case "Drilling Area":
                                x = 200; y = -9200; z = 320; break;
                        }
                    }
                    else if (mapid == 15) //holland hub
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 12180; y = -540; z = 1180; break;
                            case "Baron's Hangar":
                                x = -6075; y = 6950; z = 2855; break;
                            case "Forest":
                                x = -2770; y = 3020; z = 430; break;
                            case "Ramp":
                                x = -4645; y = -9100; z = 1680; break;
                            case "Barn":
                                x = 3680; y = -6000; z = 600; break;
                            case "Well":
                                x = 4330; y = 3490; z = 120; break;
                        }
                    }
                    else if (mapid == 16) //holland hotel
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "'Safehouse Entrance'":
                                x = 2620; y = 280; z = 600; break;
                            case "Ham":
                                x = -535; y = 420; z = 0; break;
                            case "Viking Helmet":
                                x = 830; y = 2950; z = 590; break;
                            case "'Outside'":
                                x = 60; y = -6590; z = -545; break;
                        }
                    }
                    else if (mapid == 19) //hangar cooper
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Center":
                                x = -180; y = -125; z = 75; break;
                            case "Control Room":
                                x = -1890; y = -130; z = 75; break;
                            case "Truck":
                                x = -340; y = 2220; z = 1030; break;
                        }
                    }
                    else if (mapid == 20) //sewer
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = 20150; y = -9850; z = 210; break;
                            case "Iceland Hotel Path":
                                x = 16490; y = 7280; z = 210; break;
                            case "Exit to Surface":
                                x = 7960; y = -12750; z = 210; break;
                            case "Iceland Hotel Entrance":
                                x = 7425; y = 9500; z = 210; break;
                        }
                    }
                    else if (mapid == 21) //biplane
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Barn":
                                x = -1890; y = 380; z = 870; break;
                            case "Crop Squares":
                                x = 17800; y = 3210; z = 900; break;
                            case "Bridge 1":
                                x = -140; y = -14670; z = 620; break;
                            case "Bridge 2":
                                x = -4444; y = 16170; z = 450; break;
                            case "Bridge 3":
                                x = 10460; y = 13260; z = 500; break;
                            case "Boss Arena":
                                x = 251764; y = -186; z = 0; break;
                        }
                    }
                    else if (mapid == 23) //china
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = -5440; y = -7500; z = 2020; break;
                            case "Turret Tower":
                                x = -5330; y = -8415; z = 3500; break;
                            case "Walk Across the Heavens":
                                x = 7310; y = -8370; z = 4980; break;
                            case "Graveyard":
                                x = 8570; y = 10150; z = 5840; break;
                            case "Statue":
                                x = 795; y = -2980; z = 1915; break;
                            case "Palace":
                                x = 940; y = 2255; z = 4790; break;
                        }
                    }
                    else if (mapid == 24) //china intr
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Start Platform":
                                x = -2085; y = -54630; z = 850; break;
                            case "Panda King's Perch":
                                x = 400; y = -50485; z = 1888; break;
                            case "House":
                                x = 3470; y = -51845; z = 820; break;
                            case "Clifftop":
                                x = -2820; y = -57675; z = 5420; break;
                        }
                    }
                    else if (mapid == 26) //bamboo
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance Platform":
                                x = -50; y = 3060; z = 840; break;
                            case "Ground Level":
                                x = 130; y = 30410; z = -50; break;
                            case "Overlook":
                                x = -4545; y = 35970; z = 4675; break;
                        }
                    }
                    else if (mapid == 27) //panda apt
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Yang":
                                x = -240; y = -100; z = 19995; break;
                            case "Yin":
                                x = -1855; y = -100; z = 19995; break;
                        }
                    }
                    else if (mapid == 28) //grapple
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Laser Wall":
                                x = -2930; y = 0; z = -50; break;
                            case "Second Floor":
                                x = 1050; y = 1580; z = 645; break;
                            case "Computer":
                                x = 1075; y = -1515; z = 645; break;
                            case "'Outside'":
                                x = -4210; y = -140; z = -185; break;
                            case "Overlook":
                                x = -10480; y = -4100; z = 2760; break;
                        }
                    }
                    else if (mapid == 29) //palace
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Vases":
                                x = -5270; y = -60; z = -190; break;
                            case "Computer":
                                x = -2250; y = 1445; z = 0; break;
                            case "Jing King's Room":
                                x = 470; y = -1500; z = 0; break;
                            case "Drill Site":
                                x = 2075; y = 15000; z = 545; break;
                        }
                    }
                    else if (mapid == 30) //treasure temple
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Entrance":
                                x = -6300; y = -130; z = 330; break;
                            case "Treasure Area":
                                x = 1725; y = 730; z = -330; break;
                            case "Crawlspace":
                                x = -560; y = 140; z = 1640; break;
                        }
                    }
                    else if (mapid == 31) //pirate hub
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Safehouse":
                                x = 4900; y = 1345; z = 1125; break;
                            case "Safehouse (Top)":
                                x = 5590; y = 2310; z = 2680; break;
                            case "Skull Keep (Top)":
                                x = -9600; y = -1880; z = 4410; break;
                            case "Waterfall (Top)":
                                x = 3625; y = 16360; z = 4435; break;
                            case "Fireplace":
                                x = -530; y = 7030; z = 1970; break;
                            case "Monkeys?":
                                x = -7415; y = 11565; z = 1520; break;
                            case "Cooper Gang Ship":
                                x = 11390; y = -9290; z = 1550; break;
                            case "Archipelago":
                                x = -26550; y = -19930; z = 2100; break;
                        }
                    }
                    else if (mapid == 33) //underwater
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Spawn":
                                x = 28980; y = -100; z = 2600; break;
                            case "Ship (Top)":
                                x = 21020; y = 14180; z = 6030; break;
                            case "Shipwreck":
                                x = 22460; y = 12380; z = -3480; break;
                            case "Depths":
                                x = 21910; y = 8690; z = -7285; break;
                            case "Ocean Current":
                                x = 20860; y = 22410; z = -7120; break;
                        }
                    }
                    else if (mapid == 34) //dagger
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Cooper Gang Ship":
                                x = -16760; y = 2940; z = 1000; break;
                            case "Palm Tree Circle":
                                x = -8040; y = -970; z = 1100; break;
                            case "Flipped Ship":
                                x = 1620; y = -5250; z = 1140; break;
                            case "Pirate Ship":
                                x = 15680; y = 5290; z = 770; break;
                            case "Mountain Peak":
                                x = 2215; y = 10860; z = 7940; break;
                        }
                    }
                    else if (mapid == 35) //kaine
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Spawn":
                                x = -6715; y = -14380; z = -2900; break;
                            case "Wall Sneak (Top)":
                                x = -6285; y = -2220; z = -2180; break;
                            case "Ventilation Shaft":
                                x = -1870; y = 4765; z = -3855; break;
                            case "Vault Entrance":
                                x = -1085; y = -100; z = 2360; break;
                            case "Ship Dock":
                                x = 7855; y = -24360; z = -3770; break;
                            case "RC Car Track":
                                x = -13650; y = -14110; z = -2190; break;
                            case "Random Rope":
                                x = -16480; y = 1520; z = -2830; break;
                            case "Rock Formation":
                                x = 13730; y = 20650; z = 2100; break;
                        }
                    }
                    else if (mapid == 36) //underwater
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Spawn":
                                x = 51570; y = 23850; z = -5745; break;
                            case "Water Tube":
                                x = 745; y = -34265; z = -820; break;
                            case "Boss Area":
                                x = 10200; y = -59780; z = -550; break;
                        }
                    }
                    else if (mapid == 37) //vault entrance
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Center":
                                x = 0; y = 0; z = 40; break;
                            case "Entrance Door":
                                x = 4350; y = -45; z = 460; break;
                        }
                    }
                    else if (mapid == 38) //vault gauntlet
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Slytunkhamen II":
                                x = -28690; y = 21665; z = -2175; break;
                            case "Sir Galleth Cooper":
                                x = -24715; y = 13995; z = -2260; break;
                            case "Salim Al-Kupar":
                                x = -13760; y = 12485; z = -2200; break;
                            case "Slaigh MacCooper":
                                x = -15325; y = 24680; z = -2190; break;
                            case "Rioichi Cooper":
                                x = -21130; y = 19955; z = -180; break;
                            case "Henriette Cooper":
                                x = -10530; y = 13200; z = 120; break;
                            case "Tennesee 'Kid' Cooper":
                                x = 2010; y = 13275; z = -2280; break;
                            case "Thaddeus Winslow Cooper III":
                                x = 9360; y = 1820; z = -2185; break;
                            case "Otto Van Cooper":
                                x = -2050; y = 2740; z = 0; break;
                            case "Conner Cooper":
                                x = 7515; y = 5030; z = 150; break;
                            case "Inner Sanctum Entrance":
                                x = 16645; y = -2260; z = 120; break;
                        }
                    }
                    else if (mapid == 39) //inner sanctum
                    {
                        switch (txt)
                        {
                            default:
                                break;
                            case "Center":
                                x = 0; y = 0; z = 30; break;
                            case "Top Platform":
                                x = -3840; y = 1600; z = 2970; break;
                        }
                    }
                }

                WarpSelectedCharacter(x, y, z + 300);

            }
            else //if empty
            {
                MessageBox.Show("You need to select a warp location to warp.", "Bruh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cb_character_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = cb_character.Text;
            string b = GetBuildName();
            if (sel == "Active")
            {
                if (b == BuildNames.Sly2NTSC)
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
            if (cb_loadlvl.Text != "")
            {
                SetGlobalValue(GlobalAddresses.ActChar, type: "int", towrite: GetCharacterIdFromName(LoadToLevelAs).ToString());
                m.WriteBytes((BaseAddress + GlobalAddresses.CurrentLevelAOB).ToString("X"), LevelAOBs[cb_loadlvl.SelectedIndex]);
                SetGlobalValue(GlobalAddresses.Reload, "int", "1");
                while (true)
                {
                    SetGlobalValue(GlobalAddresses.ActChar, type: "int", towrite: GetCharacterIdFromName(LoadToLevelAs).ToString());
                    if(GetGlobalValue(GlobalAddresses.Loading) == 3)
                    {
                        break;
                    }
                }
                
            }
            else //if empty
            {
                MessageBox.Show("You need to select a map to load a map.", "Bruh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        int GetCharacterIdFromName(string charactername)
        {
            if(CurrentBuild.StartsWith("Sly 2"))
            {
                switch (charactername)
                {
                    default:
                        break;
                    case CharacterNames.Sly:
                        return 7;
                    case CharacterNames.Bentley:
                        return 8;
                    case CharacterNames.Murray:
                        return 9;
                }
                return 7; //fallback to sly if not specified
            }
            else if (CurrentBuild.StartsWith("Sly 3"))
            {
                switch (charactername)
                {
                    default:
                        break;
                    case CharacterNames.Sly:
                        return 24;
                    case CharacterNames.Bentley:
                        return 25;
                    case CharacterNames.Murray:
                        return 26;
                    case CharacterNames.Guru:
                        return 29;
                    case CharacterNames.PandaKing:
                        return 30;
                    case CharacterNames.Penelope:
                        return 31;
                }
                return 24; //fallback to sly if not specified
            }
            return 0;
        }

        private void cb_fun_lanky_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_fun_lanky.Checked)
            {
                m.FreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness).ToString("X"), "float", "0.4");

                m.FreezeValue((BaseAddress + CharStructPtrs.Sly).ToString("X") +
                "," + (BaseAddress + EntityStruct.TransformComponent).ToString("X") +
                "," + (BaseAddress + Funs.Lankyness + 0x14).ToString("X"), "float", "0.4");

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
            m.WriteMemory((BaseAddress + GlobalAddresses.UnlockGadgets).ToString("X"), "int", "-1");
            m.WriteMemory((BaseAddress + GlobalAddresses.UnlockGadgets + 0x4).ToString("X"), "int", "-1");
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

        private void btn_bottle_Click(object sender, EventArgs e)
        {
            BottleSequence();
        }

        private void btn_resetscale_Click(object sender, EventArgs e)
        {
            SetActiveCharacterData(offset: EntityStruct.TransformComponent, offset2: TransformComponent.Scale, setTo: "1", vec3: true, writeType: "float");
            tbar_scale.Value = 10;
        }

        private void btn_resetcam_Click(object sender, EventArgs e)
        {
            SetGlobalValue(GlobalAddresses.ResetCamera, "int", "1");
        }

        private void tbar_camspeed_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)tbar_camspeed.Value / 10;
            Console.WriteLine(val.ToString("f1"));
            SetGlobalValue(GlobalAddresses.CameraSpeed, "float", val.ToString("f1"), freeze: true);
        }

        private void tbar_rendDist_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)tbar_rendDist.Value / 10;
            Console.WriteLine(val.ToString("f1"));
            SetGlobalValue(GlobalAddresses.DrawDist, "float", val.ToString("f1"), freeze: true);
        }

        private void tbar_fov_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)tbar_fov.Value / 10;
            Console.WriteLine(val.ToString("f1"));
            SetGlobalValue(GlobalAddresses.FOV, "float", val.ToString("f1"), freeze: true);
        }

        private void btn_resetcams_Click(object sender, EventArgs e)
        {
            SetGlobalValue(GlobalAddresses.CameraSpeed, "float", "1");
            SetGlobalValue(GlobalAddresses.DrawDist, "float", "1");
            SetGlobalValue(GlobalAddresses.FOV, "float", "1.1");
        }

        private void btn_randmap_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int rval = r.Next(cb_loadlvl.Items.Count);

            m.WriteBytes((BaseAddress + GlobalAddresses.CurrentLevelAOB).ToString("X"), LevelAOBs[rval]);
            SetGlobalValue(GlobalAddresses.Reload, "int", "1");
        }

        private void cb_loadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_loadas.Text != "")
            {
                LoadToLevelAs = cb_loadas.Text;
            }
        }

        private void tbar_clock_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)tbar_clock.Value / 10;
            Console.WriteLine(val.ToString("f1"));
            SetGlobalValue(GlobalAddresses.Clock, "float", val.ToString("f1"), freeze: true);
        }

        

        public async void GetEntityList()
        {
            list_npcs.Invoke((MethodInvoker)delegate
            {
                list_npcs.Items.Clear();
            });
            bool cleanup = false;
            cb_onlynpc.Invoke((MethodInvoker)delegate
            {
                cleanup = cb_onlynpc.Checked;
            });

            IEnumerable<long> results = await m.AoBScan((long)BaseAddress, ((long)BaseAddress+0x2000000), "46 4B 24 58", true, true);

            foreach (long res in results)
            {
                bool bad = false;
                string listitem = ("> [" + res.ToString("X") + "] >> ") + m.ReadString(res.ToString("X")) + " << First = [" +
                (BaseAddress + m.ReadUInt((res - 0x18).ToString("X"))).ToString("X") + "].";
                listitem = listitem.Replace("FK$X", "");
                
                if(cleanup)
                {
                    bad = true;

                    if (listitem.Contains("swarmer")) bad = false;
                    else if (listitem.Contains("penelope")) bad = false;
                    else if (listitem.Contains("npc")) bad = false;
                    else if (listitem.Contains("jt")) bad = false;
                    else if (listitem.Contains("dmitri")) bad = false;
                    else if (listitem.Contains("dimitri")) bad = false;
                    else if (listitem.Contains("guard")) bad = false;
                    else if (listitem.Contains("fwee")) bad = false;
                    else if (listitem.Contains("doc")) bad = false;
                    else if (listitem.Contains("carmelita")) bad = false;
                    else if (listitem.Contains("shaman")) bad = false;
                    else if (listitem.Contains("bentley")) bad = false;
                    else if (listitem.Contains("murray")) bad = false;
                    /*if (listitem.Contains("m_")) bad = true;
                    else if (listitem.Contains("explode_")) bad = true;
                    else if (listitem.Contains("pe_")) bad = true;
                    else if (listitem.Contains("psys_")) bad = true;
                    else if (listitem.Contains("xps_")) bad = true;
                    else if (listitem.Contains("o_")) bad = true;
                    else if (listitem.Contains("laser")) bad = true;
                    else if (listitem.Contains("coin")) bad = true;
                    else if (listitem.Contains("c_")) bad = true;
                    else if (listitem.Contains("adjust")) bad = true;
                    else if (listitem.Contains("abandon")) bad = true;
                    else if (listitem.Contains("item")) bad = true;
                    else if (listitem.Contains("dirt")) bad = true;
                    else if (listitem.Contains("ammo")) bad = true;
                    else if (listitem.Contains("explosion")) bad = true;
                    else if (listitem.Contains("mug")) bad = true;
                    else if (listitem.Contains("goal")) bad = true;
                    else if (listitem.Contains("glow")) bad = true;
                    else if (listitem.Contains("medicine")) bad = true;
                    else if (listitem.Contains("booty")) bad = true;
                    else if (listitem.Contains("stock")) bad = true;
                    else if (listitem.Contains("dart")) bad = true;
                    else if (listitem.Contains("mine")) bad = true;
                    else if (listitem.Contains("webcam")) bad = true;
                    else if (listitem.Contains("splash")) bad = true;
                    else if (listitem.Contains("dazed")) bad = true;
                    else if (listitem.Contains("crate")) bad = true;
                    else if (listitem.Contains("mission")) bad = true;
                    else if (listitem.Contains("ball")) bad = true;
                    else if (listitem.Contains("trap")) bad = true;
                    else if (listitem.Contains("rig")) bad = true;
                    else if (listitem.Contains("glint")) bad = true;
                    else if (listitem.Contains("bullet")) bad = true;
                    else if (listitem.Contains("compass")) bad = true;
                    else if (listitem.Contains("stomp")) bad = true;
                    else if (listitem.Contains("m_")) bad = true;
                    else if (listitem.Contains("v_")) bad = true;
                    else if (listitem.Contains("h_")) bad = true;
                    else if (listitem.Contains("c_") && !listitem.Contains("npc")) bad = true;
                    else if (listitem.Contains("p_")) bad = true;
                    else if (listitem.Contains("torso")) bad = true;
                    else if (listitem.Contains("missile")) bad = true;
                    else if (listitem.Contains("target")) bad = true;
                    else if (listitem.Contains("bouncer")) bad = true;
                    else if (listitem.Contains("standard")) bad = true;
                    else if (listitem.Contains("vault")) bad = true;
                    else if (listitem.Contains("barrel")) bad = true;*/
                }


                if (!bad)
                {
                    list_npcs.Invoke((MethodInvoker)delegate
                    {
                        list_npcs.Items.Add(listitem);
                    });
                }
            }
            
        }

        

        string GetStringBetween(string input, string from, string to)
        {
            string final = "";
            int pos1 = input.IndexOf(from) + from.Length;
            int pos2 = input.IndexOf(to);

            final = input.Substring(pos1, pos2 - pos1);
            return final;
        }

        private void cb_onlynpc_CheckedChanged(object sender, EventArgs e)
        {
            GetEntityList();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 3 && GetGlobalValue(GlobalAddresses.Loading) == 3)
            {
                GetEntityList();
            }
        }

        private void cb_guardai_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_guardai.Checked)
            {
                SetGlobalValue(GlobalAddresses.GuardAI, "int", "0", freeze: false);
                return;
            }
            SetGlobalValue(GlobalAddresses.GuardAI, "int", "1", freeze: true);
        }

        private void list_npcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(list_npcs.Text != "")
            {
                string address = GetStringBetween(list_npcs.Text, "> [", "] >> ");
                DialogResult dres = MessageBox.Show("Inspect additional info about this address?", "Inspect " + address + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(dres == DialogResult.Yes)
                {
                    string listptr = GetStringBetween(list_npcs.Text, "= [", "].");
                    string entname = m.ReadString(address);
                    entname = entname.Replace("FK$X", "");
                    entname = entname.Replace("_", " ");
                    if(listptr == BaseAddress.ToString("X"))
                    {
                        DialogResult dres2 = MessageBox.Show("Faulty list pointer, continue anyway?", "Faulty list pointer!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if(dres2 == DialogResult.No)
                        {
                            return;
                        }
                    }
                    MessageBox.Show("FK$X Starts at: " + address + ".\n" + listptr + " points to the list of '" + entname + "(s)' (First struct in list)."
                    + "\n\nNot all of the FK$X's work the same way so the list pointer might be faulty.", "Entity Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void BottleSequence()
        {
            List<float> positions = new List<float>();
            positions.Clear();
            UInt64 offsetmod = 0x0;

            UInt64 bottleoffset = 0x110;

            for (UInt64 i = 0; i <= 30; i++)
            {
                float x, y, z;
                offsetmod = i * bottleoffset;

                x = m.ReadFloat((BaseAddress + MiscPtrs.ClueSpawns).ToString("X") + "," + (BaseAddress + MiscPtrs.FirstClue + offsetmod).ToString("X"));
                y = m.ReadFloat((BaseAddress + MiscPtrs.ClueSpawns).ToString("X") + "," + (BaseAddress + MiscPtrs.FirstClue + offsetmod + 0x4).ToString("X"));
                z = m.ReadFloat((BaseAddress + MiscPtrs.ClueSpawns).ToString("X") + "," + (BaseAddress + MiscPtrs.FirstClue + offsetmod + 0x8).ToString("X"));

                positions.Add(x); positions.Add(y); positions.Add(z);
            }

            int listOffset = 0;
            while (true)
            {
                float x, y, z;
                x = positions[listOffset];
                y = positions[listOffset + 1];
                z = positions[listOffset + 2];

                WarpSelectedCharacter(x, y, z);

                listOffset += 3;

                if (listOffset > 90)
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }
        
    }
}
