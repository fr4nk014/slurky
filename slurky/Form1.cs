using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace slurky
{
    public partial class SlurkyTrainer : Form
    {
        public SlurkyTrainer()
        {
            InitializeComponent();


        }
        
        static Mem m = new Mem();
        public static long emuBase;
        
        private void SlurkyTrainer_Load(object sender, EventArgs e)
        {
            if(!bgworker.IsBusy) bgworker.RunWorkerAsync();
        }


        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            string tempPhrog = GetPhrogName();              //  phrog = process 
            int pID = m.GetProcIdFromName(tempPhrog);       //  get process ID
            bool openProc = false;                          //  is process running?

            if (pID > 0)
            {
                openProc = m.OpenProcess(pID);
            }

            if (openProc)FindEmuBase();

        }

        public static async void FindEmuBase()
        {
            IEnumerable<long> AOBResults = await m.AoBScan(0x0, 0xFFFFFFFFFFFF,
            "01 80 1A 3C ?? ?? 59 FF 00 68 19 40 01 80 1A 3C 7C 00 39 33 21 D0 59 03 ?? ?? ?? 8F 01 80 19 3C 08 00 40 03 ?? ?? 39 DF 00 00 00 00", true, false);

            long firstAOB = AOBResults.FirstOrDefault();
            
            if(firstAOB != 0)
            {
                long tempResult = firstAOB - 0x2396EF0;     //  subtracting Luminar's EE AOB that is also found in GS
                emuBase = tempResult;
                Console.WriteLine("found base address " + tempResult.ToString("X"));
            }
            else
            {
                Console.WriteLine("no base");
            }
            
        }

        public static string GetPhrogName()     //  phrog = process
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if(p.ProcessName.StartsWith("pcsx2"))
                {
                    Console.WriteLine(p.ProcessName);
                    return p.ProcessName;
                }
            }
            return null;
        }

    }
}
