using System.ComponentModel;

namespace SessionManagement
{
	public partial class frmPutty : WeifenLuo.WinFormsUI.Docking.DockContent
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
			this.components = new System.ComponentModel.Container();
			componentResourceManager = new ComponentResourceManager(typeof(SessionManagement.frmPutty));
			this.pnMain = new System.Windows.Forms.Panel();
			this.tmCheckProcess = new System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Name = "pnMain";
			this.pnMain.Size = new System.Drawing.Size(433, 415);
			this.pnMain.TabIndex = 0;
			this.tmCheckProcess.Tick += new System.EventHandler(this.tmCheckProcess_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(433, 415);
			base.Controls.Add(this.pnMain);
			base.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Name = "frmPutty";
			this.Text = "frmPutty";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPutty_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPutty_FormClosed);
			base.Load += new System.EventHandler(this.frmPutty_Load);
			base.Resize += new System.EventHandler(this.frmPutty_Resize);
			base.ResumeLayout(false);
		}

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel pnMain;

		private System.Windows.Forms.Timer tmCheckProcess;
	}
}
