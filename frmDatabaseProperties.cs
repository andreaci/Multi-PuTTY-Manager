using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SessionManagement
{
    public partial class frmDatabaseProperties : Form
    {
        public frmDatabaseProperties()
        {
            this.InitializeComponent();
        }

        public frmDatabaseProperties(string databaseID, string databaseName, string location)
        {
            this.InitializeComponent();
            this.txtDatabaseName.Enabled = false;
            this.btOK.Enabled = false;
            this.databaseID = databaseID;
            this.orginalDatabaseName = databaseName;
            this.txtDatabaseName.Text = databaseName;
            this.lbLocation.Text = location;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btRename_Click(object sender, EventArgs e)
        {
            this.txtDatabaseName.Enabled = true;
            this.txtDatabaseName.Focus();
        }

        private void txtDatabaseName_TextChanged(object sender, EventArgs e)
        {
            this.btOK.Enabled = (this.txtDatabaseName.Text != this.orginalDatabaseName && this.txtDatabaseName.Text.Trim() != "");
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.renameDatabase(this.databaseID, this.txtDatabaseName.Text);
            base.Close();
        }

        private void txtDatabaseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.txtDatabaseName.Text != this.orginalDatabaseName && this.txtDatabaseName.Text.Trim() != "")
                {
                    this.renameDatabase(this.databaseID, this.txtDatabaseName.Text);
                    base.Close();
                }
            }
        }

        private readonly string orginalDatabaseName = "";

        private readonly string databaseID = "";

        public frmDatabaseProperties.RenameDatabase renameDatabase;

        public delegate void RenameDatabase(string databaseID, string databaseName);
    }
}
