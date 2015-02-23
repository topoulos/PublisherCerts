using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Publisher;
using System.Reflection;
using System.Security.Permissions;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Timers;
using System.Diagnostics;

namespace PublisherCerts2
{
    
    class Program
    {
        //static Timer timer;

        static void Main(string[] args)
        {
            Publisher.RunMSPublisher();
            //timer = new Timer();
            //timer.Interval = 120000;
            //timer.Elapsed +=new ElapsedEventHandler(timer_Elapsed);
          
            //start_timer();
            //Console.ReadLine();
            try
            {
                foreach (Process proc in Process.GetProcessesByName("MSPUB"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    //    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    //    {
    //        Publisher.RunMSPublisher();
          
    //    }
    //    private static void start_timer()
    //    {
    //        timer.Start();
    //    }
    }
}
