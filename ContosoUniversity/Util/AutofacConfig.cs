using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.Controllers;

namespace ContosoUniversity.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(AccountController).Assembly);
            builder.RegisterControllers(typeof(CourseController).Assembly);
            builder.RegisterControllers(typeof(DepartmentController).Assembly);
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(InstructorController).Assembly);
            builder.RegisterControllers(typeof(StudentController).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<UnitOfWork>();


            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}