using System.ComponentModel;

namespace SessionManagement
{
	public partial class frmSessionManager : WeifenLuo.WinFormsUI.Docking.DockContent
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
			componentResourceManager = new ComponentResourceManager(typeof(SessionManagement.frmSessionManager));
			this.contextForDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextNewForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextSessionForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextFolderForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextPasteForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextSaveForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.contextSetDefaultForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextPropertiesForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.contextCloseDatabaseForDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.treeSessions = new System.Windows.Forms.TreeView();
			this.contextForTreeSession = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextCreateDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.contextOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.imageListSessionManager = new System.Windows.Forms.ImageList(this.components);
			this.contextForFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextNewForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextSessionForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextFolderForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.contextConnectAllForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.contextCutForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextCopyForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextPasteForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextDeleteForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextRenameForFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.contextForSession = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.contextConnectExternal = new System.Windows.Forms.ToolStripMenuItem();
			this.contextFTPExternal = new System.Windows.Forms.ToolStripMenuItem();
			this.contextSFTPExternal = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.contextCutForSession = new System.Windows.Forms.ToolStripMenuItem();
			this.contextCopyForSession = new System.Windows.Forms.ToolStripMenuItem();
			this.contextDeleteForSession = new System.Windows.Forms.ToolStripMenuItem();
			this.contextRenameForSession = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.contextConfigForSession = new System.Windows.Forms.ToolStripMenuItem();
			this.contextForDatabase.SuspendLayout();
			this.contextForTreeSession.SuspendLayout();
			this.contextForFolder.SuspendLayout();
			this.contextForSession.SuspendLayout();
			base.SuspendLayout();
			this.contextForDatabase.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.contextForDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextNewForDatabase,
				this.contextPasteForDatabase,
				this.contextSaveForDatabase,
				this.toolStripSeparator5,
				this.contextSetDefaultForDatabase,
				this.contextPropertiesForDatabase,
				this.toolStripSeparator3,
				this.contextCloseDatabaseForDatabase
			});
			this.contextForDatabase.Name = "contextForDatabase";
			this.contextForDatabase.Size = new System.Drawing.Size(195, 148);
			this.contextForDatabase.Opening += new System.ComponentModel.CancelEventHandler(this.contextForDatabase_Opening);
			this.contextNewForDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextSessionForDatabase,
				this.contextFolderForDatabase
			});
			this.contextNewForDatabase.Name = "contextNewForDatabase";
			this.contextNewForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextNewForDatabase.Text = "New";
			this.contextSessionForDatabase.Name = "contextSessionForDatabase";
			this.contextSessionForDatabase.Size = new System.Drawing.Size(113, 22);
			this.contextSessionForDatabase.Text = "Session";
			this.contextSessionForDatabase.Click += new System.EventHandler(this.contextSessionForDatabase_Click);
			this.contextFolderForDatabase.Name = "contextFolderForDatabase";
			this.contextFolderForDatabase.Size = new System.Drawing.Size(113, 22);
			this.contextFolderForDatabase.Text = "Folder";
			this.contextFolderForDatabase.Click += new System.EventHandler(this.contextFolderForDatabase_Click);
			this.contextPasteForDatabase.Name = "contextPasteForDatabase";
			this.contextPasteForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextPasteForDatabase.Text = "Paste";
			this.contextPasteForDatabase.Click += new System.EventHandler(this.contextPasteForDatabase_Click);
			this.contextSaveForDatabase.Name = "contextSaveForDatabase";
			this.contextSaveForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextSaveForDatabase.Text = "Save";
			this.contextSaveForDatabase.Click += new System.EventHandler(this.contextSaveForDatabase_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(191, 6);
			this.contextSetDefaultForDatabase.Name = "contextSetDefaultForDatabase";
			this.contextSetDefaultForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextSetDefaultForDatabase.Text = "Set as default database";
			this.contextSetDefaultForDatabase.Click += new System.EventHandler(this.contextSetDefaultForDatabase_Click);
			this.contextPropertiesForDatabase.Name = "contextPropertiesForDatabase";
			this.contextPropertiesForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextPropertiesForDatabase.Text = "Properties";
			this.contextPropertiesForDatabase.Click += new System.EventHandler(this.contextPropertiesForDatabase_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
			this.contextCloseDatabaseForDatabase.Name = "contextCloseDatabaseForDatabase";
			this.contextCloseDatabaseForDatabase.Size = new System.Drawing.Size(194, 22);
			this.contextCloseDatabaseForDatabase.Text = "Close database";
			this.contextCloseDatabaseForDatabase.Click += new System.EventHandler(this.contextCloseDatabaseForDatabase_Click);
			this.treeSessions.BackColor = System.Drawing.SystemColors.Window;
			this.treeSessions.ContextMenuStrip = this.contextForTreeSession;
			this.treeSessions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeSessions.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.treeSessions.ImageIndex = 0;
			this.treeSessions.ImageList = this.imageListSessionManager;
			this.treeSessions.LabelEdit = true;
			this.treeSessions.Location = new System.Drawing.Point(0, 0);
			this.treeSessions.Name = "treeSessions";
			this.treeSessions.SelectedImageIndex = 0;
			this.treeSessions.ShowNodeToolTips = true;
			this.treeSessions.Size = new System.Drawing.Size(255, 398);
			this.treeSessions.TabIndex = 0;
			this.treeSessions.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeSessions_AfterLabelEdit);
			this.treeSessions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSessions_AfterSelect);
			this.treeSessions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeSessions_NodeMouseClick);
			this.treeSessions.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeSessions_NodeMouseDoubleClick);
			this.treeSessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeSessions_KeyDown);
			this.treeSessions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeSessions_KeyPress);
			this.contextForTreeSession.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.contextForTreeSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextCreateDatabase,
				this.contextOpenDatabase
			});
			this.contextForTreeSession.Name = "contextForTreeSession";
			this.contextForTreeSession.Size = new System.Drawing.Size(159, 48);
			this.contextCreateDatabase.Name = "contextCreateDatabase";
			this.contextCreateDatabase.Size = new System.Drawing.Size(158, 22);
			this.contextCreateDatabase.Text = "Create database";
			this.contextCreateDatabase.Click += new System.EventHandler(this.contextCreateDatabase_Click);
			this.contextOpenDatabase.Name = "contextOpenDatabase";
			this.contextOpenDatabase.Size = new System.Drawing.Size(158, 22);
			this.contextOpenDatabase.Text = "Open database";
			this.contextOpenDatabase.Click += new System.EventHandler(this.contextOpenDatabase_Click);
			//this.imageListSessionManager.ImageStream = (System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageListSessionManager.ImageStream");
			//this.imageListSessionManager.TransparentColor = System.Drawing.Color.Transparent;
			//this.imageListSessionManager.Images.SetKeyName(0, "Database.png");
			//this.imageListSessionManager.Images.SetKeyName(1, "Folder3.png");
			//this.imageListSessionManager.Images.SetKeyName(2, "Session.png");
			//this.imageListSessionManager.Images.SetKeyName(3, "Session_cut.png");
			//this.imageListSessionManager.Images.SetKeyName(4, "Folder_cut.png");
			this.contextForFolder.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.contextForFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextNewForFolder,
				this.toolStripSeparator6,
				this.contextConnectAllForFolder,
				this.toolStripSeparator4,
				this.contextCutForFolder,
				this.contextCopyForFolder,
				this.contextPasteForFolder,
				this.contextDeleteForFolder,
				this.contextRenameForFolder
			});
			this.contextForFolder.Name = "contextForFolder";
			this.contextForFolder.Size = new System.Drawing.Size(168, 170);
			this.contextForFolder.Opening += new System.ComponentModel.CancelEventHandler(this.contextForFolder_Opening);
			this.contextNewForFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextSessionForFolder,
				this.contextFolderForFolder
			});
			this.contextNewForFolder.Name = "contextNewForFolder";
			this.contextNewForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextNewForFolder.Text = "New";
			this.contextSessionForFolder.Name = "contextSessionForFolder";
			this.contextSessionForFolder.Size = new System.Drawing.Size(113, 22);
			this.contextSessionForFolder.Text = "Session";
			this.contextSessionForFolder.Click += new System.EventHandler(this.contextSessionForFolder_Click);
			this.contextFolderForFolder.Name = "contextFolderForFolder";
			this.contextFolderForFolder.Size = new System.Drawing.Size(113, 22);
			this.contextFolderForFolder.Text = "Folder";
			this.contextFolderForFolder.Click += new System.EventHandler(this.contextFolderForFolder_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(164, 6);
			this.contextConnectAllForFolder.Name = "contextConnectAllForFolder";
			this.contextConnectAllForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextConnectAllForFolder.Text = "Open All Sessions";
			this.contextConnectAllForFolder.Click += new System.EventHandler(this.contextConnectAllForFolder_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
			this.contextCutForFolder.Name = "contextCutForFolder";
			this.contextCutForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextCutForFolder.Text = "Cut";
			this.contextCutForFolder.Click += new System.EventHandler(this.contextCutForFolder_Click);
			this.contextCopyForFolder.Name = "contextCopyForFolder";
			this.contextCopyForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextCopyForFolder.Text = "Copy";
			this.contextCopyForFolder.Click += new System.EventHandler(this.contextCopyForFolder_Click);
			this.contextPasteForFolder.Name = "contextPasteForFolder";
			this.contextPasteForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextPasteForFolder.Text = "Paste";
			this.contextPasteForFolder.Click += new System.EventHandler(this.contextPasteForFolder_Click);
			this.contextDeleteForFolder.Name = "contextDeleteForFolder";
			this.contextDeleteForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextDeleteForFolder.Text = "Delete";
			this.contextDeleteForFolder.Click += new System.EventHandler(this.contextDeleteForFolder_Click);
			this.contextRenameForFolder.Name = "contextRenameForFolder";
			this.contextRenameForFolder.Size = new System.Drawing.Size(167, 22);
			this.contextRenameForFolder.Text = "Rename";
			this.contextRenameForFolder.Click += new System.EventHandler(this.contextRenameForFolder_Click);
			this.contextForSession.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.contextForSession.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.contextForSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.contextConnect,
				this.contextConnectExternal,
				this.contextFTPExternal,
				this.contextSFTPExternal,
				this.toolStripSeparator1,
				this.contextCutForSession,
				this.contextCopyForSession,
				this.contextDeleteForSession,
				this.contextRenameForSession,
				this.toolStripSeparator2,
				this.contextConfigForSession
			});
			this.contextForSession.Name = "contextForSession";
			this.contextForSession.Size = new System.Drawing.Size(192, 232);
			this.contextConnect.Name = "contextConnect";
			this.contextConnect.Size = new System.Drawing.Size(191, 24);
			this.contextConnect.Text = "Open Session";
			this.contextConnect.Click += new System.EventHandler(this.contextConnect_Click);
			this.contextConnectExternal.Name = "contextConnectExternal";
			this.contextConnectExternal.Size = new System.Drawing.Size(191, 24);
			this.contextConnectExternal.Text = "Open Session External";
			this.contextConnectExternal.Click += new System.EventHandler(this.contextConnectExternal_Click);
			this.contextFTPExternal.Name = "contextFTPExternal";
			this.contextFTPExternal.Size = new System.Drawing.Size(191, 24);
			this.contextFTPExternal.Text = "FTP Using WinSCP";
			this.contextFTPExternal.Click += new System.EventHandler(this.contextFTPExternal_Click);
			this.contextSFTPExternal.Name = "contextSFTPExternal";
			this.contextSFTPExternal.Size = new System.Drawing.Size(191, 24);
			this.contextSFTPExternal.Text = "SFTP Using WinSCP";
			this.contextSFTPExternal.Click += new System.EventHandler(this.contextSFTPExternal_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
			this.contextCutForSession.Name = "contextCutForSession";
			this.contextCutForSession.Size = new System.Drawing.Size(191, 24);
			this.contextCutForSession.Text = "Cut";
			this.contextCutForSession.Click += new System.EventHandler(this.contextCutForSession_Click);
			this.contextCopyForSession.Name = "contextCopyForSession";
			this.contextCopyForSession.Size = new System.Drawing.Size(191, 24);
			this.contextCopyForSession.Text = "Copy";
			this.contextCopyForSession.Click += new System.EventHandler(this.contextCopyForSession_Click);
			this.contextDeleteForSession.Name = "contextDeleteForSession";
			this.contextDeleteForSession.Size = new System.Drawing.Size(191, 24);
			this.contextDeleteForSession.Text = "Delete";
			this.contextDeleteForSession.Click += new System.EventHandler(this.contextDeleteForSession_Click);
			this.contextRenameForSession.Name = "contextRenameForSession";
			this.contextRenameForSession.Size = new System.Drawing.Size(191, 24);
			this.contextRenameForSession.Text = "Rename";
			this.contextRenameForSession.Click += new System.EventHandler(this.contextRenameForSession_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
			this.contextConfigForSession.Name = "contextConfigForSession";
			this.contextConfigForSession.Size = new System.Drawing.Size(191, 24);
			this.contextConfigForSession.Text = "Configuration";
			this.contextConfigForSession.Click += new System.EventHandler(this.contextConfigForSession_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			base.ClientSize = new System.Drawing.Size(255, 398);
			base.Controls.Add(this.treeSessions);
			base.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Name = "frmSessionManager";
			this.Text = "Sessions Manager";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSessionManager_FormClosing);
			base.Load += new System.EventHandler(this.frmSessionManager_Load);
			this.contextForDatabase.ResumeLayout(false);
			this.contextForTreeSession.ResumeLayout(false);
			this.contextForFolder.ResumeLayout(false);
			this.contextForSession.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.TreeView treeSessions;

		private System.Windows.Forms.ContextMenuStrip contextForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextNewForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextSessionForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextFolderForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextPropertiesForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextCloseDatabaseForDatabase;

		private System.Windows.Forms.ContextMenuStrip contextForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextNewForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextSessionForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextFolderForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextRenameForFolder;

		private System.Windows.Forms.ContextMenuStrip contextForSession;

		private System.Windows.Forms.ToolStripMenuItem contextConnect;

		private System.Windows.Forms.ToolStripMenuItem contextConnectExternal;

		private System.Windows.Forms.ToolStripMenuItem contextFTPExternal;

		private System.Windows.Forms.ToolStripMenuItem contextSFTPExternal;

		private System.Windows.Forms.ToolStripMenuItem contextRenameForSession;

		private System.Windows.Forms.ContextMenuStrip contextForTreeSession;

		private System.Windows.Forms.ToolStripMenuItem contextOpenDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextConfigForSession;

		private System.Windows.Forms.ImageList imageListSessionManager;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private System.Windows.Forms.ToolStripMenuItem contextCreateDatabase;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		private System.Windows.Forms.ToolStripMenuItem contextCutForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextCopyForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextDeleteForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextCutForSession;

		private System.Windows.Forms.ToolStripMenuItem contextCopyForSession;

		private System.Windows.Forms.ToolStripMenuItem contextDeleteForSession;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private System.Windows.Forms.ToolStripMenuItem contextPasteForFolder;

		private System.Windows.Forms.ToolStripMenuItem contextPasteForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextSaveForDatabase;

		private System.Windows.Forms.ToolStripMenuItem contextSetDefaultForDatabase;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		private System.Windows.Forms.ToolStripMenuItem contextConnectAllForFolder;
	}
}
