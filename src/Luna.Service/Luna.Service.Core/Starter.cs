﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Luna.Service.Core.Dependency;

namespace Luna.Service.Core
{
    public class Starter : IDisposable
    {
        public readonly WindsorContainer Container;
        public ILogger Logger { get; set; }

        private Starter(Type runnerType)
        {
            Container = new WindsorContainer();
            Container.Register(
                Classes.FromAssemblyInThisApplication(runnerType.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .WithServiceAllInterfaces()
                    .If(type => !type.IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
            );

            Container.Register(
                Classes.FromAssemblyInThisApplication(runnerType.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .If(type => !type.IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
            );
        }

        public static Starter Create<T>()
            where T : IRunner
        {
            return new Starter(typeof(T));
        }

        public void Run(bool debug = false)
        {
            try
            {
                Logger = Container.Kernel.HasComponent(typeof(ILogger))
                    ? Container.Resolve<ILogger>()
                    : NullLogger.Instance;

                var runner = Container.Resolve<IRunner>();
                runner.Run();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString());
                if (debug)
                {
                    throw;
                }
            }
        }

        public void Dispose()
        {
            Container?.Dispose();
        }
    }
}
