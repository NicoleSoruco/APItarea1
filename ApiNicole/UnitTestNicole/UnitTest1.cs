using System;
using System.Web.Http.Results;
using ApiNicole.Controllers;
using ApiNicole.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestNicole
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            SorucoesController sorucoesController = new SorucoesController();

            //Act
            var resultado = sorucoesController.GetSorucoes();

            //Assert

            Assert.IsNotNull(resultado);

        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange
            SorucoesController sorucoesController = new SorucoesController();
            Soruco expected = new Soruco()
            {
                SorucoID = 1,
                FriendofSoruco = "natalia",
                Place = CategoryType.centro,
                Email = "nicolita@hotmail.com",
                Birthdayt = DateTime.Today,

            };

            //Act
            var resultado = sorucoesController.PostSoruco(expected);
            var creado = resultado as CreatedAtRouteNegotiatedContentResult<Soruco>;

            //Assert

            Assert.IsNotNull(creado);
            Assert.AreEqual("DefaultApi", creado.RouteName);
            Assert.AreEqual(expected.FriendofSoruco, creado.Content.FriendofSoruco);

        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            SorucoesController sorucoesController = new SorucoesController();
            Soruco expected = new Soruco()
            {
                SorucoID = 1,
                FriendofSoruco = "natalia",
                Place = CategoryType.centro,
                Email = "nicolita@hotmail.com",
                Birthdayt = DateTime.Today,

            };

            //Act
            var resultado = sorucoesController.PutSoruco(expected.SorucoID,expected);
            var creado = resultado as OkNegotiatedContentResult<Soruco>;

            //Assert
            Assert.IsNotNull(creado);
           

        }


        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            SorucoesController sorucoesController = new SorucoesController();
            Soruco expected = new Soruco()
            {
                SorucoID = 1,
                FriendofSoruco = "natalia",
                Place = CategoryType.centro,
                Email = "nicolita@hotmail.com",
                Birthdayt = DateTime.Today,

            };

            //Act
            var resultado = sorucoesController.PostSoruco(expected);
            var creado = sorucoesController.DeleteSoruco(expected.SorucoID);

            //Assert
            Assert.IsInstanceOfType(creado, typeof(OkNegotiatedContentResult<Soruco>));


        }
    }
}
