using System.ComponentModel;

namespace SessionManagement
{
    public partial class frmDatabaseProperties : System.Windows.Forms.Form
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lbLocation = new System.Windows.Forms.Label();
            btRename = new System.Windows.Forms.Button();
            txtDatabaseName = new System.Windows.Forms.TextBox();
            btCancel = new System.Windows.Forms.Button();
            btOK = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 17);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 70);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 17);
            label2.TabIndex = 0;
            label2.Text = "Location";
            // 
            // lbLocation
            // 
            lbLocation.AutoSize = true;
            lbLocation.Location = new System.Drawing.Point(105, 70);
            lbLocation.MaximumSize = new System.Drawing.Size(355, 50);
            lbLocation.Name = "lbLocation";
            lbLocation.Size = new System.Drawing.Size(68, 17);
            lbLocation.TabIndex = 3;
            lbLocation.Text = "lbLocation";
            // 
            // btRename
            // 
            btRename.Location = new System.Drawing.Point(389, 21);
            btRename.Name = "btRename";
            btRename.Size = new System.Drawing.Size(68, 27);
            btRename.TabIndex = 2;
            btRename.Text = "Rename";
            btRename.UseVisualStyleBackColor = true;
            btRename.Click += btRename_Click;
            // 
            // txtDatabaseName
            // 
            txtDatabaseName.Location = new System.Drawing.Point(71, 22);
            txtDatabaseName.Name = "txtDatabaseName";
            txtDatabaseName.Size = new System.Drawing.Size(312, 25);
            txtDatabaseName.TabIndex = 1;
            txtDatabaseName.TextChanged += txtDatabaseName_TextChanged;
            txtDatabaseName.KeyPress += txtDatabaseName_KeyPress;
            // 
            // btCancel
            // 
            btCancel.Location = new System.Drawing.Point(368, 111);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(89, 27);
            btCancel.TabIndex = 2;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btOK
            // 
            btOK.Location = new System.Drawing.Point(272, 111);
            btOK.Name = "btOK";
            btOK.Size = new System.Drawing.Size(89, 27);
            btOK.TabIndex = 2;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // frmDatabaseProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(474, 150);
            Controls.Add(lbLocation);
            Controls.Add(btOK);
            Controls.Add(btRename);
            Controls.Add(btCancel);
            Controls.Add(txtDatabaseName);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDatabaseProperties";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Database Properties";
            ResumeLayout(false);
            PerformLayout();
        }

        private IContainer components = null;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox txtDatabaseName;

        private System.Windows.Forms.Button btCancel;

        private System.Windows.Forms.Button btOK;

        private System.Windows.Forms.Button btRename;

        private System.Windows.Forms.Label lbLocation;
    }
}
