using System;
using System.Windows.Forms;

namespace SessionManagement
{
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1u,
        Control = 2u,
        Shift = 4u,
        Win = 8u
    }

    public class KeyPressedEventArgs : EventArgs
	{
		internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
		{
			Modifier = modifier;
			Key = key;
		}

		public ModifierKeys Modifier { get; private set; }

		public Keys Key { get; private set; }
	}
}