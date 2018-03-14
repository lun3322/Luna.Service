using System;
using System.Reflection;
using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Luna.Service.Audit;
using Luna.Service.Dependency;

namespace Luna.Service
{
    public class Starter : IDisposable
    {
        public readonly WindsorContainer Container;
        public ILogger Logger { get; set; }

        private Starter(Type runnerType, StarterOption option)
        {
            Container = new WindsorContainer();
            Container.Kernel.ComponentRegistered += (key, handler) =>
            {
                if (option.DisableAudit) return;

                if (handler.ComponentModel.Implementation.IsDefined(typeof(AuditedAttribute), true))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AuditingInterceptor)));
                }
            };

            Container.Register(
                Classes.FromAssemblyInThisApplication(runnerType.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
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

            Container.Register(
                Classes.FromAssemblyInThisApplication(runnerType.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IInterceptor>()
                    .If(type => !type.IsGenericTypeDefinition)
                    .WithService.Self()
                    .LifestyleTransient()
            );
        }

        public static Starter Create<T>(StarterOption option = null)
            where T : IRunner
        {
            return new Starter(typeof(T), option ?? new StarterOption());
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
