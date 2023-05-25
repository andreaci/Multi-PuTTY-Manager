using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SessionManagement
{
	public partial class frmSession : Form
    {
        SettingsData CurrentApplicationSettings = SettingsData.Instance;
        public frmSession()
		{
			this.InitializeComponent();
			this.createPostLoginCommandTextBox();
			SetAllCommands(false);
		}

		private void cmbProtocol_TextChanged(object sender, EventArgs e)
		{
            numPort.Value = CurrentApplicationSettings.Ports[cmbProtocol.Text];
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.sess == null)
				{
					this.sess = new Session();
					if (Global.AvailableSessions == null)
						this.sess.SessionID = 1;
					else
						this.sess.SessionID = Global.AvailableSessions.Count + 1;
				}

				this.sess.SessionName = this.txtName.Text;
				this.sess.SessionHost = this.txtHost.Text;
				this.sess.SessionProtocol = this.cmbProtocol.Text;
				this.sess.SessionPort = int.Parse(this.numPort.Value.ToString());
				this.sess.SessionConfig = this.cmbPuttySession.Text;
				this.sess.SessionDescription = this.richDescription.Text;
				this.sess.SessionCredentials.UserName = this.txtSessionUserName.Text;
				this.sess.SessionCredentials.Password = this.txtSessionPassword.Text;
				this.sess.FTPCredentials.UserName = this.txtFTPUserName.Text;
				this.sess.FTPCredentials.Password = this.txtFTPPassword.Text;
				this.sess.SFTPCredentials.UserName = this.txtSFTPUserName.Text;
				this.sess.SFTPCredentials.Password = this.txtSFTPPassword.Text;
				this.sess.PostLogin = this.checkPostLogin.Checked;
				this.sess.ConnectionTimeout = int.Parse(this.numConnectionTimeout.Value.ToString());
				this.sess.UsernameTimeout = int.Parse(this.numUsernameTimeout.Value.ToString());
				this.sess.PasswordTimeout = int.Parse(this.numPasswordTimeout.Value.ToString());
				this.sess.CommandTimeout = int.Parse(this.numCommandTimeout.Value.ToString());
				this.sess.PostLoginCommands = getPostLoginCommands();

				if (this.cmbPuttySession.Text != CurrentApplicationSettings.CreatePuttySetting)
				{
                    CurrentApplicationSettings.CreatePuttySetting = this.cmbPuttySession.Text;
                    CurrentApplicationSettings.Save();
				}
				this.createOrUpdateSession(this.sess);
				base.Close();
			}
			catch //(Exception ex)
			{
			}
		}

		public void loadExistingSession(Session sess)
		{
			if (sess != null)
				this.sess = sess;
		}

		public void displayExistingValues()
		{
			txtName.Text = sess.SessionName;
			txtHost.Text = sess.SessionHost;
			cmbProtocol.Text = sess.SessionProtocol;
			numPort.Value = sess.SessionPort;
			cmbPuttySession.Text = sess.SessionConfig;
			richDescription.Text = sess.SessionDescription;
			txtSessionUserName.Text = sess.SessionCredentials.UserName;
			txtSessionPassword.Text = sess.SessionCredentials.Password;
			txtFTPUserName.Text = sess.FTPCredentials.UserName;
			txtFTPPassword.Text = sess.FTPCredentials.Password;
			txtSFTPUserName.Text = sess.SFTPCredentials.UserName;
			txtSFTPPassword.Text = sess.SFTPCredentials.Password;
			numConnectionTimeout.Value = sess.ConnectionTimeout;
			numUsernameTimeout.Value = sess.UsernameTimeout;
			numPasswordTimeout.Value = sess.PasswordTimeout;
			numCommandTimeout.Value = sess.CommandTimeout;
			checkPostLogin.Checked = sess.PostLogin;

			SetAllCommands(checkPostLogin.Checked);
			
			
			for (int i = 0; i < sess.PostLoginCommands.Length; i++)
			{
				txtCommands[i].Text = sess.PostLoginCommands[i];
			}
		}

		private void frmSession_Load(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < CurrentApplicationSettings.PuttySessionsList.Count; i++)
				{
					PuttySession puttySession = CurrentApplicationSettings.PuttySessionsList[i] as PuttySession;
					if (puttySession.SessionHost == "")
					{
						cmbPuttySession.Items.Add(puttySession.SessionName);
					}
				}

				this.cmbProtocol.Text = "SSH";
				this.cmbPuttySession.Text = CurrentApplicationSettings.CreatePuttySetting;
				
				if (this.sess != null)
					this.displayExistingValues();
				
				if (this.txtName.Text.Trim() == "" || this.txtHost.Text.Trim() == "")
					this.btOK.Enabled = false;
				
				this.txtHost.Focus();
			}
			catch// (Exception ex)
			{
			}
		}

		public void createPostLoginCommandTextBox()
		{
			this.txtCommands = new TextBox[5];
			int x = 116;
			int num = 54;
			for (int i = 0; i < 5; i++)
			{
                this.txtCommands[i] = new TextBox
                {
                    Location = new Point(x, num),
                    Size = new Size(272, 25),
                    TabIndex = 14 + i
                };
                this.groupPostLoginCommand.Controls.Add(this.txtCommands[i]);
				num += 30;
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void SetAllCommands(bool value) { 
		
			for (int i = 0; i < txtCommands.Count<TextBox>(); i++)
				txtCommands[i].Enabled = value;

			if(value)
				txtCommands[0].Focus();
		}



        private void checkPostLogin_CheckedChanged(object sender, EventArgs e)
		{
			SetAllCommands(checkPostLogin.Checked);
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			if (txtName.Text.Trim() == "")
				btOK.Enabled = false;
			else if (txtHost.Text.Trim() != "")
				btOK.Enabled = true;
		}

		private void txtHost_TextChanged(object sender, EventArgs e)
		{
			if (txtHost.Text.Trim() == "")
				btOK.Enabled = false;
			else if (txtName.Text.Trim() != "")
				btOK.Enabled = true;
		}

		public String[] getPostLoginCommands()
		{
            String[] plArray = new String[txtCommands.Length];

			for (int i = 0; i < txtCommands.Count<TextBox>(); i++)
			{
				if (txtCommands[i].Text != "")
                    plArray[i] = txtCommands[i].Text;
			}
			return plArray;
		}

		private void tabpageExtraConnect_Enter(object sender, EventArgs e)
		{
			if (sess == null)
			{
				if (txtFTPUserName.Text == "")
					txtFTPUserName.Text = txtSessionUserName.Text;
				
				if (txtFTPPassword.Text == "")
					txtFTPPassword.Text = txtSessionPassword.Text;
				
				if (txtSFTPUserName.Text == "")
					txtSFTPUserName.Text = txtSessionUserName.Text;
				
				if (txtSFTPPassword.Text == "")
					txtSFTPPassword.Text = txtSessionPassword.Text;
				
			}
		}
		private void btShowFTPPassword_Click(object sender, EventArgs e)
		{
			if (txtFTPPassword.PasswordChar == '*')
				txtFTPPassword.PasswordChar = '\0';
			else
				txtFTPPassword.PasswordChar = '*';
		}

		private void btShowSFTPPassword_Click(object sender, EventArgs e)
		{
			if (txtSFTPPassword.PasswordChar == '*')
				txtSFTPPassword.PasswordChar = '\0';
			else
				txtSFTPPassword.PasswordChar = '*';
		}

		private void cmbProtocol_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbProtocol.Text == "SSH")
				numPort.Value = 22m;
			else if (cmbProtocol.Text == "Telnet")
				numPort.Value = 23m;
            else if (cmbProtocol.Text == "RLogin")
				numPort.Value = 513m;
		}

		private void btShowSessionPassword_Click(object sender, EventArgs e)
		{
			if (txtSessionPassword.PasswordChar == '*')
				txtSessionPassword.PasswordChar = '\0';
			else
				txtSessionPassword.PasswordChar = '*';
		}

		private void txtName_Enter(object sender, EventArgs e)
		{
			if (txtHost.Text.Trim() != "" && txtName.Text.Trim() == "")
				txtName.Text = txtHost.Text;
		}

		public Session sess;

		public TextBox[] txtCommands;

		public frmSession.CreateOrUpdateSession createOrUpdateSession;

		public delegate void CreateOrUpdateSession(Session sess);
	}
}
