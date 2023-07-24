using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSpecflowDemo.Helpers
{
    public class CommandHelper
    {
        public void RunCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // Command prompt executable
                Arguments = "/c " + command, // /c tells cmd to execute the command and then exit
                WorkingDirectory = Environment.CurrentDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processInfo;

                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        Console.WriteLine("Output: " + e.Data);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        Console.WriteLine("Error: " + e.Data);
                    }
                };

                try
                {
                    process.Start();
                }
                catch (Exception ex)
                {

                }
                
                //process.BeginOutputReadLine();
                //process.BeginErrorReadLine();
                if (command.Contains("avd"))
                {
                    Thread.Sleep(10000);
                }
                else
                {
                    process.WaitForExit();
                }
            }
        }
    }
}
