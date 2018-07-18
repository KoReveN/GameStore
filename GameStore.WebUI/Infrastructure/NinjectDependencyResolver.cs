using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;

namespace GameStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        // Здесь размещаются привязки
        private void AddBindings()
        {
            kernel.Bind<IGameRepository>().To<EFGameRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}




//// Здесь размещаются привязки
//private void AddBindings()
//{
//    // Используя мог - создаем имитированную реализацию интерфейса для проверки
//    Mock<IGameRepository> mock = new Mock<IGameRepository>();
//    mock.Setup(m => m.Games).Returns(new List<Game>
//            {
//                new Game { Name = "SimCity", Price = 1499 },
//                new Game { Name = "TITANFALL", Price = 2299},
//                new Game { Name = "Battlefield 4", Price = 899.4M }
//            });

//    // Привязываем к интерфейсу реализацию на Mock
//    kernel.Bind<IGameRepository>().ToConstant(mock.Object);
//    //Всякий раз, когда ядро Ninject получает запрос реализации 
//    //интерфейса IGameRepository, оно должно возвращать один и 
//    //тот же имитированный объект, поэтому для установки 
//    //соответствующей области действия Ninject используется метод ToConstant()
//}