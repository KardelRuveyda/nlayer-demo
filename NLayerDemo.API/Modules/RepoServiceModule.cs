using Autofac;
using NLayerDemo.Core.Repositories;
using NLayerDemo.Core.Services;
using NLayerDemo.Core.UnitOfWorks;
using NLayerDemo.Repository;
using NLayerDemo.Repository.Repositories;
using NLayerDemo.Repository.UnitOfWorks;
using NLayerDemo.Service.Mapping;
using NLayerDemo.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace NLayerDemo.API.Modules
{
    public class RepoServiceModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
