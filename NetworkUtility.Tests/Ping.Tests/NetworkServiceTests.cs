using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.Ping.Tests
{
    public class NetworkServiceTests
    {
        // Make sure that the test project refrences the actual project where we have the methods that we wanna test
        // Remember to add the fluent assertions package used to enhance the test capabilities of our project
        // Naming convention to name test methods
        // <ClassName>_<MethodName>_<Behavior>
        [Fact]
        public void NetworkService_SendPing_ReturnAString()
        {
            // Arrange - variables, classes, mocks
            var pingService = new NetworkService();

            // Act 
            var result = pingService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
    }
}
