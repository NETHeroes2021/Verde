using EjercicioFinalMVC5;
using EjercicioFinalMVC5.Controllers;
using EjercicioFinalMVC5.Models;
using EjercicioFinalMVC5.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EjercicioFinalMVC5.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeAbout()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void HomeContact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


      
    }

    [TestClass]
    public class AnimalControllerTest
    {
        [TestMethod]
        public async Task AnimalIndex()
        {
            List<Animal> animales = new FakeRepository().getAllAnimals();
            // Arrang
            var controller = new AnimalController();
            // Act
            var result = await controller.IndexTest(animales);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AnimalCreate()
        {
            // Arrange
            AnimalController controller = new AnimalController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class JaulaControllerTest
    {

        [TestMethod]
        public void JaulaCreate()
        {
            // Arrange
            JaulaController controller = new JaulaController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
