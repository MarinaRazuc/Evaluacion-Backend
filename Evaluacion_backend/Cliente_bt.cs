using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;

namespace Evaluacion_backend
{
    public class Cliente_bt : DefaultNancyBootstrapper
    {
        private TimeSpan stop, start;

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.BeforeRequest += async (ctx, token) => {
                start=new TimeSpan(DateTime.Now.Ticks);
                return null;
            };

            pipelines.AfterRequest += (ctx) => {
                stop = new TimeSpan(DateTime.Now.Ticks);
                Console.WriteLine(stop.Subtract(start).TotalMilliseconds);
            };
        }   
    }
}

