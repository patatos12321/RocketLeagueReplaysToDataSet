using RocketLeagueReplaysToDataSet.Utils;
using System;
using System.Windows.Forms;

namespace RocketLeagueReplaysToDataSet
{
    public partial class frmLaunch : Form
    {
        public frmLaunch()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void BtnReplayFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    TxtReplayFolder.Text = folderBrowser.SelectedPath;
                    SaveConfig();
                }
            }
        }

        private void btnDataSetFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    TxtDataSetFolder.Text = folderBrowser.SelectedPath;
                    SaveConfig();
                }
            }
        }

        private void btnRattletrapPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog pathBrowser = new OpenFileDialog())
            {
                DialogResult result = pathBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(pathBrowser.FileName))
                {
                    txtRattletrapPath.Text = pathBrowser.FileName;
                    SaveConfig();
                }
            }
        }

        private void LoadConfig()
        {
            TxtReplayFolder.Text = Properties.Settings.Default.ReplayFolder;
            TxtDataSetFolder.Text = Properties.Settings.Default.DataSetFolder;
            txtRattletrapPath.Text = Properties.Settings.Default.RattletrapPath;
        }

        private void SaveConfig()
        {
            Properties.Settings.Default.ReplayFolder = TxtReplayFolder.Text;
            Properties.Settings.Default.DataSetFolder = TxtDataSetFolder.Text;
            Properties.Settings.Default.RattletrapPath = txtRattletrapPath.Text;
            Properties.Settings.Default.Save();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            FullConverter.Launch();
        }
    }
}
