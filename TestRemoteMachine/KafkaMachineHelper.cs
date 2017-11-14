using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace SeleniumTests
{
    public class KafkaMachineHelper:HelpBase
    {
        private Process proc;
        private Process procKill;
        private string argument;
        private string cmd = @"C:\PSTools\PsExec64.exe";
        private int sessionID;

        public KafkaMachineHelper(ApplicationManager manager) : base(manager)
        {
        }

        public KafkaMachineHelper StartNewProcess(string argument)
        {


            proc = new Process();

            //@"\\10.0.189.30\ -w C:\DEV\kafka\bin\windows\ -d -u administrator -p @p-DATA#1 cmd /c C:\DEV\kafka\bin\windows\RunConsumer.bat";
            proc.StartInfo.WorkingDirectory = @"C:\windows\system32\";
            proc.StartInfo.FileName = cmd;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.Arguments = argument;
            proc.Start();
            Console.WriteLine(proc.StandardError.ReadToEnd());
            Console.WriteLine("\n" + proc.StandardOutput.ReadToEnd());
            sessionID = proc.ExitCode;
            return this;
        }

        public bool ReadFromKafkaFile()
        {
            string[] events = File.ReadAllLines(@"\\10.0.189.30\c$\test1.txt");
            List<ProximoEventData> list1 = new List<ProximoEventData>();
            list1.
           return Regex.IsMatch(Convert.ToString(events), "WebActivity") && Regex.IsMatch(Convert.ToString(events), "503");
         
        }

        public KafkaMachineHelper KillPreviosProcess() { 

            procKill = new Process();
            cmd = @"C:\PSTools\pskill64.exe";
            argument = @"\\10.0.189.30 -t -u administrator -p @p-DATA#1 " + sessionID;
            procKill.StartInfo.WorkingDirectory = @"C:\windows\system32\";
            procKill.StartInfo.FileName = cmd;
            procKill.StartInfo.RedirectStandardInput = true;
            procKill.StartInfo.UseShellExecute = false;
            procKill.StartInfo.RedirectStandardError = true;
            procKill.StartInfo.RedirectStandardOutput = true;
            procKill.StartInfo.CreateNoWindow = true;
            procKill.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            procKill.StartInfo.Arguments = argument;
            procKill.Start();
            return this;
        }

        public void StartNTLMSession()
        {
            NetworkCredential theNetworkCredential = new NetworkCredential("administrator", "@p-DATA#1");
            CredentialCache theNetcache = new CredentialCache();
            theNetcache.Add(new Uri(@"\\10.0.189.30\c$"), "Basic", theNetworkCredential);
            
        }

        public string Argument
        {
            get
            {
                return argument;
            }

            set
            {
                argument = value;
            }
        }

        public Process Proc
        {
            get
            {
                return proc;
            }

            set
            {
                proc = value;
            }
        }

        private int SessionID { get { return sessionID; } set { sessionID = value; }  }
    }


  
}