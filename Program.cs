﻿using System;

namespace PublisherCerts2
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Starting Certs Checker");
            while (true)
            {
                Publisher.RunMsPublisher();
                Console.WriteLine("Waiting...");
                System.Threading.Thread.Sleep(1000 * 60 * 5);
            }

        }
    }
}