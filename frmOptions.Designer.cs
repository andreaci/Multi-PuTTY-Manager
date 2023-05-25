using System.ComponentModel;

namespace SessionManagement
{
    public partial class frmOptions : System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private ComponentResourceManager componentResourceManager;
        private void InitializeComponent()
        {
            tabMain = new System.Windows.Forms.TabControl();
            tabpageGeneral = new System.Windows.Forms.TabPage();
            groupSessionManagerPosition = new System.Windows.Forms.GroupBox();
            radRight = new System.Windows.Forms.RadioButton();
            radLeft = new System.Windows.Forms.RadioButton();
            groupWinSCP = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            btWinSCPBrowser = new System.Windows.Forms.Button();
            txtWinSCPLocation = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            groupPutty = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            btPuttyBrowser = new System.Windows.Forms.Button();
            txtPuttyLocation = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            groupDatabase = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            btDatabaseBrowser = new System.Windows.Forms.Button();
            txtDatabaseLocation = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btOK = new System.Windows.Forms.Button();
            btCancel = new System.Windows.Forms.Button();
            btnPuttyDownload = new System.Windows.Forms.Button();
            tabMain.SuspendLayout();
            tabpageGeneral.SuspendLayout();
            groupSessionManagerPosition.SuspendLayout();
            groupWinSCP.SuspendLayout();
            groupPutty.SuspendLayout();
            groupDatabase.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabpageGeneral);
            tabMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabMain.Location = new System.Drawing.Point(3, 0);
            tabMain.Margin = new System.Windows.Forms.Padding(4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(577, 409);
            tabMain.TabIndex = 0;
            // 
            // tabpageGeneral
            // 
            tabpageGeneral.Controls.Add(groupSessionManagerPosition);
            tabpageGeneral.Controls.Add(groupWinSCP);
            tabpageGeneral.Controls.Add(groupPutty);
            tabpageGeneral.Controls.Add(groupDatabase);
            tabpageGeneral.Location = new System.Drawing.Point(4, 26);
            tabpageGeneral.Margin = new System.Windows.Forms.Padding(4);
            tabpageGeneral.Name = "tabpageGeneral";
            tabpageGeneral.Padding = new System.Windows.Forms.Padding(4);
            tabpageGeneral.Size = new System.Drawing.Size(569, 379);
            tabpageGeneral.TabIndex = 0;
            tabpageGeneral.Text = "General";
            tabpageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupSessionManagerPosition
            // 
            groupSessionManagerPosition.Controls.Add(radRight);
            groupSessionManagerPosition.Controls.Add(radLeft);
            groupSessionManagerPosition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupSessionManagerPosition.Location = new System.Drawing.Point(17, 293);
            groupSessionManagerPosition.Margin = new System.Windows.Forms.Padding(4);
            groupSessionManagerPosition.Name = "groupSessionManagerPosition";
            groupSessionManagerPosition.Padding = new System.Windows.Forms.Padding(4);
            groupSessionManagerPosition.Size = new System.Drawing.Size(543, 64);
            groupSessionManagerPosition.TabIndex = 3;
            groupSessionManagerPosition.TabStop = false;
            groupSessionManagerPosition.Text = "Sessions Manager Position";
            // 
            // radRight
            // 
            radRight.AutoSize = true;
            radRight.Location = new System.Drawing.Point(363, 27);
            radRight.Name = "radRight";
            radRight.Size = new System.Drawing.Size(78, 19);
            radRight.TabIndex = 1;
            radRight.TabStop = true;
            radRight.Text = "Right Side";
            radRight.UseVisualStyleBackColor = true;
            // 
            // radLeft
            // 
            radLeft.AutoSize = true;
            radLeft.Location = new System.Drawing.Point(81, 27);
            radLeft.Name = "radLeft";
            radLeft.Size = new System.Drawing.Size(70, 19);
            radLeft.TabIndex = 0;
            radLeft.TabStop = true;
            radLeft.Text = "Left Side";
            radLeft.UseVisualStyleBackColor = true;
            // 
            // groupWinSCP
            // 
            groupWinSCP.Controls.Add(label5);
            groupWinSCP.Controls.Add(btWinSCPBrowser);
            groupWinSCP.Controls.Add(txtWinSCPLocation);
            groupWinSCP.Controls.Add(label6);
            groupWinSCP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupWinSCP.Location = new System.Drawing.Point(17, 199);
            groupWinSCP.Margin = new System.Windows.Forms.Padding(4);
            groupWinSCP.Name = "groupWinSCP";
            groupWinSCP.Padding = new System.Windows.Forms.Padding(4);
            groupWinSCP.Size = new System.Drawing.Size(543, 79);
            groupWinSCP.TabIndex = 2;
            groupWinSCP.TabStop = false;
            groupWinSCP.Text = "WinSCP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(78, 55);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(212, 15);
            label5.TabIndex = 3;
            label5.Text = "(For example: C:\\WinSCP\\WinSCP.exe)";
            // 
            // btWinSCPBrowser
            // 
            btWinSCPBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btWinSCPBrowser.Location = new System.Drawing.Point(468, 25);
            btWinSCPBrowser.Name = "btWinSCPBrowser";
            btWinSCPBrowser.Size = new System.Drawing.Size(68, 26);
            btWinSCPBrowser.TabIndex = 2;
            btWinSCPBrowser.Text = "Browse";
            btWinSCPBrowser.UseVisualStyleBackColor = true;
            btWinSCPBrowser.Click += btWinSCPBrowser_Click;
            // 
            // txtWinSCPLocation
            // 
            txtWinSCPLocation.Location = new System.Drawing.Point(81, 25);
            txtWinSCPLocation.Name = "txtWinSCPLocation";
            txtWinSCPLocation.Size = new System.Drawing.Size(381, 23);
            txtWinSCPLocation.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 28);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 15);
            label6.TabIndex = 0;
            label6.Text = "Location";
            // 
            // groupPutty
            // 
            groupPutty.Controls.Add(btnPuttyDownload);
            groupPutty.Controls.Add(label3);
            groupPutty.Controls.Add(btPuttyBrowser);
            groupPutty.Controls.Add(txtPuttyLocation);
            groupPutty.Controls.Add(label4);
            groupPutty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupPutty.Location = new System.Drawing.Point(17, 101);
            groupPutty.Margin = new System.Windows.Forms.Padding(4);
            groupPutty.Name = "groupPutty";
            groupPutty.Padding = new System.Windows.Forms.Padding(4);
            groupPutty.Size = new System.Drawing.Size(543, 83);
            groupPutty.TabIndex = 1;
            groupPutty.TabStop = false;
            groupPutty.Text = "PuTTY";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(78, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(184, 15);
            label3.TabIndex = 3;
            label3.Text = "(For example: C:\\Putty\\Putty.exe)";
            // 
            // btPuttyBrowser
            // 
            btPuttyBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btPuttyBrowser.Location = new System.Drawing.Point(394, 23);
            btPuttyBrowser.Name = "btPuttyBrowser";
            btPuttyBrowser.Size = new System.Drawing.Size(69, 26);
            btPuttyBrowser.TabIndex = 2;
            btPuttyBrowser.Text = "Browse";
            btPuttyBrowser.UseVisualStyleBackColor = true;
            btPuttyBrowser.Click += btPuttyBrowser_Click;
            // 
            // txtPuttyLocation
            // 
            txtPuttyLocation.Location = new System.Drawing.Point(81, 25);
            txtPuttyLocation.Name = "txtPuttyLocation";
            txtPuttyLocation.Size = new System.Drawing.Size(307, 23);
            txtPuttyLocation.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 0;
            label4.Text = "Location";
            // 
            // groupDatabase
            // 
            groupDatabase.Controls.Add(label2);
            groupDatabase.Controls.Add(btDatabaseBrowser);
            groupDatabase.Controls.Add(txtDatabaseLocation);
            groupDatabase.Controls.Add(label1);
            groupDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupDatabase.Location = new System.Drawing.Point(18, 11);
            groupDatabase.Margin = new System.Windows.Forms.Padding(4);
            groupDatabase.Name = "groupDatabase";
            groupDatabase.Padding = new System.Windows.Forms.Padding(4);
            groupDatabase.Size = new System.Drawing.Size(543, 75);
            groupDatabase.TabIndex = 0;
            groupDatabase.TabStop = false;
            groupDatabase.Text = "Default database";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(78, 53);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(170, 15);
            label2.TabIndex = 3;
            label2.Text = "(For example: C:\\Database.dat)";
            // 
            // btDatabaseBrowser
            // 
            btDatabaseBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btDatabaseBrowser.Location = new System.Drawing.Point(468, 23);
            btDatabaseBrowser.Name = "btDatabaseBrowser";
            btDatabaseBrowser.Size = new System.Drawing.Size(68, 26);
            btDatabaseBrowser.TabIndex = 2;
            btDatabaseBrowser.Text = "Browse";
            btDatabaseBrowser.UseVisualStyleBackColor = true;
            btDatabaseBrowser.Click += btDatabaseBrowser_Click;
            // 
            // txtDatabaseLocation
            // 
            txtDatabaseLocation.Location = new System.Drawing.Point(81, 23);
            txtDatabaseLocation.Name = "txtDatabaseLocation";
            txtDatabaseLocation.Size = new System.Drawing.Size(381, 23);
            txtDatabaseLocation.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Location";
            // 
            // btOK
            // 
            btOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btOK.Location = new System.Drawing.Point(392, 412);
            btOK.Name = "btOK";
            btOK.Size = new System.Drawing.Size(88, 27);
            btOK.TabIndex = 1;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // btCancel
            // 
            btCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btCancel.Location = new System.Drawing.Point(486, 412);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(88, 27);
            btCancel.TabIndex = 2;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btnPuttyDownload
            // 
            btnPuttyDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnPuttyDownload.Location = new System.Drawing.Point(467, 23);
            btnPuttyDownload.Name = "btnPuttyDownload";
            btnPuttyDownload.Size = new System.Drawing.Size(69, 26);
            btnPuttyDownload.TabIndex = 4;
            btnPuttyDownload.Text = "Download";
            btnPuttyDownload.UseVisualStyleBackColor = true;
            btnPuttyDownload.Click += btnPuttyDownload_Click;
            // 
            // frmOptions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(586, 447);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(tabMain);
            Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmOptions";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Options...";
            Load += frmOptions_Load;
            tabMain.ResumeLayout(false);
            tabpageGeneral.ResumeLayout(false);
            groupSessionManagerPosition.ResumeLayout(false);
            groupSessionManagerPosition.PerformLayout();
            groupWinSCP.ResumeLayout(false);
            groupWinSCP.PerformLayout();
            groupPutty.ResumeLayout(false);
            groupPutty.PerformLayout();
            groupDatabase.ResumeLayout(false);
            groupDatabase.PerformLayout();
            ResumeLayout(false);
        }

        private IContainer components = null;

        private System.Windows.Forms.TabControl tabMain;

        private System.Windows.Forms.TabPage tabpageGeneral;

        private System.Windows.Forms.GroupBox groupDatabase;

        private System.Windows.Forms.Button btDatabaseBrowser;

        private System.Windows.Forms.TextBox txtDatabaseLocation;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.GroupBox groupWinSCP;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button btWinSCPBrowser;

        private System.Windows.Forms.TextBox txtWinSCPLocation;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.GroupBox groupPutty;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button btPuttyBrowser;

        private System.Windows.Forms.TextBox txtPuttyLocation;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button btOK;

        private System.Windows.Forms.Button btCancel;

        private System.Windows.Forms.GroupBox groupSessionManagerPosition;

        private System.Windows.Forms.RadioButton radRight;

        private System.Windows.Forms.RadioButton radLeft;
        private System.Windows.Forms.Button btnPuttyDownload;
    }
}
