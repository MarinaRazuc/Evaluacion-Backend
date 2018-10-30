namespace Evaluacion_backend
{
    using System;
    using System.Diagnostics;

    using Nancy.Hosting.Self;

    class Inicio
    {
        static void Main()
        {

            var nancyHost = new NancyHost(new Uri("http://localhost:1234/"));
            nancyHost.Start();

            Console.WriteLine("Nancy now listening - navigating to http://localhost:1234/. Press enter to stop");
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }
   
}