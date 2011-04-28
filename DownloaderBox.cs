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
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace LauncherShyax
{
    public partial class DownloaderBox : Form
    {
        public DownloaderBox()
        {
            InitializeComponent();
        }

        private void DownloaderBox_Load(object sender, EventArgs e)
        {

        }

        public void Download(XmlNodeList nodeList, FileInfo[] mpqFiles, string wowDir)
        {
            foreach (XmlNode node in nodeList)
            {
                if (!mpqFiles.Contains(new FileInfo(node.InnerText)))
                {
                    // Have to create two WebClient
                    WebClient webClient = new WebClient();
                    WebClient webClient2 = new WebClient();
                    labelDl.Text = "Téléchargement de la mise à jour : " + node.Attributes["nom"].Value;
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient2.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient2_DownloadStringCompleted);
                    webClient2.DownloadStringAsync(new Uri(node.Attributes["desc"].Value));
                    webClient.DownloadFileAsync(new Uri(node.Attributes["lien"].Value), Path.Combine(wowDir, node.InnerText));
                }
            }
            buttonClose.Visible = true;
        }

        void webClient2_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            labelMaj.Text = e.Result;
        }
       
        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDl.Value = (int)(e.BytesReceived*100/e.TotalBytesToReceive);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
