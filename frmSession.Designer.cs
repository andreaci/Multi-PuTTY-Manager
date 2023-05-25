using System.ComponentModel;
using System.Windows.Forms;

namespace SessionManagement
{
	public partial class frmSession : System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}


        private ComponentResourceManager componentResourceManager;
        private void InitializeComponent()
		{
			componentResourceManager = new ComponentResourceManager(typeof(SessionManagement.frmSession));
			this.btOK = new System.Windows.Forms.Button();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabpageSession = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btShowSessionPassword = new System.Windows.Forms.Button();
			this.txtSessionPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSessionUserName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.richDescription = new System.Windows.Forms.RichTextBox();
			this.numPort = new NumericUpDown();
			this.cmbPuttySession = new System.Windows.Forms.ComboBox();
			this.cmbProtocol = new System.Windows.Forms.ComboBox();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabpageAdvancedSession = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.numPasswordTimeout = new System.Windows.Forms.NumericUpDown();
			this.numConnectionTimeout = new System.Windows.Forms.NumericUpDown();
			this.label20 = new System.Windows.Forms.Label();
			this.numUsernameTimeout = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.numCommandTimeout = new System.Windows.Forms.NumericUpDown();
			this.groupPostLoginCommand = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.checkPostLogin = new System.Windows.Forms.CheckBox();
			this.tabpageExtraConnect = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btShowSFTPPassword = new System.Windows.Forms.Button();
			this.txtSFTPPassword = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtSFTPUserName = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btShowFTPPassword = new System.Windows.Forms.Button();
			this.txtFTPPassword = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtFTPUserName = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btCancel = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.tabpageSession.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numPort).BeginInit();
			this.tabpageAdvancedSession.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numPasswordTimeout).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numConnectionTimeout).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numUsernameTimeout).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numCommandTimeout).BeginInit();
			this.groupPostLoginCommand.SuspendLayout();
			this.tabpageExtraConnect.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.btOK.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btOK.Location = new System.Drawing.Point(307, 406);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(89, 27);
			this.btOK.TabIndex = 19;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			this.tabMain.Controls.Add(this.tabpageSession);
			this.tabMain.Controls.Add(this.tabpageAdvancedSession);
			this.tabMain.Controls.Add(this.tabpageExtraConnect);
			this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabMain.Location = new System.Drawing.Point(1, 6);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(494, 394);
			this.tabMain.TabIndex = 2;
			this.tabpageSession.Controls.Add(this.groupBox1);
			this.tabpageSession.Location = new System.Drawing.Point(4, 24);
			this.tabpageSession.Name = "tabpageSession";
			this.tabpageSession.Padding = new System.Windows.Forms.Padding(3);
			this.tabpageSession.Size = new System.Drawing.Size(486, 366);
			this.tabpageSession.TabIndex = 0;
			this.tabpageSession.Text = "Session";
			this.tabpageSession.UseVisualStyleBackColor = true;
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.richDescription);
			this.groupBox1.Controls.Add(this.numPort);
			this.groupBox1.Controls.Add(this.cmbPuttySession);
			this.groupBox1.Controls.Add(this.cmbProtocol);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new System.Drawing.Point(33, 5);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(420, 352);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox2.Controls.Add(this.btShowSessionPassword);
			this.groupBox2.Controls.Add(this.txtSessionPassword);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtSessionUserName);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(30, 245);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(350, 95);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Auto-login credentials";
			
			this.btShowSessionPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btShowSessionPassword.Location = new System.Drawing.Point(301, 59);
			this.btShowSessionPassword.Name = "btShowSessionPassword";
			this.btShowSessionPassword.Size = new System.Drawing.Size(26, 26);
			this.btShowSessionPassword.TabIndex = 16;
			this.btShowSessionPassword.UseVisualStyleBackColor = true;
			this.btShowSessionPassword.Click += new System.EventHandler(this.btShowSessionPassword_Click);
			this.txtSessionPassword.Font = new System.Drawing.Font("Century Schoolbook", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSessionPassword.Location = new System.Drawing.Point(103, 59);
			this.txtSessionPassword.Name = "txtSessionPassword";
			this.txtSessionPassword.PasswordChar = '*';
			this.txtSessionPassword.Size = new System.Drawing.Size(194, 26);
			this.txtSessionPassword.TabIndex = 15;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 15);
			this.label6.TabIndex = 14;
			this.label6.Text = "Password";
			this.txtSessionUserName.Location = new System.Drawing.Point(103, 29);
			this.txtSessionUserName.Name = "txtSessionUserName";
			this.txtSessionUserName.Size = new System.Drawing.Size(194, 23);
			this.txtSessionUserName.TabIndex = 13;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 15);
			this.label5.TabIndex = 12;
			this.label5.Text = "User name";
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(29, 178);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 15);
			this.label7.TabIndex = 5;
			this.label7.Text = "Description";
			this.richDescription.Location = new System.Drawing.Point(138, 173);
			this.richDescription.Name = "richDescription";
			this.richDescription.Size = new System.Drawing.Size(242, 53);
			this.richDescription.TabIndex = 5;
			this.richDescription.Text = "";
			this.numPort.Location = new System.Drawing.Point(138, 113);

            NumericUpDown numericUpDown = this.numPort;
			int[] array1 = new int[4];
			array1[0] = 32000;
			numericUpDown.Maximum = new decimal(array1);
			this.numPort.Name = "numPort";
			this.numPort.Size = new System.Drawing.Size(83, 23);
			this.numPort.TabIndex = 3;
			System.Windows.Forms.NumericUpDown numericUpDown2 = this.numPort;
            int[]  array2 = new int[4];
			array2[0] = 22;
			numericUpDown2.Value = new decimal(array2);
			this.cmbPuttySession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPuttySession.FormattingEnabled = true;
			this.cmbPuttySession.Items.AddRange(new object[]
			{
				"Default Settings"
			});
			this.cmbPuttySession.Location = new System.Drawing.Point(138, 143);
			this.cmbPuttySession.MaxDropDownItems = 100;
			this.cmbPuttySession.Name = "cmbPuttySession";
			this.cmbPuttySession.Size = new System.Drawing.Size(192, 23);
			this.cmbPuttySession.TabIndex = 4;
			this.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProtocol.FormattingEnabled = true;
			this.cmbProtocol.Items.AddRange(new object[]
			{
				"Telnet",
				"SSH",
				"Raw",
				"RLogin"
			});
			this.cmbProtocol.Location = new System.Drawing.Point(138, 82);
			this.cmbProtocol.Name = "cmbProtocol";
			this.cmbProtocol.Size = new System.Drawing.Size(83, 23);
			this.cmbProtocol.TabIndex = 2;
			this.cmbProtocol.SelectedIndexChanged += new System.EventHandler(this.cmbProtocol_SelectedIndexChanged);
			this.txtHost.Location = new System.Drawing.Point(138, 18);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(242, 23);
			this.txtHost.TabIndex = 0;
			this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
			this.txtName.Location = new System.Drawing.Point(138, 50);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(242, 23);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(29, 147);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(81, 15);
			this.label21.TabIndex = 0;
			this.label21.Text = "PuTTY setting";
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 15);
			this.label4.TabIndex = 0;
			this.label4.Text = "Port";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Protocol";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Host/IP Address";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			this.tabpageAdvancedSession.Controls.Add(this.groupBox6);
			this.tabpageAdvancedSession.Controls.Add(this.groupPostLoginCommand);
			this.tabpageAdvancedSession.Location = new System.Drawing.Point(4, 24);
			this.tabpageAdvancedSession.Name = "tabpageAdvancedSession";
			this.tabpageAdvancedSession.Padding = new System.Windows.Forms.Padding(3);
			this.tabpageAdvancedSession.Size = new System.Drawing.Size(486, 366);
			this.tabpageAdvancedSession.TabIndex = 1;
			this.tabpageAdvancedSession.Text = "Advanced Session";
			this.tabpageAdvancedSession.UseVisualStyleBackColor = true;
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Controls.Add(this.numPasswordTimeout);
			this.groupBox6.Controls.Add(this.numConnectionTimeout);
			this.groupBox6.Controls.Add(this.label20);
			this.groupBox6.Controls.Add(this.numUsernameTimeout);
			this.groupBox6.Controls.Add(this.label17);
			this.groupBox6.Controls.Add(this.numCommandTimeout);
			this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox6.Location = new System.Drawing.Point(39, 20);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(404, 100);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Timeout (ms)";
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(231, 30);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(57, 15);
			this.label19.TabIndex = 25;
			this.label19.Text = "Password";
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(17, 30);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(69, 15);
			this.label18.TabIndex = 25;
			this.label18.Text = "Connection";
			System.Windows.Forms.NumericUpDown numericUpDown3 = this.numPasswordTimeout;
			
			int[] array3 = new int[4];
			array3[0] = 100;
			numericUpDown3.Increment = new decimal(array3);
			this.numPasswordTimeout.Location = new System.Drawing.Point(321, 28);
			System.Windows.Forms.NumericUpDown numericUpDown4 = this.numPasswordTimeout;

			int[] array4 = new int[4];
            array4[0] = 30000;
			numericUpDown4.Maximum = new decimal(array4);
			System.Windows.Forms.NumericUpDown numericUpDown5 = this.numPasswordTimeout;
			int[] array5 = new int[4];
            array5[0] = 500;
			numericUpDown5.Minimum = new decimal(array5);

			this.numPasswordTimeout.Name = "numPasswordTimeout";
			this.numPasswordTimeout.Size = new System.Drawing.Size(67, 23);
			this.numPasswordTimeout.TabIndex = 11;
			System.Windows.Forms.NumericUpDown numericUpDown6 = this.numPasswordTimeout;
            int[] array6 = new int[4];
            array6[0] = 1000;
			numericUpDown6.Value = new decimal(array6);
			System.Windows.Forms.NumericUpDown numericUpDown7 = this.numConnectionTimeout;

            int[] array7 = new int[4];
            array7[0] = 100;
			numericUpDown7.Increment = new decimal(array7);
			this.numConnectionTimeout.Location = new System.Drawing.Point(107, 28);
			System.Windows.Forms.NumericUpDown numericUpDown8 = this.numConnectionTimeout;

            int[] array8 = new int[4];
            array8[0] = 30000;
			numericUpDown8.Maximum = new decimal(array8);
			System.Windows.Forms.NumericUpDown numericUpDown9 = this.numConnectionTimeout;

            int[] array9 = new int[4];
            array9[0] = 500;
			numericUpDown9.Minimum = new decimal(array9);
			this.numConnectionTimeout.Name = "numConnectionTimeout";
			this.numConnectionTimeout.Size = new System.Drawing.Size(67, 23);
			this.numConnectionTimeout.TabIndex = 9;
			System.Windows.Forms.NumericUpDown numericUpDown10 = this.numConnectionTimeout;

            int[] array10 = new int[4];
            array10[0] = 1500;
			numericUpDown10.Value = new decimal(array10);
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(17, 63);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(63, 15);
			this.label20.TabIndex = 25;
			this.label20.Text = "User name";
			System.Windows.Forms.NumericUpDown numericUpDown11 = this.numUsernameTimeout;

			int[] array11 = new int[4];
            array11[0] = 100;
			numericUpDown11.Increment = new decimal(array11);
			this.numUsernameTimeout.Location = new System.Drawing.Point(107, 61);
			System.Windows.Forms.NumericUpDown numericUpDown12 = this.numUsernameTimeout;

			int[] array12 = new int[4];
            array12[0] = 30000;
			numericUpDown12.Maximum = new decimal(array12);
			System.Windows.Forms.NumericUpDown numericUpDown13 = this.numUsernameTimeout;

            int[] array13 = new int[4];
            array13[0] = 500;
			numericUpDown13.Minimum = new decimal(array13);
			this.numUsernameTimeout.Name = "numUsernameTimeout";
			this.numUsernameTimeout.Size = new System.Drawing.Size(67, 23);
			this.numUsernameTimeout.TabIndex = 10;
			System.Windows.Forms.NumericUpDown numericUpDown14 = this.numUsernameTimeout;

            int[] array14 = new int[4];
            array14[0] = 1000;
			numericUpDown14.Value = new decimal(array14);
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(231, 65);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 15);
			this.label17.TabIndex = 25;
			this.label17.Text = "Command";
			System.Windows.Forms.NumericUpDown numericUpDown15 = this.numCommandTimeout;

            int[] array15 = new int[4];
            array15[0] = 100;
			numericUpDown15.Increment = new decimal(array15);
			this.numCommandTimeout.Location = new System.Drawing.Point(321, 63);
			System.Windows.Forms.NumericUpDown numericUpDown16 = this.numCommandTimeout;

            int[] array16 = new int[4];
            array16[0] = 30000;
			numericUpDown16.Maximum = new decimal(array16);
			System.Windows.Forms.NumericUpDown numericUpDown17 = this.numCommandTimeout;

			int[] array17 = new int[4];
            array17[0] = 500;
			numericUpDown17.Minimum = new decimal(array17);
			this.numCommandTimeout.Name = "numCommandTimeout";
			this.numCommandTimeout.Size = new System.Drawing.Size(67, 23);
			this.numCommandTimeout.TabIndex = 12;
			System.Windows.Forms.NumericUpDown numericUpDown18 = this.numCommandTimeout;

			int[] array18 = new int[4];
            array18[0] = 1000;
			numericUpDown18.Value = new decimal(array18);
			this.groupPostLoginCommand.Controls.Add(this.label12);
			this.groupPostLoginCommand.Controls.Add(this.label11);
			this.groupPostLoginCommand.Controls.Add(this.label10);
			this.groupPostLoginCommand.Controls.Add(this.label9);
			this.groupPostLoginCommand.Controls.Add(this.label8);
			this.groupPostLoginCommand.Controls.Add(this.checkPostLogin);
			this.groupPostLoginCommand.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.groupPostLoginCommand.Location = new System.Drawing.Point(39, 134);
			this.groupPostLoginCommand.Name = "groupPostLoginCommand";
			this.groupPostLoginCommand.Size = new System.Drawing.Size(404, 204);
			this.groupPostLoginCommand.TabIndex = 13;
			this.groupPostLoginCommand.TabStop = false;
			this.groupPostLoginCommand.Text = "Post-login commands";
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(21, 177);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(73, 15);
			this.label12.TabIndex = 23;
			this.label12.Text = "Command 5";
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(22, 147);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(73, 15);
			this.label11.TabIndex = 22;
			this.label11.Text = "Command 4";
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(22, 117);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 15);
			this.label10.TabIndex = 21;
			this.label10.Text = "Command 3";
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(22, 87);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(73, 15);
			this.label9.TabIndex = 20;
			this.label9.Text = "Command 2";
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(22, 57);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(73, 15);
			this.label8.TabIndex = 19;
			this.label8.Text = "Command 1";
			this.checkPostLogin.AutoSize = true;
			this.checkPostLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.checkPostLogin.Location = new System.Drawing.Point(116, 27);
			this.checkPostLogin.Name = "checkPostLogin";
			this.checkPostLogin.Size = new System.Drawing.Size(61, 19);
			this.checkPostLogin.TabIndex = 13;
			this.checkPostLogin.Text = "Enable";
			this.checkPostLogin.UseVisualStyleBackColor = true;
			this.checkPostLogin.CheckedChanged += new System.EventHandler(this.checkPostLogin_CheckedChanged);
			this.tabpageExtraConnect.Controls.Add(this.groupBox5);
			this.tabpageExtraConnect.Controls.Add(this.groupBox4);
			this.tabpageExtraConnect.Location = new System.Drawing.Point(4, 24);
			this.tabpageExtraConnect.Name = "tabpageExtraConnect";
			this.tabpageExtraConnect.Padding = new System.Windows.Forms.Padding(3);
			this.tabpageExtraConnect.Size = new System.Drawing.Size(486, 366);
			this.tabpageExtraConnect.TabIndex = 2;
			this.tabpageExtraConnect.Text = "Extra Connection";
			this.tabpageExtraConnect.UseVisualStyleBackColor = true;
			this.tabpageExtraConnect.Enter += new System.EventHandler(this.tabpageExtraConnect_Enter);
			this.groupBox5.Controls.Add(this.btShowSFTPPassword);
			this.groupBox5.Controls.Add(this.txtSFTPPassword);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.txtSFTPUserName);
			this.groupBox5.Controls.Add(this.label16);
			this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox5.Location = new System.Drawing.Point(58, 202);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(370, 109);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "SFTP";
			
			this.btShowSFTPPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btShowSFTPPassword.Location = new System.Drawing.Point(308, 61);
			this.btShowSFTPPassword.Name = "btShowSFTPPassword";
			this.btShowSFTPPassword.Size = new System.Drawing.Size(26, 26);
			this.btShowSFTPPassword.TabIndex = 22;
			this.btShowSFTPPassword.UseVisualStyleBackColor = true;
			this.btShowSFTPPassword.Click += new System.EventHandler(this.btShowSFTPPassword_Click);
			this.txtSFTPPassword.Location = new System.Drawing.Point(110, 61);
			this.txtSFTPPassword.Name = "txtSFTPPassword";
			this.txtSFTPPassword.PasswordChar = '*';
			this.txtSFTPPassword.Size = new System.Drawing.Size(192, 23);
			this.txtSFTPPassword.TabIndex = 19;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(22, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(57, 15);
			this.label15.TabIndex = 18;
			this.label15.Text = "Password";
			this.txtSFTPUserName.Location = new System.Drawing.Point(110, 29);
			this.txtSFTPUserName.Name = "txtSFTPUserName";
			this.txtSFTPUserName.Size = new System.Drawing.Size(192, 23);
			this.txtSFTPUserName.TabIndex = 17;
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(22, 33);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 15);
			this.label16.TabIndex = 16;
			this.label16.Text = "User name";
			this.groupBox4.Controls.Add(this.btShowFTPPassword);
			this.groupBox4.Controls.Add(this.txtFTPPassword);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.txtFTPUserName);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new System.Drawing.Point(58, 42);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(370, 109);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "FTP";
			
			this.btShowFTPPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btShowFTPPassword.Location = new System.Drawing.Point(308, 62);
			this.btShowFTPPassword.Name = "btShowFTPPassword";
			this.btShowFTPPassword.Size = new System.Drawing.Size(26, 26);
			this.btShowFTPPassword.TabIndex = 21;
			this.btShowFTPPassword.UseVisualStyleBackColor = true;
			this.btShowFTPPassword.Click += new System.EventHandler(this.btShowFTPPassword_Click);
			this.txtFTPPassword.Location = new System.Drawing.Point(110, 62);
			this.txtFTPPassword.Name = "txtFTPPassword";
			this.txtFTPPassword.PasswordChar = '*';
			this.txtFTPPassword.Size = new System.Drawing.Size(192, 23);
			this.txtFTPPassword.TabIndex = 19;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(22, 65);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(57, 15);
			this.label13.TabIndex = 18;
			this.label13.Text = "Password";
			this.txtFTPUserName.Location = new System.Drawing.Point(110, 29);
			this.txtFTPUserName.Name = "txtFTPUserName";
			this.txtFTPUserName.Size = new System.Drawing.Size(192, 23);
			this.txtFTPUserName.TabIndex = 17;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(22, 34);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(63, 15);
			this.label14.TabIndex = 16;
			this.label14.Text = "User name";
			this.btCancel.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new System.Drawing.Point(402, 406);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(89, 27);
			this.btCancel.TabIndex = 20;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(495, 445);
			base.Controls.Add(this.btCancel);
			base.Controls.Add(this.tabMain);
			base.Controls.Add(this.btOK);
			this.Font = new System.Drawing.Font("Century Schoolbook", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmSession";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Session....";
			base.Load += new System.EventHandler(this.frmSession_Load);
			this.tabMain.ResumeLayout(false);
			this.tabpageSession.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numPort).EndInit();
			this.tabpageAdvancedSession.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numPasswordTimeout).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numConnectionTimeout).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numUsernameTimeout).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numCommandTimeout).EndInit();
			this.groupPostLoginCommand.ResumeLayout(false);
			this.groupPostLoginCommand.PerformLayout();
			this.tabpageExtraConnect.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
		}

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Button btOK;

		private System.Windows.Forms.TabControl tabMain;

		private System.Windows.Forms.TabPage tabpageSession;

		private System.Windows.Forms.GroupBox groupBox1;

		private System.Windows.Forms.NumericUpDown numPort;

		private System.Windows.Forms.ComboBox cmbProtocol;

		private System.Windows.Forms.TextBox txtHost;

		private System.Windows.Forms.TextBox txtName;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TabPage tabpageAdvancedSession;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.RichTextBox richDescription;

		private System.Windows.Forms.GroupBox groupPostLoginCommand;

		private System.Windows.Forms.Label label12;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.CheckBox checkPostLogin;

		private System.Windows.Forms.Button btCancel;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.NumericUpDown numCommandTimeout;

		private System.Windows.Forms.TabPage tabpageExtraConnect;

		private System.Windows.Forms.GroupBox groupBox5;

		private System.Windows.Forms.Button btShowSFTPPassword;

		private System.Windows.Forms.TextBox txtSFTPPassword;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.TextBox txtSFTPUserName;

		private System.Windows.Forms.Label label16;

		private System.Windows.Forms.GroupBox groupBox4;

		private System.Windows.Forms.Button btShowFTPPassword;

		private System.Windows.Forms.TextBox txtFTPPassword;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.TextBox txtFTPUserName;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.GroupBox groupBox2;

		private System.Windows.Forms.Button btShowSessionPassword;

		private System.Windows.Forms.TextBox txtSessionPassword;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.TextBox txtSessionUserName;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.GroupBox groupBox6;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.Label label18;

		private System.Windows.Forms.NumericUpDown numPasswordTimeout;

		private System.Windows.Forms.NumericUpDown numConnectionTimeout;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.NumericUpDown numUsernameTimeout;

		private System.Windows.Forms.ComboBox cmbPuttySession;

		private System.Windows.Forms.Label label21;
	}
}
