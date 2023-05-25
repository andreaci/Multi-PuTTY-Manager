namespace SessionManagement
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextForDocPanel = new System.Windows.Forms.ContextMenuStrip(components);
            closeAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            contextCloseSession = new System.Windows.Forms.ToolStripMenuItem();
            contextDuplicateSession = new System.Windows.Forms.ToolStripMenuItem();
            contextRestartSession = new System.Windows.Forms.ToolStripMenuItem();
            contextRenameForDocPanel = new System.Windows.Forms.ToolStripMenuItem();
            contextChangeSettings = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            contextRunMultiCommands = new System.Windows.Forms.ToolStripMenuItem();
            contextAcceptGlobalCommand = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            contextEventLog = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            contextFTPExternal = new System.Windows.Forms.ToolStripMenuItem();
            contextSFTPExternal = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            contextCopyClipboard = new System.Windows.Forms.ToolStripMenuItem();
            contextClearScollback = new System.Windows.Forms.ToolStripMenuItem();
            contextResetTerminal = new System.Windows.Forms.ToolStripMenuItem();
            contextResetAndClear = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            mnuMain = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnuFileNewDatabase = new System.Windows.Forms.ToolStripMenuItem();
            mnuFileOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            mnuSaveAllDatabases = new System.Windows.Forms.ToolStripMenuItem();
            mnufileImportDatabase = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            mnuFileCloseAllSessions = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewToolbars = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewToolbarsQuickConnection = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewToolbarsMSC = new System.Windows.Forms.ToolStripMenuItem();
            mnuViewToolbarsStatus = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            mnuViewSessionManager = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnuToolsPuTTYSessions = new System.Windows.Forms.ToolStripMenuItem();
            mnuToolsPuttyConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mnuToolsOption = new System.Windows.Forms.ToolStripMenuItem();
            toolStripGlobalCommand = new System.Windows.Forms.ToolStrip();
            toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            toolStripGlobalCommandCommand = new System.Windows.Forms.ToolStripComboBox();
            toolStripGlobalCommandSession = new System.Windows.Forms.ToolStripSplitButton();
            toolStripCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            toolStripUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripGlobalCommandRun = new System.Windows.Forms.ToolStripButton();
            toolStripSeparatorStatus = new System.Windows.Forms.ToolStripSeparator();
            toolStripGlobalCommandStatus = new System.Windows.Forms.ToolStripLabel();
            toolStripGlobalCommandStopMultiCommands = new System.Windows.Forms.ToolStripButton();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            toolStripQuickConnect = new System.Windows.Forms.ToolStrip();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            toolStripQuickConnectProtocol = new System.Windows.Forms.ToolStripComboBox();
            toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            toolStripQuickConnectHost = new System.Windows.Forms.ToolStripComboBox();
            toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            toolStripQuickConnetUserName = new System.Windows.Forms.ToolStripTextBox();
            toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            toolStripQuickConnectPassword = new System.Windows.Forms.ToolStripTextBox();
            toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            toolStripQuickConnecSessionConfig = new System.Windows.Forms.ToolStripComboBox();
            toolStripQuickConnectConnect = new System.Windows.Forms.ToolStripButton();
            statusBar = new System.Windows.Forms.StatusStrip();
            statusBarStatus = new System.Windows.Forms.ToolStripStatusLabel();
            dockPanelMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            contextForDocPanel.SuspendLayout();
            mnuMain.SuspendLayout();
            toolStripGlobalCommand.SuspendLayout();
            toolStripQuickConnect.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // contextForDocPanel
            // 
            contextForDocPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            contextForDocPanel.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextForDocPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { closeAllButThis, contextCloseSession, contextDuplicateSession, contextRestartSession, contextRenameForDocPanel, contextChangeSettings, toolStripSeparator3, contextRunMultiCommands, contextAcceptGlobalCommand, toolStripSeparator9, contextEventLog, toolStripSeparator6, contextFTPExternal, contextSFTPExternal, toolStripSeparator7, contextCopyClipboard, contextClearScollback, contextResetTerminal, contextResetAndClear, toolStripSeparator8 });
            contextForDocPanel.Name = "contextForDocPanel";
            contextForDocPanel.Size = new System.Drawing.Size(261, 364);
            contextForDocPanel.Opening += contextForDocPanel_Opening;
            // 
            // closeAllButThis
            // 
            closeAllButThis.Name = "closeAllButThis";
            closeAllButThis.Size = new System.Drawing.Size(260, 22);
            closeAllButThis.Text = "Close All But This";
            closeAllButThis.Click += toolStripMenuItem1_Click;
            // 
            // contextCloseSession
            // 
            contextCloseSession.Name = "contextCloseSession";
            contextCloseSession.Size = new System.Drawing.Size(260, 22);
            contextCloseSession.Text = "&Close";
            contextCloseSession.Click += contextCloseSession_Click;
            // 
            // contextDuplicateSession
            // 
            contextDuplicateSession.Name = "contextDuplicateSession";
            contextDuplicateSession.Size = new System.Drawing.Size(260, 22);
            contextDuplicateSession.Text = "Clone Session";
            contextDuplicateSession.Click += contextDuplicateSession_Click;
            // 
            // contextRestartSession
            // 
            contextRestartSession.Name = "contextRestartSession";
            contextRestartSession.Size = new System.Drawing.Size(260, 22);
            contextRestartSession.Text = "Restart Session";
            contextRestartSession.Click += contextRestartSession_Click;
            // 
            // contextRenameForDocPanel
            // 
            contextRenameForDocPanel.Name = "contextRenameForDocPanel";
            contextRenameForDocPanel.Size = new System.Drawing.Size(260, 22);
            contextRenameForDocPanel.Text = "Rename Tab";
            contextRenameForDocPanel.Click += contextRenameForDocPanel_Click;
            // 
            // contextChangeSettings
            // 
            contextChangeSettings.Name = "contextChangeSettings";
            contextChangeSettings.Size = new System.Drawing.Size(260, 22);
            contextChangeSettings.Text = "Change Settings...";
            contextChangeSettings.Click += contextChangeSettings_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(257, 6);
            // 
            // contextRunMultiCommands
            // 
            contextRunMultiCommands.Name = "contextRunMultiCommands";
            contextRunMultiCommands.Size = new System.Drawing.Size(260, 22);
            contextRunMultiCommands.Text = "Run Multi Commands";
            contextRunMultiCommands.Click += contextRunMultiCommands_Click;
            // 
            // contextAcceptGlobalCommand
            // 
            contextAcceptGlobalCommand.CheckOnClick = true;
            contextAcceptGlobalCommand.Name = "contextAcceptGlobalCommand";
            contextAcceptGlobalCommand.Size = new System.Drawing.Size(260, 22);
            contextAcceptGlobalCommand.Text = "Accept Multi Sessions Command";
            contextAcceptGlobalCommand.Click += contextAcceptGlobalCommand_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(257, 6);
            // 
            // contextEventLog
            // 
            contextEventLog.Name = "contextEventLog";
            contextEventLog.Size = new System.Drawing.Size(260, 22);
            contextEventLog.Text = "PuTTY Event Log";
            contextEventLog.Click += contextEventLog_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(257, 6);
            // 
            // contextFTPExternal
            // 
            contextFTPExternal.Name = "contextFTPExternal";
            contextFTPExternal.Size = new System.Drawing.Size(260, 22);
            contextFTPExternal.Text = "FTP Using WinSCP";
            contextFTPExternal.Click += contextFTPExternal_Click;
            // 
            // contextSFTPExternal
            // 
            contextSFTPExternal.Name = "contextSFTPExternal";
            contextSFTPExternal.Size = new System.Drawing.Size(260, 22);
            contextSFTPExternal.Text = "SFTP Using WinSCP";
            contextSFTPExternal.Click += contextSFTPExternal_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(257, 6);
            // 
            // contextCopyClipboard
            // 
            contextCopyClipboard.Name = "contextCopyClipboard";
            contextCopyClipboard.Size = new System.Drawing.Size(260, 22);
            contextCopyClipboard.Text = "Copy All to Clipboard";
            contextCopyClipboard.Click += contextCopyClipboard_Click;
            // 
            // contextClearScollback
            // 
            contextClearScollback.Name = "contextClearScollback";
            contextClearScollback.Size = new System.Drawing.Size(260, 22);
            contextClearScollback.Text = "Clear Scrollback";
            contextClearScollback.Click += contextClearScollback_Click;
            // 
            // contextResetTerminal
            // 
            contextResetTerminal.Name = "contextResetTerminal";
            contextResetTerminal.Size = new System.Drawing.Size(260, 22);
            contextResetTerminal.Text = "Reset Terminal";
            contextResetTerminal.Click += contextResetTerminal_Click;
            // 
            // contextResetAndClear
            // 
            contextResetAndClear.Name = "contextResetAndClear";
            contextResetAndClear.Size = new System.Drawing.Size(260, 22);
            contextResetAndClear.Text = "Reset Terminal and Clear Scrollback";
            contextResetAndClear.Click += contextResetAndClear_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(257, 6);
            // 
            // mnuMain
            // 
            mnuMain.BackColor = System.Drawing.SystemColors.Control;
            mnuMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem });
            mnuMain.Location = new System.Drawing.Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            mnuMain.Size = new System.Drawing.Size(1187, 25);
            mnuMain.TabIndex = 7;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuFileNewDatabase, mnuFileOpenDatabase, mnuSaveAllDatabases, mnufileImportDatabase, toolStripSeparator11, mnuFileCloseAllSessions, toolStripSeparator10, mnuFileExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.MouseEnter += fileToolStripMenuItem_MouseEnter;
            // 
            // mnuFileNewDatabase
            // 
            mnuFileNewDatabase.Image = Properties.Resources.New;
            mnuFileNewDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuFileNewDatabase.Name = "mnuFileNewDatabase";
            mnuFileNewDatabase.Size = new System.Drawing.Size(235, 22);
            mnuFileNewDatabase.Text = "New database";
            mnuFileNewDatabase.Click += mnuFileNewDatabase_Click;
            // 
            // mnuFileOpenDatabase
            // 
            mnuFileOpenDatabase.Image = Properties.Resources.OpenFile;
            mnuFileOpenDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuFileOpenDatabase.Name = "mnuFileOpenDatabase";
            mnuFileOpenDatabase.Size = new System.Drawing.Size(235, 22);
            mnuFileOpenDatabase.Text = "Open database";
            mnuFileOpenDatabase.Click += mnuFileOpenDatabase_Click;
            // 
            // mnuSaveAllDatabases
            // 
            mnuSaveAllDatabases.Image = Properties.Resources.SaveAll;
            mnuSaveAllDatabases.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuSaveAllDatabases.Name = "mnuSaveAllDatabases";
            mnuSaveAllDatabases.Size = new System.Drawing.Size(235, 22);
            mnuSaveAllDatabases.Text = "Save all databases";
            mnuSaveAllDatabases.Click += mnuSaveAllDatabases_Click;
            // 
            // mnufileImportDatabase
            // 
            mnufileImportDatabase.Image = Properties.Resources.XMLTransformation;
            mnufileImportDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnufileImportDatabase.Name = "mnufileImportDatabase";
            mnufileImportDatabase.Size = new System.Drawing.Size(235, 22);
            mnufileImportDatabase.Text = "Import database from XML file";
            mnufileImportDatabase.Click += mnufileImportDatabase_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuFileCloseAllSessions
            // 
            mnuFileCloseAllSessions.Image = Properties.Resources.CloseAll;
            mnuFileCloseAllSessions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuFileCloseAllSessions.Name = "mnuFileCloseAllSessions";
            mnuFileCloseAllSessions.Size = new System.Drawing.Size(235, 22);
            mnuFileCloseAllSessions.Text = "Close all sessions";
            mnuFileCloseAllSessions.Click += mnuFileCloseAllSessions_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new System.Drawing.Size(235, 22);
            mnuFileExit.Text = "Exit";
            mnuFileExit.Click += mnuFileExit_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuViewToolbars, toolStripSeparator5, mnuViewSessionManager });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.MouseEnter += viewToolStripMenuItem_MouseEnter;
            // 
            // mnuViewToolbars
            // 
            mnuViewToolbars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuViewToolbarsQuickConnection, mnuViewToolbarsMSC, mnuViewToolbarsStatus });
            mnuViewToolbars.Name = "mnuViewToolbars";
            mnuViewToolbars.Size = new System.Drawing.Size(168, 22);
            mnuViewToolbars.Text = "Toolbars";
            // 
            // mnuViewToolbarsQuickConnection
            // 
            mnuViewToolbarsQuickConnection.Checked = true;
            mnuViewToolbarsQuickConnection.CheckOnClick = true;
            mnuViewToolbarsQuickConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            mnuViewToolbarsQuickConnection.Name = "mnuViewToolbarsQuickConnection";
            mnuViewToolbarsQuickConnection.Size = new System.Drawing.Size(209, 22);
            mnuViewToolbarsQuickConnection.Text = "Quick Session";
            mnuViewToolbarsQuickConnection.Click += mnuViewToolbarsQuickConnection_Click;
            // 
            // mnuViewToolbarsMSC
            // 
            mnuViewToolbarsMSC.Checked = true;
            mnuViewToolbarsMSC.CheckOnClick = true;
            mnuViewToolbarsMSC.CheckState = System.Windows.Forms.CheckState.Checked;
            mnuViewToolbarsMSC.Name = "mnuViewToolbarsMSC";
            mnuViewToolbarsMSC.Size = new System.Drawing.Size(209, 22);
            mnuViewToolbarsMSC.Text = "Multi Sessions Command";
            mnuViewToolbarsMSC.Click += mnuViewToolbarsMSC_Click;
            // 
            // mnuViewToolbarsStatus
            // 
            mnuViewToolbarsStatus.Checked = true;
            mnuViewToolbarsStatus.CheckOnClick = true;
            mnuViewToolbarsStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            mnuViewToolbarsStatus.Name = "mnuViewToolbarsStatus";
            mnuViewToolbarsStatus.Size = new System.Drawing.Size(209, 22);
            mnuViewToolbarsStatus.Text = "Status";
            mnuViewToolbarsStatus.Visible = false;
            mnuViewToolbarsStatus.Click += mnuViewToolbarsStatus_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuViewSessionManager
            // 
            mnuViewSessionManager.Checked = true;
            mnuViewSessionManager.CheckOnClick = true;
            mnuViewSessionManager.CheckState = System.Windows.Forms.CheckState.Checked;
            mnuViewSessionManager.Name = "mnuViewSessionManager";
            mnuViewSessionManager.Size = new System.Drawing.Size(168, 22);
            mnuViewSessionManager.Text = "Sessions Manager";
            mnuViewSessionManager.Click += mnuViewSessionManager_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuToolsPuTTYSessions, mnuToolsPuttyConfiguration, toolStripSeparator1, mnuToolsOption });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            toolsToolStripMenuItem.Text = "Tools";
            toolsToolStripMenuItem.MouseEnter += toolsToolStripMenuItem_MouseEnter;
            // 
            // mnuToolsPuTTYSessions
            // 
            mnuToolsPuTTYSessions.Name = "mnuToolsPuTTYSessions";
            mnuToolsPuTTYSessions.Size = new System.Drawing.Size(184, 22);
            mnuToolsPuTTYSessions.Text = "PuTTY Sessions";
            mnuToolsPuTTYSessions.Click += mnuToolsPuTTYSessions_Click;
            // 
            // mnuToolsPuttyConfiguration
            // 
            mnuToolsPuttyConfiguration.Image = Properties.Resources.ConfigurationEditor;
            mnuToolsPuttyConfiguration.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuToolsPuttyConfiguration.Name = "mnuToolsPuttyConfiguration";
            mnuToolsPuttyConfiguration.Size = new System.Drawing.Size(184, 22);
            mnuToolsPuttyConfiguration.Text = "PuTTY Configuration";
            mnuToolsPuttyConfiguration.Click += mnuToolPuttyConfiguration_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuToolsOption
            // 
            mnuToolsOption.Image = Properties.Resources.Settings;
            mnuToolsOption.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            mnuToolsOption.Name = "mnuToolsOption";
            mnuToolsOption.Size = new System.Drawing.Size(184, 22);
            mnuToolsOption.Text = "Options...";
            mnuToolsOption.Click += mnuToolsOption_Click;
            // 
            // toolStripGlobalCommand
            // 
            toolStripGlobalCommand.BackColor = System.Drawing.SystemColors.Control;
            toolStripGlobalCommand.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolStripGlobalCommand.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripGlobalCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel7, toolStripGlobalCommandCommand, toolStripGlobalCommandSession, toolStripGlobalCommandRun, toolStripSeparatorStatus, toolStripGlobalCommandStatus, toolStripGlobalCommandStopMultiCommands, toolStripButton1 });
            toolStripGlobalCommand.Location = new System.Drawing.Point(0, 50);
            toolStripGlobalCommand.Name = "toolStripGlobalCommand";
            toolStripGlobalCommand.Size = new System.Drawing.Size(1187, 25);
            toolStripGlobalCommand.TabIndex = 16;
            toolStripGlobalCommand.Text = "toolStrip1";
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Image = Properties.Resources.CommentCode;
            toolStripLabel7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new System.Drawing.Size(158, 22);
            toolStripLabel7.Text = "Multi Sessions Command";
            // 
            // toolStripGlobalCommandCommand
            // 
            toolStripGlobalCommandCommand.Name = "toolStripGlobalCommandCommand";
            toolStripGlobalCommandCommand.Size = new System.Drawing.Size(400, 25);
            toolStripGlobalCommandCommand.KeyPress += toolStripGlobalCommandCommand_KeyPress;
            toolStripGlobalCommandCommand.MouseEnter += QuickOpenConnectionMenuFocus;
            // 
            // toolStripGlobalCommandSession
            // 
            toolStripGlobalCommandSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            toolStripGlobalCommandSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripCheckAll, toolStripUncheckAll, toolStripSeparator2 });
            toolStripGlobalCommandSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripGlobalCommandSession.Name = "toolStripGlobalCommandSession";
            toolStripGlobalCommandSession.Size = new System.Drawing.Size(67, 22);
            toolStripGlobalCommandSession.Text = "Sessions";
            toolStripGlobalCommandSession.ButtonClick += toolStripGlobalCommandSession_ButtonClick;
            toolStripGlobalCommandSession.MouseEnter += QuickOpenConnectionMenuFocus;
            // 
            // toolStripCheckAll
            // 
            toolStripCheckAll.Name = "toolStripCheckAll";
            toolStripCheckAll.Size = new System.Drawing.Size(135, 22);
            toolStripCheckAll.Text = "All Sessions";
            toolStripCheckAll.Click += toolStripCheckAll_Click;
            // 
            // toolStripUncheckAll
            // 
            toolStripUncheckAll.Name = "toolStripUncheckAll";
            toolStripUncheckAll.Size = new System.Drawing.Size(135, 22);
            toolStripUncheckAll.Text = "None";
            toolStripUncheckAll.Click += toolStripUncheckAll_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // toolStripGlobalCommandRun
            // 
            toolStripGlobalCommandRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripGlobalCommandRun.Image = Properties.Resources.Play;
            toolStripGlobalCommandRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripGlobalCommandRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripGlobalCommandRun.Name = "toolStripGlobalCommandRun";
            toolStripGlobalCommandRun.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            toolStripGlobalCommandRun.Size = new System.Drawing.Size(40, 22);
            toolStripGlobalCommandRun.ToolTipText = "Run Command";
            toolStripGlobalCommandRun.Click += toolStripGlobalCommandRun_Click;
            toolStripGlobalCommandRun.MouseEnter += toolStripGlobalCommandRun_MouseEnter;
            // 
            // toolStripSeparatorStatus
            // 
            toolStripSeparatorStatus.Name = "toolStripSeparatorStatus";
            toolStripSeparatorStatus.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripGlobalCommandStatus
            // 
            toolStripGlobalCommandStatus.Image = Properties.Resources.Statistics;
            toolStripGlobalCommandStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripGlobalCommandStatus.Name = "toolStripGlobalCommandStatus";
            toolStripGlobalCommandStatus.Size = new System.Drawing.Size(55, 22);
            toolStripGlobalCommandStatus.Text = "Status";
            // 
            // toolStripGlobalCommandStopMultiCommands
            // 
            toolStripGlobalCommandStopMultiCommands.Image = Properties.Resources.StopOutline;
            toolStripGlobalCommandStopMultiCommands.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripGlobalCommandStopMultiCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripGlobalCommandStopMultiCommands.Name = "toolStripGlobalCommandStopMultiCommands";
            toolStripGlobalCommandStopMultiCommands.Size = new System.Drawing.Size(147, 22);
            toolStripGlobalCommandStopMultiCommands.Text = "Stop Multi Commands";
            toolStripGlobalCommandStopMultiCommands.Click += toolStripGlobalCommandStopMultiCommands_Click;
            toolStripGlobalCommandStopMultiCommands.MouseEnter += toolStripGlobalCommandStopMultiCommands_MouseEnter;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.CloseAll;
            toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(117, 22);
            toolStripButton1.Text = "Close all sessions";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripQuickConnect
            // 
            toolStripQuickConnect.BackColor = System.Drawing.SystemColors.Control;
            toolStripQuickConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolStripQuickConnect.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripQuickConnect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel2, toolStripQuickConnectProtocol, toolStripLabel3, toolStripQuickConnectHost, toolStripLabel4, toolStripQuickConnetUserName, toolStripLabel5, toolStripQuickConnectPassword, toolStripLabel6, toolStripQuickConnecSessionConfig, toolStripQuickConnectConnect });
            toolStripQuickConnect.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStripQuickConnect.Location = new System.Drawing.Point(0, 25);
            toolStripQuickConnect.Name = "toolStripQuickConnect";
            toolStripQuickConnect.Size = new System.Drawing.Size(1187, 25);
            toolStripQuickConnect.TabIndex = 15;
            toolStripQuickConnect.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(52, 22);
            toolStripLabel2.Text = "Protocol";
            // 
            // toolStripQuickConnectProtocol
            // 
            toolStripQuickConnectProtocol.BackColor = System.Drawing.SystemColors.Window;
            toolStripQuickConnectProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripQuickConnectProtocol.Items.AddRange(new object[] { "Telnet", "SSH", "Raw", "RLogin" });
            toolStripQuickConnectProtocol.Name = "toolStripQuickConnectProtocol";
            toolStripQuickConnectProtocol.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            toolStripLabel3.Size = new System.Drawing.Size(52, 22);
            toolStripLabel3.Text = "Host";
            // 
            // toolStripQuickConnectHost
            // 
            toolStripQuickConnectHost.Name = "toolStripQuickConnectHost";
            toolStripQuickConnectHost.Size = new System.Drawing.Size(140, 25);
            toolStripQuickConnectHost.KeyPress += QuickOpenConnectionMenu;
            toolStripQuickConnectHost.MouseEnter += QuickOpenConnectionMenuFocus;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            toolStripLabel4.Size = new System.Drawing.Size(71, 22);
            toolStripLabel4.Text = "Login as";
            // 
            // toolStripQuickConnetUserName
            // 
            toolStripQuickConnetUserName.BackColor = System.Drawing.SystemColors.Window;
            toolStripQuickConnetUserName.Name = "toolStripQuickConnetUserName";
            toolStripQuickConnetUserName.Size = new System.Drawing.Size(100, 25);
            toolStripQuickConnetUserName.KeyPress += QuickOpenConnectionMenu;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            toolStripLabel5.Size = new System.Drawing.Size(77, 22);
            toolStripLabel5.Text = "Password";
            // 
            // toolStripQuickConnectPassword
            // 
            toolStripQuickConnectPassword.BackColor = System.Drawing.SystemColors.Window;
            toolStripQuickConnectPassword.Name = "toolStripQuickConnectPassword";
            toolStripQuickConnectPassword.Size = new System.Drawing.Size(100, 25);
            toolStripQuickConnectPassword.KeyPress += QuickOpenConnectionMenu;
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            toolStripLabel6.Size = new System.Drawing.Size(100, 22);
            toolStripLabel6.Text = "PuTTY Setting";
            // 
            // toolStripQuickConnecSessionConfig
            // 
            toolStripQuickConnecSessionConfig.BackColor = System.Drawing.SystemColors.Window;
            toolStripQuickConnecSessionConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripQuickConnecSessionConfig.Items.AddRange(new object[] { "Default Settings" });
            toolStripQuickConnecSessionConfig.MaxDropDownItems = 100;
            toolStripQuickConnecSessionConfig.Name = "toolStripQuickConnecSessionConfig";
            toolStripQuickConnecSessionConfig.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripQuickConnectConnect
            // 
            toolStripQuickConnectConnect.Image = Properties.Resources.ConnectToRemoteServer;
            toolStripQuickConnectConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripQuickConnectConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripQuickConnectConnect.Name = "toolStripQuickConnectConnect";
            toolStripQuickConnectConnect.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            toolStripQuickConnectConnect.Size = new System.Drawing.Size(92, 22);
            toolStripQuickConnectConnect.Text = "Connect";
            toolStripQuickConnectConnect.ToolTipText = "Open Session";
            toolStripQuickConnectConnect.Click += toolStripQuickConnectConnect_Click;
            toolStripQuickConnectConnect.MouseEnter += toolStripQuickConnectConnect_MouseEnter;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusBarStatus });
            statusBar.Location = new System.Drawing.Point(0, 529);
            statusBar.Name = "statusBar";
            statusBar.Size = new System.Drawing.Size(1187, 22);
            statusBar.TabIndex = 20;
            statusBar.Text = "statusStrip1";
            // 
            // statusBarStatus
            // 
            statusBarStatus.Name = "statusBarStatus";
            statusBarStatus.Size = new System.Drawing.Size(39, 17);
            statusBarStatus.Text = "Status";
            // 
            // dockPanelMain
            // 
            dockPanelMain.BackColor = System.Drawing.Color.Lavender;
            dockPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanelMain.DockBackColor = System.Drawing.SystemColors.ControlLight;
            dockPanelMain.DockLeftPortion = 0.22D;
            dockPanelMain.DockRightPortion = 0.22D;
            dockPanelMain.Location = new System.Drawing.Point(0, 75);
            dockPanelMain.Margin = new System.Windows.Forms.Padding(4);
            dockPanelMain.Name = "dockPanelMain";
            dockPanelMain.Size = new System.Drawing.Size(1187, 454);
            dockPanelMain.TabIndex = 21;
            dockPanelMain.ActiveDocumentChanged += dockPanelMain_ActiveDocumentChanged;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1187, 551);
            Controls.Add(dockPanelMain);
            Controls.Add(statusBar);
            Controls.Add(toolStripGlobalCommand);
            Controls.Add(toolStripQuickConnect);
            Controls.Add(mnuMain);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IsMdiContainer = true;
            MainMenuStrip = mnuMain;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmMain";
            Text = "Multi PuTTY Manager";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Activated += frmMain_Activated;
            Deactivate += frmMain_Deactivate;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            contextForDocPanel.ResumeLayout(false);
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            toolStripGlobalCommand.ResumeLayout(false);
            toolStripGlobalCommand.PerformLayout();
            toolStripQuickConnect.ResumeLayout(false);
            toolStripQuickConnect.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mnuMain;

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextForDocPanel;

        private System.Windows.Forms.ToolStripMenuItem contextRenameForDocPanel;

        private System.Windows.Forms.ToolStripMenuItem contextSFTPExternal;

        private System.Windows.Forms.ToolStripMenuItem contextFTPExternal;

        private System.Windows.Forms.ToolStripMenuItem contextDuplicateSession;

        private System.Windows.Forms.ToolStrip toolStripGlobalCommand;

        private System.Windows.Forms.ToolStripLabel toolStripLabel2;

        private System.Windows.Forms.ToolStripComboBox toolStripQuickConnectProtocol;

        private System.Windows.Forms.ToolStripLabel toolStripLabel3;

        private System.Windows.Forms.ToolStripLabel toolStripLabel4;

        private System.Windows.Forms.ToolStripTextBox toolStripQuickConnetUserName;

        private System.Windows.Forms.ToolStripLabel toolStripLabel5;

        private System.Windows.Forms.ToolStripTextBox toolStripQuickConnectPassword;

        private System.Windows.Forms.ToolStripLabel toolStripLabel6;

        private System.Windows.Forms.ToolStripComboBox toolStripQuickConnecSessionConfig;

        private System.Windows.Forms.ToolStripButton toolStripQuickConnectConnect;

        private System.Windows.Forms.ToolStripLabel toolStripLabel7;

        private System.Windows.Forms.ToolStripButton toolStripGlobalCommandRun;

        private System.Windows.Forms.ToolStrip toolStripQuickConnect;

        private System.Windows.Forms.ToolStripMenuItem contextCloseSession;

        private System.Windows.Forms.ToolStripSplitButton toolStripGlobalCommandSession;

        private System.Windows.Forms.ToolStripMenuItem toolStripCheckAll;

        private System.Windows.Forms.ToolStripMenuItem toolStripUncheckAll;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        private System.Windows.Forms.ToolStripMenuItem mnuViewSessionManager;

        private System.Windows.Forms.ToolStripMenuItem mnuToolsPuttyConfiguration;

        private System.Windows.Forms.ToolStripMenuItem mnuToolsOption;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private System.Windows.Forms.StatusStrip statusBar;

        private System.Windows.Forms.ToolStripStatusLabel statusBarStatus;

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelMain;

        private System.Windows.Forms.ToolStripMenuItem mnuViewToolbars;


        private System.Windows.Forms.ToolStripMenuItem mnuViewToolbarsQuickConnection;

        private System.Windows.Forms.ToolStripMenuItem mnuViewToolbarsMSC;

        private System.Windows.Forms.ToolStripMenuItem mnuViewToolbarsStatus;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

        private System.Windows.Forms.ToolStripComboBox toolStripGlobalCommandCommand;

        private System.Windows.Forms.ToolStripComboBox toolStripQuickConnectHost;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;

        private System.Windows.Forms.ToolStripMenuItem contextChangeSettings;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;

        private System.Windows.Forms.ToolStripMenuItem contextEventLog;

        private System.Windows.Forms.ToolStripMenuItem contextCopyClipboard;

        private System.Windows.Forms.ToolStripMenuItem contextClearScollback;

        private System.Windows.Forms.ToolStripMenuItem contextResetTerminal;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;

        private System.Windows.Forms.ToolStripMenuItem contextResetAndClear;

        private System.Windows.Forms.ToolStripMenuItem mnuFileNewDatabase;

        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenDatabase;

        private System.Windows.Forms.ToolStripMenuItem mnuSaveAllDatabases;

        private System.Windows.Forms.ToolStripMenuItem mnufileImportDatabase;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;

        private System.Windows.Forms.ToolStripMenuItem mnuFileCloseAllSessions;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;

        private System.Windows.Forms.ToolStripMenuItem mnuToolsPuTTYSessions;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorStatus;

        private System.Windows.Forms.ToolStripLabel toolStripGlobalCommandStatus;

        private System.Windows.Forms.ToolStripMenuItem contextAcceptGlobalCommand;

        private System.Windows.Forms.ToolStripButton toolStripGlobalCommandStopMultiCommands;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

        private System.Windows.Forms.ToolStripMenuItem contextRunMultiCommands;

        private System.Windows.Forms.ToolStripMenuItem contextRestartSession;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThis;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
