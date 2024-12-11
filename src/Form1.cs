using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using FastColoredTextBoxNS;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using Python_WRD.Buttons;
using Python_WRD.Properties;

namespace DynamicButtons
{
    public partial class Form1 : MaterialForm
    {
        private Form codeWindow;
        public Form1()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            this.FormClosing += new FormClosingEventHandler(this.beta_FormClosing);
            AutoUpdater.Start("https://python.freeutka.xyz/updater.xml");
            AutoUpdater.Icon = Python_WRD.Properties.Resources.pythonu;
            //AutoUpdater.InstalledVersion = new Version("1.0.0.0");
            AutoUpdater.UpdateFormSize = new System.Drawing.Size(751, 507);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Home Buttons
            materialButton1.Click += HomeButtons.OpenGitHub;
            materialButton2.Click += HomeButtons.OpenDiscord;
            materialButton3.Click += HomeButtons.OpenWebsite;
            materialButton4.Click += HomeButtons.CheckForUpdates;

            // Code Buttons
            materialButton5.Click += ApisAndBots._1;
            materialButton6.Click += ApisAndBots._2;
            materialButton7.Click += ApisAndBots._3;
            materialButton8.Click += ApisAndBots._4;
            materialButton9.Click += ApisAndBots._5;
            materialButton10.Click += ApisAndBots._6;
            materialButton11.Click += ApisAndBots._7;
            materialButton12.Click += ApisAndBots._8;
            materialButton13.Click += ApisAndBots._9;
            
            materialButton14.Click += WebApps._1;
            materialButton15.Click += WebApps._2;
            materialButton16.Click += WebApps._3;
            materialButton17.Click += WebApps._4;
            materialButton18.Click += WebApps._5;
            materialButton19.Click += WebApps._6;
            materialButton20.Click += WebApps._7;
        }
        public Form1 Instance => this;

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green600, Primary.Green700,
                Primary.Green200, Accent.Green700,
                TextShade.WHITE
            );
        }

        private void beta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (codeWindow != null && !codeWindow.IsDisposed)
            {
                codeWindow.Close();
            }
        }

        private void beta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (codeWindow != null && !codeWindow.IsDisposed)
            {
                codeWindow.Close();
            }
        }
    }
}