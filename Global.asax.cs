
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;

namespace Agri_Energy_Connect_Web_Application
{
    public class Global : HttpApplication
    {
        private FileChangeMonitor _monitor;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string pathToMonitor = @"C:\Users\fmotj\OneDrive\Desktop\New folder\Agri-Energy Connect Web Application";

            _monitor = new FileChangeMonitor(pathToMonitor);
            _monitor.FileChanged += OnFileChanged;
            _monitor.Start();

            // Log or output the monitoring start information if needed
            Console.WriteLine($"Monitoring changes in {pathToMonitor}");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _monitor.Stop();
        }

        private void OnFileChanged(object sender, FileChangedEventArgs e)
        {
            Console.WriteLine($"File changed: {e.FilePath}");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "python",  // Ensure 'python' is correctly set in the system PATH
                    Arguments = $"D:\\python\\FIRSTPRO.py \"{e.FilePath}\"",  // Use double backslashes or raw string
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine(result);
        }
    }
}
