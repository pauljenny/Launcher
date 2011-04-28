using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace LauncherShyax
{
    public partial class Launcher : Form
    {
        public bool isAllowedToDeleteCache
        {
            get { return checkBoxCache.Checked; }
            set { checkBoxCache.Checked = value; }
        }

        public const string ipAddress = "127.0.0.1";
        public const int realmPort = 3724;
        public const int worldPort = 8085;

        public bool wowFound;
        private string _wowDir;
        public Launcher()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FindWoWDir();
            VerifyVersion();
            VerifyStatus();
            ChangeRealmlist();
            labelStatut.Text = "En attente de l'utilisateur...";
        }

        private void FindWoWDir()
        {
            labelStatut.Text = "Recherche du répertoire d'installation de World Of Warcraft...";
            // Look Locally before in registry
            _wowDir = Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location);
            const string wowExe = "Wow.exe";
            FileInfo wowInfo = new FileInfo(Path.Combine(_wowDir, wowExe));
            if (wowInfo.Exists)
            {
                wowFound = true;
                return;
            }
            else
            {
                // Look In Registry
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                if (key == null)
                {
                    labelStatut.Text = "World Of Warcraft non trouvé. Raison : Clé SOFTWARE";
                    return;
                }
                if (Environment.Is64BitProcess)
                {
                    key = key.OpenSubKey("Wow6432Node");
                    if (key == null)
                    {
                        labelStatut.Text = "World Of Warcraft non trouvé. Raison : Clé Wow6432Node";
                        return;
                    }
                }
                key = key.OpenSubKey("Blizzard Entertainment");
                if (key == null)
                {
                    labelStatut.Text = "World Of Warcraft non trouvé. Raison : Clé Blizzard Entertainment";
                    return;
                }
                key = key.OpenSubKey("World of Warcraft");
                if (key == null)
                {
                    labelStatut.Text = "World Of Warcraft non trouvé. Raison : Clé World of Warcraft";
                    return;
                }
                _wowDir = key.GetValue("InstallPath").ToString();
                key.Close();
                wowFound = true;
            }
        }

        private void DeleteCache()
        {
            const string cacheDir = "Cache";
            DirectoryInfo cacheInfo = new DirectoryInfo(Path.Combine(_wowDir, cacheDir));
            if (cacheInfo.Exists)
                cacheInfo.Delete(true);
        }

        private void LaunchGame()
        {
            const string wowExe = "Wow.exe";
            ProcessStartInfo wowStartInfo = new ProcessStartInfo(Path.Combine(_wowDir, wowExe));
            Process.Start(wowStartInfo);
            Close();
        }

        private void VerifyVersion()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("http://"+ ipAddress + "/version.xml");
            }
            catch (Exception e)
            {
                labelStatut.Text = "XML non trouvé !";
                return;
            }
            const string dataDir = "Data";
            DirectoryInfo mpqInfo = new DirectoryInfo(Path.Combine(_wowDir, dataDir));
            FileInfo[] mpqFiles = mpqInfo.GetFiles("patch-*.mpq", SearchOption.TopDirectoryOnly);

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("version");
            XmlNode lastNode = nodeList[0];
            FileInfo lastNodeInfo = new FileInfo(lastNode.InnerText);
            try
            {
                FileInfo contains = mpqFiles.First(fileInfo => fileInfo.Name == lastNode.InnerText);
            }
            catch (Exception e)
            {
                DownloaderBox dlBox = new DownloaderBox();
                dlBox.Show();
                dlBox.Download(nodeList, mpqFiles, Path.Combine(_wowDir, dataDir));
            }
        }

        private void VerifyStatus()
        {
            IPAddress[] address = Dns.GetHostAddresses(ipAddress);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            try
            {
                s.Connect(address[0], realmPort);
            }
            catch (Exception e)
            {
                pictureBoxRealm.Image = LauncherShyax.Properties.Resources.down;
            }
            pictureBoxRealm.Visible = true;
            try
            {
                s.Connect(address[0], worldPort);
            }
            catch (Exception e)
            {
                pictureBoxWorld.Image = LauncherShyax.Properties.Resources.down;
            }
            pictureBoxWorld.Visible = true;
        }

        private void ChangeRealmlist()
        {
            const string dataDir = "Data";
            const string localeDir = "frFR";
            const string realmFile = "realmlist.wtf";
            FileInfo realmList = new FileInfo(Path.Combine(_wowDir, dataDir, localeDir, realmFile));
            if (realmList != null)
            {
                realmList.Delete();                
            }
            FileStream stream = realmList.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(("set realmlist "+ipAddress+":"+worldPort));
            stream.Write(bytes, 0, bytes.Length);
            stream.Dispose();
        }

        private void pictureBoxLancer_Click(object sender, EventArgs e)
        {
            if (isAllowedToDeleteCache)
                DeleteCache();
            LaunchGame();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {
            HelpBox box = new HelpBox();
            box.ShowDialog();
        }
    }
}
