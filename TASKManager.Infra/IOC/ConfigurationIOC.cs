using Autofac;
using FluentValidation;
using TASKManager.Domain.Core.Interfaces.Repositories;
using TASKManager.Domain.Core.Interfaces.Services;
using TASKManager.Domain.Entities;
using TASKManager.Domain.Services.Services;
using TASKManager.Domain.Validators;
using TASKManager.Infra.Data.Repositories;

namespace TASKManager.Infra.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TaskValidator>().As<IValidator<Task>>();

            builder.RegisterType<TaskRepository>().As<ITaskRepository>();

            builder.RegisterType<TaskService>().As<ITaskService>();
        }
    }
}
