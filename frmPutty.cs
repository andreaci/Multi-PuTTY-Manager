using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace SessionManagement
{
	public partial class frmPutty : DockContent
    {
        SettingsData CurrentApplicationSettings = SettingsData.Instance;

        [DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("User32.dll")]
		private static extern int SetForegroundWindow(IntPtr point);

		[DllImport("USER32.DLL")]
		public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, uint uFlags);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		public frmPutty()
		{
			this.InitializeComponent();
			this.info = null;
			this.proc = null;
			this.autoThread = null;
			this.session = new Session();
		}

		public frmPutty(Session sess, Action<Session, string> closeSession = null)
		{
			this.InitializeComponent();
			this.info = null;
			this.proc = null;
			this.session = sess;

			if(closeSession != null)
                this.closeSession = new CloseSession(closeSession);
		}

		public void openConnection()
        {
            Global.OpenSessions ??= new List<Session>();
            
			try
			{
				string str = $" -load \"{this.session.SessionConfig}\" -{this.session.SessionProtocol.ToLower()}";
				
				if (this.session.SessionPort != -1)
					str += $" -P {this.session.SessionPort}";

                if (session.SessionCredentials.UserName.Length > 0)
                    str += $" -l {session.SessionCredentials.UserName}";

                if (session.SessionCredentials.Password.Length > 0)
                    str += $" -pw {session.SessionCredentials.Password}";


                this.info = new ProcessStartInfo(CurrentApplicationSettings.PuttyLocation)
                {
                    Arguments = str + " " + this.session.SessionHost,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                this.proc = Process.Start(this.info);
				this.proc.WaitForInputIdle();
				
				frmPutty.SetParent(this.proc.MainWindowHandle, this.pnMain.Handle);
				moveWindow(this.proc.MainWindowHandle, this.pnMain.Size);
				this.Text = this.session.SessionName;
				
				Global.OpenSessions.Add(this.session);
			}
			catch //(Exception ex)
			{
			}
		}

		public void autoLoginAndRunCommands()
		{
			if (Control.ModifierKeys != Keys.Control)
			{
				this.autoThread = new Thread(delegate()
				{
					this.autoCommands();
				});
				this.autoThread.Start();
			}
		}

		private void autoCommands()
		{
			try
			{
				if (this.session.SessionCredentials.UserName != "" && this.session.SessionCredentials.Password != "")
				{
					Thread.Sleep(this.session.ConnectionTimeout);
					if (this.session.PostLogin)
					{
						for (int i = 0; i < this.session.PostLoginCommands.Length; i++)
						{
							this.runCommand(this.session.PostLoginCommands[i].ToString());
							Thread.Sleep(this.session.CommandTimeout);
						}
					}
				}

			}
			catch //(Exception ex)
			{

			}
		}

		public System.Threading.ThreadState getMultiCommandsThreadState()
		{
			System.Threading.ThreadState result;
			if (this.multiCommandsThread != null)
			{
				result = this.multiCommandsThread.ThreadState;
			}
			else
			{
				result = System.Threading.ThreadState.Stopped;
			}
			return result;
		}

		private void runCommand(string command)
		{
			try
			{
				if (this.proc != null && this.proc.Responding)
				{
                    APIHelper.SendString(this.proc.MainWindowHandle, command);
				}
			}
			catch //(Exception ex)
			{
			}
		}

		private void multiCommands(String[] arrCommands)
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
					this.runCommand(array[0]);
					Thread.Sleep(int.Parse(array[1]));
				}
				this.multiCommandsThread.Interrupt();
			}
			catch //(Exception ex)
			{
				this.multiCommandsThread.Interrupt();
			}
		}

		public void runMultiCommands(String[] arrCommands)
		{
			if (this.proc != null)
			{
				try
				{
					if (!this.proc.HasExited)
					{
						if (this.multiCommandsThread == null || !this.multiCommandsThread.IsAlive)
						{
							this.multiCommandsThread = null;
							this.multiCommandsThread = new Thread(delegate()
							{
								this.multiCommands(arrCommands);
							});
							this.multiCommandsThread.Start();
						}
					}
				}
				catch //(Exception ex)
				{
				}
			}
		}

		public void stopRunningMultiCommands()
		{
			if (multiCommandsThread != null && multiCommandsThread.IsAlive)
					multiCommandsThread.Interrupt();
			
		}

		public static void moveWindow(IntPtr handle, Size size)
		{
			try
			{
				frmPutty.MoveWindow(handle, -9, -30, size.Width + 18, size.Height + 39, true);
			}
			catch //(Exception ex)
			{
			}
		}

		private void frmPutty_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.autoThread?.Interrupt();
			this.multiCommandsThread?.Interrupt();
			this.proc?.Close();
		}

		private void frmPutty_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.closeSession(this.session, base.Handle.ToString());
		}

		private void tmCheckProcess_Tick(object sender, EventArgs e)
		{
			if (this.proc.HasExited)
			{
				this.tmCheckProcess.Stop();
				base.Close();
			}
		}

		private void frmPutty_Load(object sender, EventArgs e)
		{
			this.tmCheckProcess.Start();
		}

		private void frmPutty_Resize(object sender, EventArgs e)
		{
			if (this.proc != null)
			{
				try
				{
					if (!this.proc.HasExited && base.Height > 0)
							moveWindow(this.proc.MainWindowHandle, this.pnMain.Size);
				}
				catch //(Exception ex)
				{
				}
			}
		}

		public string getPuttyWindowTitle()
		{
			string result = null;
			try
			{
				StringBuilder stringBuilder = new (256);
				if (frmPutty.GetWindowText(this.proc.MainWindowHandle, stringBuilder, 256) > 0)
					result = stringBuilder.ToString();
			}
			catch //(Exception ex)
			{
			}
			return result;
		}

		public string getCurrentDirectory()
		{
			string result;
			try
			{
				string puttyWindowTitle = this.getPuttyWindowTitle();
				if (puttyWindowTitle == null)
				{
					result = null;
				}
				else
				{
					string[] array = puttyWindowTitle.Split(new char[]
					{
						':'
					});
					result = array[1];
				}
			}
			catch //(Exception ex)
			{
				result = null;
			}
			return result;
		}

		//private const uint SHOWWINDOW = 64u;

		public ProcessStartInfo info;

		public Process proc;

		public Session session;

		private Thread autoThread;

		private Thread multiCommandsThread;

		public frmPutty.CloseSession closeSession;

		public delegate void CloseSession(Session sess, string puttyName);
	}
}
