using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicButtons;
using FastColoredTextBoxNS;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;

namespace Python_WRD.Components
{
    internal class OpenCodeWindowHandler
    {
        private static Form codeWindow;

        public static void OpenCodeWindow(string code)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null)
            {
                return;
            }

            if (codeWindow != null && !codeWindow.IsDisposed)
            {
                codeWindow.Close();
            }

            codeWindow = new MaterialForm
            {
                Text = "PythonWRD",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(form1.Right + 10, form1.Top),
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage((MaterialForm)codeWindow);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green600, Primary.Green700,
                Primary.Green200, Accent.Green700,
                TextShade.WHITE
            );

            FastColoredTextBox codeBox = new FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Text = code,
                ReadOnly = true,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.FromArgb(220, 220, 220),
                Font = new Font("Consolas", 10),
                ShowLineNumbers = true,
            };

            codeBox.Language = Language.Custom;

            codeWindow.Controls.Add(codeBox);
            codeWindow.Show();
        }
    }
}
