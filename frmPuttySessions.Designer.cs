using System.ComponentModel;

namespace SessionManagement
{
	public partial class frmPuttySessions : System.Windows.Forms.Form
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
			componentResourceManager = new ComponentResourceManager(typeof(SessionManagement.frmPuttySessions));
			this.btCancel = new System.Windows.Forms.Button();
			this.btCreateDatabase = new System.Windows.Forms.Button();
			this.dataGridPuttySession = new System.Windows.Forms.DataGridView();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.dataGridPuttySession).BeginInit();
			base.SuspendLayout();
			this.btCancel.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new System.Drawing.Point(344, 295);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(104, 26);
			this.btCancel.TabIndex = 22;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			this.btCreateDatabase.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.btCreateDatabase.Location = new System.Drawing.Point(224, 295);
			this.btCreateDatabase.Name = "btCreateDatabase";
			this.btCreateDatabase.Size = new System.Drawing.Size(116, 26);
			this.btCreateDatabase.TabIndex = 21;
			this.btCreateDatabase.Text = "Create Database";
			this.btCreateDatabase.UseVisualStyleBackColor = true;
			this.btCreateDatabase.Click += new System.EventHandler(this.btCreateDatabase_Click);
			this.dataGridPuttySession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridPuttySession.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
			{
				this.colName,
				this.colHost
			});
			this.dataGridPuttySession.Location = new System.Drawing.Point(5, 38);
			this.dataGridPuttySession.Name = "dataGridPuttySession";
			this.dataGridPuttySession.ReadOnly = true;
			this.dataGridPuttySession.Size = new System.Drawing.Size(443, 251);
			this.dataGridPuttySession.TabIndex = 23;
			this.colName.HeaderText = "Session Name";
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			this.colName.Width = 200;
			this.colHost.HeaderText = "Session Host/IP Address";
			this.colHost.Name = "colHost";
			this.colHost.ReadOnly = true;
			this.colHost.Width = 200;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(159, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 25);
			this.label1.TabIndex = 24;
			this.label1.Text = "PuTTY Sessions";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(453, 326);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.dataGridPuttySession);
			base.Controls.Add(this.btCancel);
			base.Controls.Add(this.btCreateDatabase);
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPuttySessions";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PuTTY Sessions";
			base.Load += new System.EventHandler(this.frmPuttySessions_Load);
			((System.ComponentModel.ISupportInitialize)this.dataGridPuttySession).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Button btCancel;

		private System.Windows.Forms.Button btCreateDatabase;

		private System.Windows.Forms.DataGridView dataGridPuttySession;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.DataGridViewTextBoxColumn colName;

		private System.Windows.Forms.DataGridViewTextBoxColumn colHost;
	}
}
