using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SessionManagement
{
	public sealed class KeyboardHook : IDisposable
	{
		[DllImport("User32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

		[DllImport("User32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		public KeyboardHook()
		{
			this._window.KeyPressed += delegate(object sender, KeyPressedEventArgs args)
			{
                this.KeyPressed?.Invoke(this, args);
            };
		}

		public void RegisterHotKey(ModifierKeys modifier, Keys key)
		{
			this._currentId++;
			if (!KeyboardHook.RegisterHotKey(this._window.Handle, this._currentId, (uint)modifier, (uint)key))
				throw new InvalidOperationException("Couldn’t register the hot key.");
		}

		public event EventHandler<KeyPressedEventArgs> KeyPressed;

		public void Dispose()
		{
			for (int i = this._currentId; i > 0; i--)
			{
				KeyboardHook.UnregisterHotKey(this._window.Handle, i);
			}
			this._window.Dispose();
		}

		private readonly KeyboardHook.Window _window = new ();

		private int _currentId;

		private class Window : NativeWindow, IDisposable
		{
			public Window()
			{
				this.CreateHandle(new CreateParams());
			}

			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg == KeyboardHook.Window.WM_HOTKEY)
				{
					Keys key = (Keys)((int)m.LParam >> 16 & 65535);
					ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 65535);
                    this.KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
			}

			public event EventHandler<KeyPressedEventArgs> KeyPressed;

			public void Dispose()
			{
				this.DestroyHandle();
			}

			private static readonly int WM_HOTKEY = 786;
		}
	}
}
