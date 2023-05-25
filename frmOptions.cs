using System;
using System.IO;
using System.Windows.Forms;

namespace SessionManagement
{
    public partial class frmOptions : Form
    {
        SettingsData CurrentApplicationSettings = SettingsData.Instance;

        public frmOptions()
        {
            this.InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtPuttyLocation.Text))
            {
                MessageBox.Show("PuTTY file does not exist!");
                return;
            }

            try
            {
                CurrentApplicationSettings.DefaultDatabaseLocation = this.txtDatabaseLocation.Text;
                CurrentApplicationSettings.PuttyLocation = this.txtPuttyLocation.Text;
                CurrentApplicationSettings.WinSCPLocation = this.txtWinSCPLocation.Text;

                if (this.radLeft.Checked)
                    CurrentApplicationSettings.SessionManagerPosition = "Left";
                else
                    CurrentApplicationSettings.SessionManagerPosition = "Right";

                CurrentApplicationSettings.Save();
                if (this.strCurrentSessionManagerPosition != CurrentApplicationSettings.SessionManagerPosition)
                    this.displaySessionManager();

                base.Close();
            }
            catch//(Exception ex)
            {
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.txtDatabaseLocation.Text = CurrentApplicationSettings.DefaultDatabaseLocation;
            this.txtPuttyLocation.Text = CurrentApplicationSettings.PuttyLocation;
            this.txtWinSCPLocation.Text = CurrentApplicationSettings.WinSCPLocation;

            if (CurrentApplicationSettings.SessionManagerPosition == "Left")
                this.radLeft.Checked = true;
            else
                this.radRight.Checked = true;

            this.strCurrentSessionManagerPosition = CurrentApplicationSettings.SessionManagerPosition;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btDatabaseBrowser_Click(object sender, EventArgs e)
        {
            txtDatabaseLocation.Text = ShowOpenFile("Database Files (*.dat)|*.dat", txtDatabaseLocation.Text);
        }

        private void btPuttyBrowser_Click(object sender, EventArgs e)
        {
            txtPuttyLocation.Text = ShowOpenFile("Putty (putty.exe)|putty.exe|Binaries Files (*.exe)|*.exe|All Files (*.*)|*.*", txtPuttyLocation.Text);
        }

        private void btWinSCPBrowser_Click(object sender, EventArgs e)
        {
            txtWinSCPLocation.Text = ShowOpenFile("WinSCP (winscp.exe)|winscp.exe|Binaries Files (*.exe)|*.exe|All Files (*.*)|*.*", txtWinSCPLocation.Text);
        }

        private String ShowOpenFile(String filter, String fileName)
        {

            OpenFileDialog openFileDialog = new ()
            {
                Filter = filter,
                FilterIndex = 0,
                RestoreDirectory = true,
                FileName = fileName
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;

            return fileName;
        }

        public frmOptions.DisplaySessionManager displaySessionManager;

        private string strCurrentSessionManagerPosition;

        private void btnPuttyDownload_Click(object sender, EventArgs e)
        {
            String destPath = Path.Combine(SettingsData.ProcessPath, $"Putty_{CurrentApplicationSettings.ExecutionArchitecture}.exe");

            try
            {
                HttpHelper.DownloadFileAsync(CurrentApplicationSettings.PuttyDownloadPath, destPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error during download file: {ex.Message}");
                return;
            }

            txtPuttyLocation.Text = destPath;

        }

        public delegate void DisplaySessionManager();
    }
}
