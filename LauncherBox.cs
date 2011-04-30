/* 
 * LauncherShyax, un launcher pour World Of Warcraft avec téléchargement de mise à jour
  Copyright (C) 2011 Shyax — Tous droits réservés.
  
  Ce programme est un logiciel libre ; vous pouvez le redistribuer ou le
  modifier suivant les termes de la “GNU General Public License” telle que
  publiée par la Free Software Foundation : soit la version 3 de cette
  licence, soit (à votre gré) toute version ultérieure.
  
  Ce programme est distribué dans l’espoir qu’il vous sera utile, mais SANS
  AUCUNE GARANTIE : sans même la garantie implicite de COMMERCIALISABILITÉ
  ni d’ADÉQUATION À UN OBJECTIF PARTICULIER. Consultez la Licence Générale
  Publique GNU pour plus de détails.
  
  Vous devriez avoir reçu une copie de la Licence Générale Publique GNU avec
  ce programme ; si ce n’est pas le cas, consultez :
  <http://www.gnu.org/licenses/>.
 * */

using System;
using System.Collections.Generic;
using System.Configuration;
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
        #region Variables
        public bool isAllowedToDeleteCache
        {
            get { return Configuration.Default.IsAllowedToDeleteCache; }
            set { Configuration.Default.IsAllowedToDeleteCache = value; }
        }
        public string hostAddress
        {
            get { return Configuration.Default.HostAddress; }
        }
        public string siteAddress
        {
            get { return Configuration.Default.SiteAddress; }
        }
        public string forumAddress
        {
            get { return Configuration.Default.ForumAddress; }
        }
        public string bugTrackerAddress
        {
            get { return Configuration.Default.BugTrackerAddress; }
        }
        public int realmPort
        {
            get { return Convert.ToInt32(Configuration.Default.RealmServerPort); }
        }
        public int worldPort
        {
            get { return Convert.ToInt32(Configuration.Default.WorldServerPort); }
        }

        public string _wowDir
        {
            get { return Configuration.Default.WoWDirectory; }
            set 
            { 
                Configuration.Default.WoWDirectory = value;
            }
        }
        #endregion

        public Launcher()
        {
            InitializeComponent();
        }

        private void LauncherBox_Load(object sender, EventArgs e)
        {
            FindWoWDir();
            VerifyVersion();
            VerifyStatus();
            ChangeRealmlist();
            AddLinks();
            checkBoxCache.Checked = Configuration.Default.IsAllowedToDeleteCache;
        }

        /// <summary>
        /// Find the game's directory locally (in the directory of the launcher) then in the registry
        /// </summary>
        private void FindWoWDir()
        {
            const string wowExe = "Wow.exe";
            FileInfo wowInfo = new FileInfo(Path.Combine(_wowDir, wowExe));
            if (wowInfo.Exists)
            {
                return;
            }
            else
            {
                // Look Locally before in registry
                _wowDir = Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location);
                FileInfo wowInfo2 = new FileInfo(Path.Combine(_wowDir, wowExe));
                if (wowInfo2.Exists)
                {
                    return;
                }
                else
                {
                    // Look In Registry
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                    if (key == null)
                    {
                        MessageBox.Show("World Of Warcraft non trouvé. Raison : Clé SOFTWARE");
                        return;
                    }
                    if (Environment.Is64BitProcess)
                    {
                        key = key.OpenSubKey("Wow6432Node");
                        if (key == null)
                        {
                            MessageBox.Show("World Of Warcraft non trouvé. Raison : Clé Wow6432Node");
                            return;
                        }
                    }
                    key = key.OpenSubKey("Blizzard Entertainment");
                    if (key == null)
                    {
                        MessageBox.Show("World Of Warcraft non trouvé. Raison : Clé Blizzard Entertainment");
                        return;
                    }
                    key = key.OpenSubKey("World of Warcraft");
                    if (key == null)
                    {
                        MessageBox.Show("World Of Warcraft non trouvé. Raison : Clé World of Warcraft");
                        return;
                    }
                    _wowDir = key.GetValue("InstallPath").ToString();
                    key.Close();
                }
            }
        }

        /// <summary>
        /// Verify if we have the latest version of the server using version.xml
        /// If the file of the latest is not found, DownloaderBox is launched
        /// </summary>
        private void VerifyVersion()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("http://"+ hostAddress + "/version.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show("XML de MAJ non trouvé !");
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
                dlBox.Show(this);
                dlBox.Download(nodeList, mpqFiles, Path.Combine(_wowDir, dataDir));
            }
        }

        /// <summary>
        /// Verify the status of the realm server and the world server using worldPort, realmPort and ipAddress
        /// </summary>
        private void VerifyStatus()
        {
            IPAddress[] address = Dns.GetHostAddresses(hostAddress);

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

        /// <summary>
        /// Create a new realmlist.wtf
        /// </summary>
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
            byte[] bytes = Encoding.UTF8.GetBytes(("set realmlist " + hostAddress + ":" + worldPort));
            stream.Write(bytes, 0, bytes.Length);
            stream.Dispose();
        }

        private void AddLinks()
        {
            linkLabelSite.Links.Add(0, linkLabelSite.Text.Length, siteAddress);
            linkLabelForum.Links.Add(0, linkLabelForum.Text.Length, forumAddress);
            linkLabelBugTracker.Links.Add(0, linkLabelBugTracker.Text.Length, bugTrackerAddress);
        }

        /// <summary>
        /// Delete the Cache/ directory
        /// Call only when isAllowedToDeleteCache is true !
        /// </summary>
        private void DeleteCache()
        {
            const string cacheDir = "Cache";
            DirectoryInfo cacheInfo = new DirectoryInfo(Path.Combine(_wowDir, cacheDir));
            if (cacheInfo.Exists)
                cacheInfo.Delete(true);
        }

        /// <summary>
        /// Launch the game and close the launcher
        /// </summary>
        private void LaunchGame()
        {
            const string wowExe = "Wow.exe";
            ProcessStartInfo wowStartInfo = new ProcessStartInfo(Path.Combine(_wowDir, wowExe));
            Process.Start(wowStartInfo);

            Close();
        }

        #region Events
        private void pictureBoxLancer_Click(object sender, EventArgs e)
        {
            Configuration.Default.IsAllowedToDeleteCache = checkBoxCache.Checked;
            Configuration.Default.Save();
            if (checkBoxCache.Checked)
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

        private void linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelSite.LinkVisited = true;
            Process.Start(siteAddress);
        }

        private void linkLabelForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelForum.LinkVisited = true;
            Process.Start(forumAddress);
        }

        private void linkLabelBugTracker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelBugTracker.LinkVisited = true;
            Process.Start(bugTrackerAddress);
        }
        #endregion
    }
}
