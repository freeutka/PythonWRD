using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUpdaterDotNET;
using System.Windows.Forms;

namespace Python_WRD.Buttons
{
    internal class HomeButtons
    {
        public static void OpenGitHub(object sender, EventArgs e)
        {
            string url = "https://github.com/freeutka/PythonWRD";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        public static void OpenDiscord(object sender, EventArgs e)
        {
            string url = "https://discord.gg/vjtPaHrFgb";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        public static void OpenWebsite(object sender, EventArgs e)
        {
            string url = "https://python.freeutka.xyz/";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        public static void CheckForUpdates(object sender, EventArgs e)
        {
            AutoUpdaterDotNET.AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdaterDotNET.AutoUpdater.Start("https://python.freeutka.xyz/updater.xml");
        }

        private static void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    var dialogResult = MessageBox.Show(
                        $"A new version ({args.CurrentVersion}) is available. You are using version {args.InstalledVersion}.\nDo you want to update the application now?",
                        "Update Available",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "There are no updates available at the moment.",
                        "No Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    $"An error occurred while checking for updates:\n{args.Error.Message}",
                    "Update Check Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
