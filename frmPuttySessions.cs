using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SessionManagement
{
	public partial class frmPuttySessions : Form
    {
        SettingsData CurrentApplicationSettings = SettingsData.Instance;
        
		public frmPuttySessions()
		{
			this.InitializeComponent();
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void frmPuttySessions_Load(object sender, EventArgs e)
		{
			try
			{
                CurrentApplicationSettings.readPuttySessionFromRegistry();
				for (int i = 0; i < CurrentApplicationSettings.PuttySessionsList.Count; i++)
				{
					PuttySession puttySession = CurrentApplicationSettings.PuttySessionsList[i] as PuttySession;
					if (puttySession.SessionHost != "")
					{
						this.dataGridPuttySession.Rows.Add(new object[]
						{
							puttySession.SessionName,
							puttySession.SessionHost
						});
					}
				}

				this.btCreateDatabase.Enabled = dataGridPuttySession.Rows.Count > 1;
			}
			catch //(Exception ex)
			{
			}
		}

		private void btCreateDatabase_Click(object sender, EventArgs e)
		{
			try
			{
				this.createDatabaseFromPuttySessions();
				base.Close();
			}
			catch //(Exception ex)
			{
			}
		}

		public frmPuttySessions.CreateDatabaseFromPuttySessions createDatabaseFromPuttySessions;

		public delegate void CreateDatabaseFromPuttySessions();
	}
}
