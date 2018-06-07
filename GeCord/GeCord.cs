using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordSharp;


namespace GeCord
{
    public partial class GeCord : Form
    {

        public const string DLL = "discord-rpc-w32.dll";

        private DiscordRpc.RichPresence dcrp;
        private DiscordRpc.EventHandlers dchn;

        string _gfnStatus = "";
        string _discordStatus = "";

        string cliid = "INSERTYOURCLIENTIDHERE";

        string exeGFN = "GeForceNOW";
        string exeGFNStreamer = "GeForceNOWStreamer";

        public GeCord()
        {
            InitializeComponent();
        }

        private void GeCord_Load(object sender, EventArgs e)
        {
            DiscordInit();
            gfnUpdate.Start();

            this.WindowState = FormWindowState.Minimized;

            readyWrapper();
        }

        private void readyWrapper()
        {
            if (!Directory.Exists("wrapper")) Directory.CreateDirectory("wrapper");
            if (!File.Exists("gcw.exe")) File.WriteAllBytes("gcw.exe", Properties.Resources.gcw);
        }

        private void DiscordInit()
        {
            _discordStatus = "Discord - Connecting";
            stDiscord.Text = _discordStatus;

            dchn = new DiscordRpc.EventHandlers();

            dchn.readyCallback = ReadyCallback;
            dchn.errorCallback = ErrorCallback;
            dchn.disconnectedCallback = DisconnectedCallback;

            DiscordRpc.Initialize(cliid, ref dchn, true, null);
            _discordStatus = "Discord - Connected?";
            stDiscord.Text = _discordStatus;

            DiscordRpc.RunCallbacks();

            DiscordRpc.UpdatePresence(ref dcrp);

        }

        private void gfnUpdate_Tick(object sender, EventArgs e)
        {
            //Check if GFN is running
            Process[] gfn = Process.GetProcessesByName(exeGFN);
            Process[] gfnStreamer = Process.GetProcessesByName(exeGFNStreamer);

            if (gfn.Length == 0)
            {
                _gfnStatus = "stopped";
            }
            else
            {
                _gfnStatus = "running";
            }
            string Game = "GG!";
            if (gfnStreamer.Length != 0)
            {
                _gfnStatus = "streaming";
                Game = gfnGame(gfnStreamer);
            }

            //Update UI
            stGFN.Text = "GeForce Now - " + _gfnStatus;

            //Update Dicord State
            if(Game != "GG!") dcrp.details = "Playing " + Game; stGame.Text = Game;
            dcrp.state = _gfnStatus.Replace("running","In Menus").Replace("streaming","In Game").Replace("stopped","In Standby");

            DiscordRpc.UpdatePresence(ref dcrp);

            //Update Wrapper
            string we = "jpgfn" + Game.ToLower() + ".exe";

            if (Game != "GG!" && Game != "Waiting")
            {
                if (!File.Exists("wrapper\\jpgfn" + Game.ToLower() + ".exe")) File.Copy("gcw.exe", "wrapper\\jpgfn" + Game.ToLower() + ".exe");
                Process[] cGame = Process.GetProcessesByName(we.Replace(".exe", ""));
                if (cGame.Length == 0) Process.Start("wrapper\\jpgfn" + Game.ToLower() + ".exe", "\"G\"".Replace("G", Game));
            }

            DirectoryInfo dInfo = new DirectoryInfo("wrapper");
            foreach(var file in dInfo.GetFiles("*.exe"))
            {
                Process[] prc = Process.GetProcessesByName(file.Name.Replace(".exe",""));
                if(file.Name != we && prc.Length != 0) Kill(file.Name);
            }
        }

        private void ReadyCallback()
        {
            _discordStatus = "Discord - Connected";
            stDiscord.Text = _discordStatus;
        }

        private void DisconnectedCallback(int errorCode, string message)
        {
            _discordStatus = "Discord - Disconncted";
            stDiscord.Text = _discordStatus;
        }

        private void ErrorCallback(int errorCode, string message)
        {
            _discordStatus = "Discord - Error";
            stDiscord.Text = _discordStatus;
        }

        public string gfnGame(Process[] processes)
        {
            string[] result = new string[64];
            int c = 0;

            string g = "Waiting";

            foreach(var process in processes)
            {
                if(process.MainWindowTitle.Contains(" on GeForce NOW"))
                {
                    string Gametitle = process.MainWindowTitle.Replace(" on GeForce NOW","");
                    g = Gametitle;
                }
            }


            return g;
        }

        public void Kill(string processName)
        {

            var p = Process.GetProcesses().Where(pr => pr.ProcessName == processName.Replace(".exe",""));

            foreach (var proc in p)
            {
                proc.Kill();
            }

        }

        private void GeCord_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notify.Visible = true;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notify.Visible = false;
            }
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
