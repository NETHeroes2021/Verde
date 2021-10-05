using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace EjercicioFinalMVC5.Services.ID
{
    public class GestorDependencias : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //  builder.RegisterType<RebelsController>();
            //  builder.RegisterType<SpecificationAND>().As<ISpecification>().SingleInstance();
            //  builder.RegisterType<RebelsFactory>().As<IRebelsFactory>().SingleInstance();
           builder.RegisterType<Repository.Repository>().As<IRepository>().SingleInstance();
            //builder.RegisterType<FakeRepository>().As<IRepository>().SingleInstance();

            base.Load(builder);
        }
    }
}