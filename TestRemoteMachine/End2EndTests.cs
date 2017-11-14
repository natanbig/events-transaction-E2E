
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;



namespace SeleniumTests
{
 
    public class End2EndTests:TestBase
    {    
        [Test]
        public void ProximoEventTest()
        
            
            {
            app.Kafka.StartNewProcess(@"\\10.0.189.30\ -w C:\DEV\kafka\bin\windows\ -d -u administrator -p @p-DATA#1 cmd /c C:\DEV\kafka\bin\windows\RunConsumer.bat");
            app.Navigator.GoToDLPTestPage();
                if (app.Navigator.BaseURL == @"http://dlptest.com/")
                    app.Web.SendProximoEvent();
                else
                    app.Web.SendProximoEventFromReservedSite();
            app.Kafka.KillPreviosProcess();

            Assert.AreEqual(app.Kafka.ReadFromKafkaFile(), true);
            

            }




        //   List <ProximoEventData> proximoList= new List<ProximoEventData>();

        //  System.Diagnostics.Process.Start(@"cmd /c \\10.0.189.30\c$\DEV\kafka\bin\windows\RunConsumer.bat");

        // File.Copy(@"\\10.0.189.30\c$\test1.txt", @"\\10.0.189.30\c$\test.txt");
        //    string[] events = File.ReadAllLines(@"\\10.0.189.30\c$\test.txt");

        //File.Delete(@"\\10.0.189.30\c$\test1.txt");

        //  File.Delete(@"\\10.0.189.30\c$\test.txt");









    }
}
