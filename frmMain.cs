using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SessionManagement
{
    public partial class frmMain : Form
    {

        SettingsData CurrentApplicationSettings = SettingsData.Instance;

        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        public frmMain()
        {
            this.InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Global.AvailableSessions = new List<Session>();

            try
            {
                this.fmSessionManager = new frmSessionManager
                {
                    openSession = new frmSessionManager.OpenSession(this.openSession),
                    hideSessionManager = new frmSessionManager.HideSessionManager(this.HideSessionManager),
                    openExtraSession = new frmSessionManager.OpenExtraSession(OpenExtraSession),
                    displayStatus = new frmSessionManager.DisplayStatus(this.DisplayStatus)
                };

                this.displaySessionManager();
                this.toolStripQuickConnectPassword.TextBox.PasswordChar = '*';
                this.checkItemsStatusAndDisplay();

                for (int i = 0; i < CurrentApplicationSettings.PuttySessionsList.Count; i++)
                {
                    PuttySession puttySession = CurrentApplicationSettings.PuttySessionsList[i];
                    if (puttySession.SessionHost == "")
                    {
                        this.toolStripQuickConnecSessionConfig.Items.Add(puttySession.SessionName);
                    }
                }

                if (CurrentApplicationSettings.QuickPuttySetting.Trim() != "")
                    this.toolStripQuickConnecSessionConfig.Text = CurrentApplicationSettings.QuickPuttySetting;
                else
                    this.toolStripQuickConnecSessionConfig.Text = "Default Settings";

                if (CurrentApplicationSettings.QuickPuttyProtocol.Trim() != "")
                    this.toolStripQuickConnectProtocol.Text = CurrentApplicationSettings.QuickPuttyProtocol;
                else
                    this.toolStripQuickConnectProtocol.Text = "SSH";

                this.toolStripGlobalCommandStatus.Text = "";
                this.disableWhenNoActiveSession();
                this.hook.KeyPressed += this.hook_KeyPressed;
                this.hook.RegisterHotKey(SessionManagement.ModifierKeys.Control, Keys.Tab);
                this.hook.RegisterHotKey(SessionManagement.ModifierKeys.Control | SessionManagement.ModifierKeys.Shift, Keys.Tab);
            }
            catch //(Exception ex)
            {
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                int num = this.indexOfActiveTab();
                if (!this.formActivate && num != -1)
                {
                    this.switchBackPreviousTab(num);
                    this.switchToNextTab(num - 1);
                }
                this.formActivate = true;
            }
            catch //(Exception ex)
            {
            }
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            this.formActivate = false;
            base.Focus();
        }

        private void switchToNextTab(int currentIndex)
        {
            int num = this.dockPanelMain.Documents.Count<IDockContent>();
            if (num > 1)
            {
                int num2 = currentIndex + 1;
                if (num2 >= num)
                    num2 = 0;

                try
                {
                    frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(num2) as frmPutty;
                    frmPutty.Show(this.dockPanelMain, DockState.Document);
                }
                catch //(Exception ex)
                {
                }
            }
        }

        private void switchBackPreviousTab(int currentIndex)
        {
            int num = this.dockPanelMain.Documents.Count<IDockContent>();
            if (num > 1)
            {
                int num2 = currentIndex - 1;
                if (num2 < 0)
                    num2 = num - 1;

                try
                {
                    frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(num2) as frmPutty;
                    frmPutty.Show(this.dockPanelMain, DockState.Document);
                }
                catch //(Exception ex)
                {
                }
            }
        }

        private int indexOfActiveTab()
        {
            int result;
            try
            {
                int num = this.dockPanelMain.Documents.Count<IDockContent>();
                if (num == 0)
                    result = -1;
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        if (this.dockPanelMain.Documents.ElementAt(i) == this.dockPanelMain.ActiveDocument)
                            return i;
                    }
                    result = -1;
                }
            }
            catch //(Exception ex)
            {
                result = -1;
            }
            return result;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            try
            {
                if (this.dockPanelMain.Documents.Count<IDockContent>() > 1)
                {
                    if (!this.formActivate)
                    {
                        frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                        if (frmPutty != null)
                        {
                            IntPtr foregroundWindow = frmMain.GetForegroundWindow();
                            if (frmPutty.proc.MainWindowHandle == foregroundWindow)
                                this.formActivate = true;
                        }
                    }
                    if (this.formActivate)
                    {
                        int currentIndex = this.indexOfActiveTab();
                        if (e.Modifier == SessionManagement.ModifierKeys.Control && e.Key == Keys.Tab)
                            this.switchToNextTab(currentIndex);
                        else if (e.Modifier == (SessionManagement.ModifierKeys.Control | SessionManagement.ModifierKeys.Shift) && e.Key == Keys.Tab)
                            this.switchBackPreviousTab(currentIndex);
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        public void DisplayStatus(string status)
        {
            statusBarStatus.Text = status;
        }

        public void HideSessionManager() => mnuViewSessionManager.Checked = false;

        public void closeSession(Session sess, string puttyName)
        {
            try
            {
                this.removePuttySessionFromGlobalCommandSessions(puttyName);
                this.displayStatusOfGlobalCommandSessions();
                if (this.dockPanelMain.DocumentsCount <= 1)
                {
                    this.dockPanelMain.ContextMenuStrip = null;
                    this.disableWhenNoActiveSession();
                }
                else
                {
                    int num = this.indexOfActiveTab();
                    if (num < this.dockPanelMain.DocumentsCount - 1)
                        this.switchToNextTab(num);
                    else
                        this.switchBackPreviousTab(num);
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextRenameForDocPanel_Click(object sender, EventArgs e)
        {
            frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
            if (frmPutty != null)
            {
                string text = frmPutty.Text;
                if (Global.InputBox("Rename Tab", "New name", ref text) == DialogResult.OK)
                {
                    if (text != "")
                    {
                        frmPutty.Text = text;
                        this.toolStripGlobalCommandSession.DropDownItems[frmPutty.Handle.ToString()].Text = text;
                    }
                }
            }
        }

        private void contextSFTPExternal_Click(object sender, EventArgs e)
        {
            frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
            OpenExtraSession(frmPutty.session, "sftp");
        }

        public void OpenExtraSession(Session sess, string type)
        {
            try
            {
                if (!File.Exists(CurrentApplicationSettings.WinSCPLocation))
                {
                    MessageBox.Show("WinScP.exe file does not exist.  Go to Tools -> Options... to configure WinSCP file");
                    return;
                }

                Process process = Process.Start(new ProcessStartInfo(CurrentApplicationSettings.WinSCPLocation)
                {
                    Arguments = $"{type}://{sess.SFTPCredentials.UserName}:{sess.SFTPCredentials.Password}@{sess.SessionHost}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextFTPExternal_Click(object sender, EventArgs e)
        {
            frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
            OpenExtraSession(frmPutty.session, "ftp");
        }

        private void contextDuplicateSession_Click(object sender, EventArgs e)
        {
            this.duplicateActiveSession();
        }

        public void duplicateActiveSession()
        {
            try
            {
                frmPutty frmPutty = new();
                frmPutty.closeSession = new frmPutty.CloseSession(this.closeSession);
                frmPutty frmPutty2 = this.dockPanelMain.ActiveDocument as frmPutty;
                frmPutty.session.copySession(frmPutty2.session);
                frmPutty.openConnection();
                frmPutty.Show(this.dockPanelMain, DockState.Document);
                if (this.dockPanelMain.DocumentsCount > 0)
                {
                    this.dockPanelMain.ContextMenuStrip = this.contextForDocPanel;
                    this.enableWhenHavingActiveSession();
                    this.addPuttySessionToGlobalCommandSessions(frmPutty);
                }
                frmPutty.autoLoginAndRunCommands();
            }
            catch// (Exception ex)
            {
            }
        }

        public void openSession(Session sess)
        {
            if (!File.Exists(CurrentApplicationSettings.PuttyLocation))
            {
                MessageBox.Show("PuTTY.exe file does not exist. Go to Tools -> Options... to configure PuTTY file");
                return;
            }

            try
            {
                frmPutty frmPutty = new(sess, closeSession);
                frmPutty.openConnection();
                frmPutty.Show(this.dockPanelMain, DockState.Document);

                if (this.dockPanelMain.DocumentsCount > 0)
                {
                    this.dockPanelMain.ContextMenuStrip = this.contextForDocPanel;
                    this.enableWhenHavingActiveSession();
                    this.addPuttySessionToGlobalCommandSessions(frmPutty);
                }
                frmPutty.autoLoginAndRunCommands();
            }
            catch //(Exception ex)
            {
            }
        }

        private void toolStripQuickConnectConnect_Click(object sender, EventArgs e)
        {
            if (this.toolStripQuickConnectHost.Text != "")
                this.openQuickConnection();
        }

        public void openQuickConnection()
        {
            if (!File.Exists(CurrentApplicationSettings.PuttyLocation))
            {
                MessageBox.Show("PuTTY.exe file does not exist. Go to Tools -> Options... to configure PuTTY file");
                return;
            }

            try
            {
                if (!(this.toolStripQuickConnectHost.Text == ""))
                {
                    Session session = new()
                    {
                        SessionProtocol = this.toolStripQuickConnectProtocol.Text,
                        SessionHost = this.toolStripQuickConnectHost.Text,
                        SessionCredentials = new BasicCredentials()
                        {
                            UserName = this.toolStripQuickConnetUserName.Text,
                            Password = this.toolStripQuickConnectPassword.Text
                        },
                        SessionConfig = this.toolStripQuickConnecSessionConfig.Text,
                        SessionName = this.toolStripQuickConnectHost.Text
                    };

                    frmPutty frmPutty = new(session, this.closeSession);
                    frmPutty.openConnection();
                    frmPutty.Show(this.dockPanelMain, DockState.Document);

                    if (this.dockPanelMain.DocumentsCount > 0)
                    {
                        this.dockPanelMain.ContextMenuStrip = this.contextForDocPanel;
                        this.enableWhenHavingActiveSession();
                        this.addPuttySessionToGlobalCommandSessions(frmPutty);
                    }
                    this.addHistoryQuickConnectHost();

                    frmPutty.autoLoginAndRunCommands();
                }
            }
            catch //(Exception ex)
            {
            }

        }

        public void addHistoryQuickConnectHost()
        {
            try
            {
                string text = this.toolStripQuickConnectHost.Text;

                int num = this.isTextInItemsList(this.toolStripQuickConnectHost);
                if (num != -1)
                    this.toolStripQuickConnectHost.Items.RemoveAt(num);
                this.toolStripQuickConnectHost.Items.Insert(0, text);

                if (this.toolStripQuickConnectHost.Items.Count > 5)
                    this.toolStripQuickConnectHost.Items.RemoveAt(5);

                this.toolStripQuickConnectHost.Text = text;
            }
            catch// (Exception ex)
            {
            }
        }

        public int isTextInItemsList(ToolStripComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].Equals(comboBox.Text))
                    return i;
            }
            return -1;
        }

        public void addPuttySessionToGlobalCommandSessions(frmPutty fmPutty)
        {
            ToolStripMenuItem toolStripMenuItem = new(fmPutty.Text)
            {
                Name = fmPutty.Handle.ToString(),
                Checked = true,
                CheckOnClick = true,
                CheckState = CheckState.Unchecked
            };
            toolStripMenuItem.Click += this.item_Click;
            this.toolStripGlobalCommandSession.DropDownItems.Add(toolStripMenuItem);
        }

        private void item_Click(object sender, EventArgs e)
        {
            this.displayStatusOfGlobalCommandSessions();
            this.toolStripGlobalCommandSession.ShowDropDown();
        }

        public void removePuttySessionFromGlobalCommandSessions(string puttyName)
        {
            try
            {
                for (int i = 3; i < this.toolStripGlobalCommandSession.DropDownItems.Count; i++)
                {
                    if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).Name == puttyName)
                    {
                        this.toolStripGlobalCommandSession.DropDownItems.RemoveAt(i);
                        break;
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void QuickOpenConnectionMenu(object sender, KeyPressEventArgs e)
        {
            if (toolStripQuickConnectHost.Text != "")
            {
                if (e.KeyChar == '\r')
                    openQuickConnection();
            }
        }

        private void QuickOpenConnectionMenuFocus(object sender, EventArgs e)
        {
            this.toolStripQuickConnect.Focus();
        }

        private void toolStripGlobalCommandSession_ButtonClick(object sender, EventArgs e)
        {
            this.toolStripGlobalCommandSession.ShowDropDown();
        }

        private void toolStripQuickConnectConnect_MouseEnter(object sender, EventArgs e)
        {
            base.Focus();
        }

        private void toolStripGlobalCommandRun_MouseEnter(object sender, EventArgs e)
        {
            base.Focus();
        }

        private void toolStripGlobalCommandStopMultiCommands_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dockPanelMain.Documents.Count<IDockContent>(); i++)
                {
                    frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(i) as frmPutty;
                    frmPutty.stopRunningMultiCommands();
                }
                this.toolStripGlobalCommandStopMultiCommands.Visible = false;
            }
            catch //(Exception ex)
            {
                this.toolStripGlobalCommandStopMultiCommands.Visible = false;
            }
        }

        private void toolStripGlobalCommandStopMultiCommands_MouseEnter(object sender, EventArgs e)
        {
            this.toolStripGlobalCommand.Focus();
        }

        public void displayStatusOfGlobalCommandSessions()
        {
            try
            {
                int count = this.toolStripGlobalCommandSession.DropDownItems.Count;
                this.toolStripSeparatorStatus.Visible = true;
                if (count == 3)
                {
                    this.toolStripGlobalCommandStatus.Text = "No session accepts command";
                    this.toolStripGlobalCommandCommand.Enabled = false;
                    this.toolStripGlobalCommandRun.Enabled = false;
                }
                else
                {
                    int num = 0;
                    for (int i = 3; i < count; i++)
                    {
                        if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState == CheckState.Checked)
                        {
                            num++;
                        }
                    }
                    if (num == 0)
                    {
                        this.toolStripGlobalCommandStatus.Text = "No session accepts command";
                        this.toolStripGlobalCommandCommand.Enabled = false;
                        this.toolStripGlobalCommandRun.Enabled = false;
                    }
                    else if (num == 1)
                    {
                        this.toolStripGlobalCommandStatus.Text = num.ToString() + "/" + (count - 3).ToString() + " session accepts command";
                        this.toolStripGlobalCommandCommand.Enabled = true;
                        this.toolStripGlobalCommandRun.Enabled = true;
                    }
                    else
                    {
                        this.toolStripGlobalCommandStatus.Text = num.ToString() + "/" + (count - 3).ToString() + " sessions accept command";
                        this.toolStripGlobalCommandCommand.Enabled = true;
                        this.toolStripGlobalCommandRun.Enabled = true;
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void toolStripCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < this.toolStripGlobalCommandSession.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState = CheckState.Checked;
            }
            this.displayStatusOfGlobalCommandSessions();
        }

        private void toolStripUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < this.toolStripGlobalCommandSession.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState = CheckState.Unchecked;
            }
            this.displayStatusOfGlobalCommandSessions();
        }

        public void stopMultiCommandsThread(String[] arrCommands)
        {
            try
            {
                string[] array = Array.Empty<String>();
                for (int i = 0; i < arrCommands.Length; i++)
                {
                    if (!this.multiCommandsThread.IsAlive)
                    {
                        break;
                    }
                    array = arrCommands[i].ToString().Split(new char[]
                    {
                        ';'
                    });
                    Thread.Sleep(int.Parse(array[1]));
                }
                this.toolStripGlobalCommandStopMultiCommands.Visible = false;
            }
            catch //(Exception ex)
            {
                this.toolStripGlobalCommandStopMultiCommands.Visible = false;
            }
        }

        public void startMultiCommandsThread(String[] arrCommands)
        {
            try
            {
                this.toolStripGlobalCommandStopMultiCommands.Visible = true;
                this.multiCommandsThread = null;
                this.multiCommandsThread = new Thread(delegate ()
                {
                    this.stopMultiCommandsThread(arrCommands);
                });
                this.multiCommandsThread.Start();
            }
            catch //(Exception ex)
            {
                this.toolStripGlobalCommandStopMultiCommands.Visible = false;
                this.multiCommandsThread = null;
            }
        }

        public void runMultiCommandsOnActiveSession(String[] arrCommands)
        {
            try
            {
                frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                frmPutty.runMultiCommands(arrCommands);
            }
            catch //(Exception ex)
            {
            }
        }

        public void runMultiCommandsOnMultiSessions(String[] arrCommands)
        {
            int count = this.toolStripGlobalCommandSession.DropDownItems.Count;
            try
            {
                if (count > 3)
                {
                    for (int i = 3; i < count; i++)
                    {
                        if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState == CheckState.Checked)
                        {
                            int num = int.Parse(((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).Name);
                            for (int j = 0; j < this.dockPanelMain.Documents.Count<IDockContent>(); j++)
                            {
                                frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(j) as frmPutty;
                                if (num == int.Parse(frmPutty.Handle.ToString()))
                                {
                                    frmPutty.runMultiCommands(arrCommands);
                                    break;
                                }
                            }
                        }
                    }

                    this.startMultiCommandsThread(arrCommands);
                }
            }
            catch //(Exception ex)
            {
            }
            this.toolStripGlobalCommandCommand.Text = "";
        }

        private void toolStripGlobalCommandRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.toolStripGlobalCommandCommand.Text.Trim() == ""))
                {
                    if (this.toolStripGlobalCommandCommand.Text.Trim() == "_mc")
                    {
                        new frmMultiCommands
                        {
                            runMultiCommands = new frmMultiCommands.RunMultiCommands(this.runMultiCommandsOnMultiSessions)
                        }.ShowDialog();
                    }
                    else
                    {
                        this.runCommandOnMultiSessions(this.toolStripGlobalCommandCommand.Text);
                        this.addHistoryGlobalCommand();
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        public void runCommandOnMultiSessions(string command)
        {
            int count = this.toolStripGlobalCommandSession.DropDownItems.Count;
            try
            {
                if (count > 3)
                {
                    for (int i = 3; i < count; i++)
                    {
                        if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState == CheckState.Checked)
                        {
                            int num = int.Parse(((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).Name);
                            for (int j = 0; j < this.dockPanelMain.Documents.Count<IDockContent>(); j++)
                            {
                                frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(j) as frmPutty;
                                if (num == int.Parse(frmPutty.Handle.ToString()))
                                {
                                    RunCommand(command, frmPutty.proc);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch// (Exception ex)
            {
            }
        }

        public static void RunCommand(string command, Process proc)
        {
            try
            {
                if (proc != null && proc.Responding)
                {
                    APIHelper.SendString(proc.MainWindowHandle, command);
                }
            }
            catch //(Exception ex)
            {
            }
        }

        public void addHistoryGlobalCommand()
        {
            int num = this.isTextInItemsList(this.toolStripGlobalCommandCommand);
            if (num != -1)
            {
                this.toolStripGlobalCommandCommand.Items.RemoveAt(num);
            }
            this.toolStripGlobalCommandCommand.Items.Insert(0, this.toolStripGlobalCommandCommand.Text);
            if (this.toolStripGlobalCommandCommand.Items.Count > 10)
            {
                this.toolStripGlobalCommandCommand.Items.RemoveAt(10);
            }
            this.toolStripGlobalCommandCommand.Text = "";
            SetForegroundWindow(base.Handle);
            this.toolStripGlobalCommandCommand.Focus();
        }

        public void getAndSaveDisplayedItems()
        {
            CurrentApplicationSettings.ViewToolbarsMSC = mnuViewToolbarsMSC.Checked;
            CurrentApplicationSettings.ViewToolbarsQuickSession = mnuViewToolbarsQuickConnection.Checked;
            CurrentApplicationSettings.ViewSessionManager = mnuViewSessionManager.Checked;

            if (CurrentApplicationSettings.SessionManagerPosition == "Left")
                CurrentApplicationSettings.SessionManagerWidth = (int)(this.dockPanelMain.DockLeftPortion * 100.0);
            else
                CurrentApplicationSettings.SessionManagerWidth = (int)(this.dockPanelMain.DockRightPortion * 100.0);

            CurrentApplicationSettings.Save();
        }

        public void checkItemsStatusAndDisplay()
        {

            toolStripQuickConnect.Visible = mnuViewToolbarsQuickConnection.Checked = CurrentApplicationSettings.ViewToolbarsQuickSession;
            toolStripGlobalCommand.Visible = mnuViewToolbarsMSC.Checked = CurrentApplicationSettings.ViewToolbarsMSC;
            fmSessionManager.Visible = mnuViewSessionManager.Checked = CurrentApplicationSettings.ViewSessionManager;

            dockPanelMain.DockRightPortion = (double)CurrentApplicationSettings.SessionManagerWidth / 100.0;
            dockPanelMain.DockLeftPortion = dockPanelMain.DockRightPortion;
        }

        private void mnuViewSessionManager_Click(object sender, EventArgs e)
        {
            fmSessionManager.Visible = mnuViewSessionManager.Checked;
        }

        private void mnuToolPuttyConfiguration_Click(object sender, EventArgs e)
        {
            if (!File.Exists(CurrentApplicationSettings.PuttyLocation))
            {
                MessageBox.Show("PuTTY.exe file does not exist. Go to Tools -> Options... to configure PuTTY file");
                return;
            }

            try
            {
                Process process = Process.Start(new ProcessStartInfo(CurrentApplicationSettings.PuttyLocation)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });
            }
            catch //(Exception ex)
            {
            }
        }


        private void mnuToolsOption_Click(object sender, EventArgs e)
        {
            new frmOptions
            {
                displaySessionManager = new frmOptions.DisplaySessionManager(this.displaySessionManager)
            }.ShowDialog();
        }

        public void displaySessionManager()
        {
            dockPanelMain.Theme = new VS2015LightTheme();


            if (CurrentApplicationSettings.SessionManagerPosition == "Left")
            {
                this.dockPanelMain.DockLeftPortion = this.dockPanelMain.DockRightPortion;
                this.fmSessionManager.Hide();
                this.fmSessionManager.DockAreas = DockAreas.DockLeft;
                this.fmSessionManager.Show(this.dockPanelMain, DockState.DockLeft);
            }
            else
            {
                this.dockPanelMain.DockRightPortion = this.dockPanelMain.DockLeftPortion;
                this.fmSessionManager.Hide();
                this.fmSessionManager.DockAreas = DockAreas.DockRight;
                this.fmSessionManager.Show(this.dockPanelMain, DockState.DockRight);
            }
        }

        public void disableWhenNoActiveSession()
        {
            this.toolStripGlobalCommand.Enabled = false;
            this.mnuFileCloseAllSessions.Enabled = false;
            this.toolStripGlobalCommandStatus.Text = "";
            this.toolStripSeparatorStatus.Visible = false;
            this.statusBarStatus.Text = "";
            this.toolStripGlobalCommandStopMultiCommands.Visible = false;
        }

        public void enableWhenHavingActiveSession()
        {
            this.toolStripGlobalCommand.Enabled = true;
            this.mnuFileCloseAllSessions.Enabled = true;
            this.displayStatusOfGlobalCommandSessions();
        }


        private void dockPanelMain_ActiveDocumentChanged(object sender, EventArgs e)
        {
            try
            {
                frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                if (frmPutty != null)
                {
                    this.DisplayStatus(frmPutty.getPuttyWindowTitle());
                    SetForegroundWindow(frmPutty.proc.MainWindowHandle);
                }
            }
            catch //(Exception ex)
            {
            }
        }


        private void mnuViewToolbarsQuickConnection_Click(object sender, EventArgs e)
        {
            if (this.mnuViewToolbarsQuickConnection.Checked)
                this.toolStripQuickConnect.Show();
            else
                this.toolStripQuickConnect.Hide();
        }

        private void mnuViewToolbarsMSC_Click(object sender, EventArgs e)
        {
            if (this.mnuViewToolbarsMSC.Checked)
                this.toolStripGlobalCommand.Show();
            else
                this.toolStripGlobalCommand.Hide();
        }

        private void mnuViewToolbarsStatus_Click(object sender, EventArgs e)
        {
            if (this.mnuViewToolbarsStatus.Checked)
                this.statusBar.Show();
            else
                this.statusBar.Hide();
        }

        public void closeAllSessions()
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to close all sessions?", "Close all sessions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    while (dockPanelMain.Documents.Any<IDockContent>())
                    {
                        frmPutty frmPutty = this.dockPanelMain.Documents.ElementAt(0) as frmPutty;
                        frmPutty?.Close();
                    }
                }
                catch //(Exception ex)
                {
                }
            }
        }

        public void closeAllButActiveSession()
        {
            try
            {
                frmPutty activePutty = this.dockPanelMain.ActiveDocument as frmPutty;
                List<frmPutty> listToClose = new();

                foreach (frmPutty putty in dockPanelMain.Documents.Cast<frmPutty>())
                {
                    if (putty != null && putty != activePutty)
                    {
                        listToClose.Add(putty);
                    }
                }

                foreach (frmPutty putty in listToClose)
                {
                    putty.Close();
                }
            }
            catch //(Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }
        }

        public void closeActiveSession()
        {
            frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
            frmPutty?.Close();
        }

        private void toolStripGlobalCommandCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(this.toolStripGlobalCommandCommand.Text.Trim() == ""))
            {
                if (e.KeyChar == '\r')
                {
                    if (this.toolStripGlobalCommandCommand.Text.Trim() == "_mc")
                    {
                        new frmMultiCommands
                        {
                            runMultiCommands = new frmMultiCommands.RunMultiCommands(this.runMultiCommandsOnMultiSessions)
                        }.ShowDialog();
                    }
                    else
                    {
                        this.runCommandOnMultiSessions(this.toolStripGlobalCommandCommand.Text);
                        this.addHistoryGlobalCommand();
                    }
                }
            }
        }

        private void contextCloseSession_Click(object sender, EventArgs e)
        {
            this.closeActiveSession();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public void sendCommandFromPuttySystemMenu(uint command)
        {
            try
            {
                frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                if (frmPutty != null)
                {
                    frmMain.PostMessage(frmPutty.proc.MainWindowHandle, 274u, new IntPtr((long)((ulong)command)), IntPtr.Zero);
                    frmMain.SetForegroundWindow(frmPutty.proc.MainWindowHandle);
                    if (command == 64u)
                    {
                        frmPutty.autoLoginAndRunCommands();
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextRestartSession_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(64u);
        }

        private void contextChangeSettings_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(80u);
        }

        private void contextEventLog_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(16u);
        }

        private void contextCopyClipboard_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(368u);
        }

        private void contextClearScollback_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(96u);
        }

        private void contextResetTerminal_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(112u);
        }

        private void contextResetAndClear_Click(object sender, EventArgs e)
        {
            this.sendCommandFromPuttySystemMenu(112u);
            this.sendCommandFromPuttySystemMenu(96u);
        }

        private void toolStripMenuSaveDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.SaveAllDatabases();
        }

        private void mnuHelp_MouseEnter(object sender, EventArgs e)
        {
            this.mnuMain.Focus();
        }

        private void toolsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.mnuMain.Focus();
        }

        private void viewToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.mnuMain.Focus();
        }

        private void fileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.mnuMain.Focus();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentApplicationSettings.QuickPuttyProtocol = this.toolStripQuickConnectProtocol.Text;

            if (this.toolStripQuickConnecSessionConfig.Text != CurrentApplicationSettings.QuickPuttySetting)
                CurrentApplicationSettings.QuickPuttySetting = this.toolStripQuickConnecSessionConfig.Text;

            CurrentApplicationSettings.Save();
            this.getAndSaveDisplayedItems();
            this.fmSessionManager.Close();
        }

        private void toolStripMenuNewDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.createNewDatabase();
        }

        private void toolStripMenuOpenDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.openDatabase("dat");
        }


        private void mnuFileCloseAllSessions_Click(object sender, EventArgs e)
        {
            this.closeAllSessions();
        }

        private void mnuFileNewDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.createNewDatabase();
        }

        private void mnuFileOpenDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.openDatabase("dat");
        }

        private void mnuSaveAllDatabases_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.SaveAllDatabases();
        }

        private void mnufileImportDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.openDatabase("xml");
        }

        private void toolStripMenuImportDatabase_Click(object sender, EventArgs e)
        {
            this.fmSessionManager.openDatabase("xml");
        }

        public void createDatabaseFromPuttySessions()
        {
            this.fmSessionManager.createDatabaseFromPuttySessions();
        }

        private void mnuToolsPuTTYSessions_Click(object sender, EventArgs e)
        {
            new frmPuttySessions
            {
                createDatabaseFromPuttySessions = new frmPuttySessions.CreateDatabaseFromPuttySessions(this.createDatabaseFromPuttySessions)
            }.ShowDialog();
        }


        private void contextForDocPanel_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                if (frmPutty != null)
                {
                    System.Threading.ThreadState multiCommandsThreadState = frmPutty.getMultiCommandsThreadState();
                    if (multiCommandsThreadState == System.Threading.ThreadState.Stopped || multiCommandsThreadState == System.Threading.ThreadState.Aborted)
                    {
                        this.contextRunMultiCommands.Text = "Run Multi Commands";
                    }
                    else
                    {
                        this.contextRunMultiCommands.Text = "Stop Running Multi Commands";
                    }
                    if (frmPutty.getPuttyWindowTitle().Contains("(inactive"))
                    {
                        this.contextRestartSession.Visible = true;
                    }
                    else
                    {
                        this.contextRestartSession.Visible = false;
                    }
                    for (int i = 3; i < this.toolStripGlobalCommandSession.DropDownItems.Count; i++)
                    {
                        if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).Name == frmPutty.Handle.ToString())
                        {
                            if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState == CheckState.Checked)
                            {
                                this.contextAcceptGlobalCommand.Checked = true;
                            }
                            else
                            {
                                this.contextAcceptGlobalCommand.Checked = false;
                            }
                            break;
                        }
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextAcceptGlobalCommand_Click(object sender, EventArgs e)
        {
            try
            {
                frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                if (frmPutty != null)
                {
                    for (int i = 3; i < this.toolStripGlobalCommandSession.DropDownItems.Count; i++)
                    {
                        if (((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).Name == frmPutty.Handle.ToString())
                        {
                            if (this.contextAcceptGlobalCommand.Checked)
                            {
                                ((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState = CheckState.Checked;
                            }
                            else
                            {
                                ((ToolStripMenuItem)this.toolStripGlobalCommandSession.DropDownItems[i]).CheckState = CheckState.Unchecked;
                            }
                            this.displayStatusOfGlobalCommandSessions();
                            break;
                        }
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextRunMultiCommands_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.contextRunMultiCommands.Text == "Run Multi Commands")
                {
                    new frmMultiCommands
                    {
                        runMultiCommands = new frmMultiCommands.RunMultiCommands(this.runMultiCommandsOnActiveSession)
                    }.ShowDialog();
                }
                else
                {
                    frmPutty frmPutty = this.dockPanelMain.ActiveDocument as frmPutty;
                    frmPutty.stopRunningMultiCommands();
                }
            }
            catch //(Exception ex)
            {
            }
        }

        //private const int MOUSEEVENTF_RIGHTDOWN = 8;

        //private const int MOUSEEVENTF_RIGHTUP = 16;

        //private const uint TPM_LEFTBUTTON = 0u;

        //private const uint TPM_RETURNCMD = 256u;

        //private const uint WM_SYSCOMMAND = 274u;

        //private const uint PY_RESTARTSESSION = 64u;

        //private const uint PY_EVENTLOG = 16u;

        //private const uint PY_CHANGESETTING = 80u;

        //private const uint PY_COPYCLIPBOARD = 368u;

        //private const uint PY_CLEARSCROLLBACK = 96u;

        //private const uint PY_RESETTERMINAL = 112u;

        private frmSessionManager fmSessionManager;

        private Thread multiCommandsThread;

        private readonly KeyboardHook hook = new();

        private bool formActivate = true;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.closeAllButActiveSession();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.closeAllSessions();
        }

    }
}
