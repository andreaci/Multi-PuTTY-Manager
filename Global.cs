using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SessionManagement
{
	public static class Global
	{
		public static DialogResult InputBox(string title, string promptText, ref string value)
		{

            Label label = new()
            {
                Text = promptText,
                AutoSize = true
            };
            label.SetBounds(9, 18, 372, 13);

            TextBox textBox = new()
            {
                Text = value
            };
            textBox.Anchor |= AnchorStyles.Right;
			textBox.SetBounds(12, 36, 372, 20);

            Button button = new()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Right)
            };
            button.SetBounds(228, 72, 75, 23);

            Button button2 = new()
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Right)
            };
            button2.SetBounds(309, 72, 75, 23);

            Form form = new()
            {
                Text = title,
                ClientSize = new Size(396, 107),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                AcceptButton = button,
                CancelButton = button2
            };
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.Controls.AddRange(new Control[]
			{
				label,
				textBox,
				button,
				button2
			});

			DialogResult result = form.ShowDialog();
			value = textBox.Text;
			return result;
		}

		public static List<Session> AvailableSessions { get; set; }
					  
		public static List<Session> OpenSessions { get; set; }

        public static List<String> DatabaseLocation { get; set; }
    }
}
