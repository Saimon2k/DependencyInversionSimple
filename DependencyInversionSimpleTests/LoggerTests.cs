using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace DependencyInversionSimple.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        [TestMethod()]
        public void LogTest()
        {
            var mock = new Mock<ILogService>();
            var logger = new Logger(mock.Object);

            logger.Log("ping 1");
            mock.Verify(x => x.Write(It.IsAny<string>()), Times.Once());

            logger.Log("ping 2");
            mock.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}