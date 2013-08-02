using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskScheduler.Tools
{
    public class CMDRunner
    {
        public static void RunCommand(string Command)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = Command;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex) { Tools.Logger.LogToFile(new Models.LogEntry(99, "RunCommand", ex.Message)); };
        }
    }
}
