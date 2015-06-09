using System.Web.Mvc;
using MartinBank.Core.Interfaces;
using MartinBank.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MartinBank.Tests.MartinBank.Web.Controllers
{
    [TestClass]
    public class ChequeGeneratorControllerTests
    {
        private Mock<ILoggingService> loggingServiceMock;
        private Mock<IWebConfigurationSettings> webConfigurationSettings;
        private ChequeGeneratorController controller;

        [TestInitialize]
        public void Start()
        {
            loggingServiceMock = new Mock<ILoggingService>();
            webConfigurationSettings = new Mock<IWebConfigurationSettings>();
            controller = new ChequeGeneratorController(loggingServiceMock.Object, webConfigurationSettings.Object);
        }

        [TestMethod]
        public void ChequeGeneratorController_IsController_Returns_True()
        {
            Assert.IsInstanceOfType(controller, typeof(IController));
        }

        [TestMethod]
        public void ChequeGeneratorController_Returns_ValidIndexViewResult()
        {
            // act
            var output = controller.Index();
            var viewResult = output as ViewResult;

            // assert
            Assert.IsNotNull(viewResult, "No view is displayed");
        }

        [TestCleanup]
        public void End()
        {
            controller = null;
        }
    }
}
