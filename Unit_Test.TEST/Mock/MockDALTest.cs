using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Test.APP.Mock;

namespace Unit_Test.TEST.Mock
{
    public class MockDALTest
    {
        [Fact]
        [Trait("Category", "Mock DAL")]
        public void CreateUser_Success()
        {
            // Créer un mock de IDatabaseConnection
            Mock<IDatabaseConnection> databaseConnectionMock = new Mock<IDatabaseConnection>();
            databaseConnectionMock
                .Setup(x => x.CreateUser("john", "password", 25))
                .Returns(true); // Simuler le retour de true pour une création réussie

            // Appeler la méthode de création d'utilisateur directement
            bool result = databaseConnectionMock.Object.CreateUser("john", "password", 25);

            // Vérifier que la méthode de création d'utilisateur a été appelée avec les bons paramètres
            databaseConnectionMock.Verify(x => x.CreateUser("john", "password", 25), Times.Once);

            // Vérifier que le résultat de la méthode est égal à true
            Assert.True(result);
        }

        [Fact]
        [Trait("Category", "Mock DAL")]
        public void UpdateUserAge_Success()
        {

            Mock<IDatabaseConnection> databaseConnectionMock = new Mock<IDatabaseConnection>();
            databaseConnectionMock
                .Setup(x => x.UpdateUserAge("john", 30))
                .Returns(true);

            bool result = databaseConnectionMock.Object.UpdateUserAge("john", 30);

            databaseConnectionMock.Verify(x => x.UpdateUserAge("john", 30), Times.Once);

            Assert.True(result);
        }

        [Fact]
        [Trait("Category", "Mock DAL")]
        public void Login_Success()
        {

            Mock<IDatabaseConnection> databaseConnectionMock = new Mock<IDatabaseConnection>();
            databaseConnectionMock
                .Setup(x => x.Login("john", "password"))
                .Returns(true);


            bool result = databaseConnectionMock.Object.Login("john", "password");

            databaseConnectionMock.Verify(x => x.Login("john", "password"), Times.Once);

            Assert.True(result);
        }
    }
}
