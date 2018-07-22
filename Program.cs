using System;
using System.Threading.Tasks;

namespace PublisherCerts2
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            Console.WriteLine("Starting Certs Checker");
            while (true)
            {
                await Publisher.RunMsPublisher();
                Console.WriteLine("Waiting...");
                System.Threading.Thread.Sleep(1000 * 60 * 5);
            }

        }
    }
}