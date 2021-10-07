using EjercicioFinalMVC5.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EjercicioFinalMVC5.Tests
{
    [TestClass]
    public class ClasesTest
    {
        [TestMethod]
        public void ImageHelperBien1()
        {

            var imagen = ImageHelper.dameByteArray("https://safetyaustraliagroup.com.au/wp-content/uploads/2019/05/image-not-found.png");

            Assert.IsNotNull(imagen);

        }

        [TestMethod]
        public void ImageHelperBien2()
        {

            var imagen = ImageHelper.dameByteArray("https://www.freejpg.com.ar/image-900/98/983d/F100027767-hombre_sosteniendo_un_cigarrillo_de_marihuana.jpg");

            Assert.IsNotNull(imagen);

        }
    }
}
