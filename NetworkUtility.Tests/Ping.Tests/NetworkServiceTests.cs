using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.Ping.Tests
{
    public class NetworkServiceTests
    {
        // We need this field to be available globally and accessed by the all the methods defined below
        private readonly NetworkService _pingService;
        public NetworkServiceTests()
        {
            // We are defining a SUT (System Under Test)
            // Instead for recreating the object each time in the body of each function 
            // We can just use this instance
            _pingService = new NetworkService();
        }

        // Make sure that the test project refrences the actual project where we have the methods that we wanna test
        // Remember to add the fluent assertions package used to enhance the test capabilities of our project
        // Naming convention to name test methods
        // <ClassName>_<MethodName>_<Behavior>
        [Fact]
        public void NetworkService_SendPing_ReturnAString()
        {
            // Arrange - variables, classes, mocks
            // var pingService = new NetworkService();

            // Act 
            var result = _pingService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        // Theory will allow is to pass inline data
        // With the InLineData we are going to define our test cases
        // In this case our function requires arguments and to do so we used InlineData
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            // var pingService = new NetworkService();

            // Act
            var result = _pingService.PingTimeout(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            // Arrange 
            // ...

            // Act
            var result = _pingService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.GetPingOptions();

            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.MostRecentPings();

            // Assert
            result.Should().BeOfType<PingOptions[]>(); // Performing a type test
            result.Should().ContainEquivalentOf(expected); // Each time of the collection must equal to the expected
            result.Should().Contain(x => x.DontFragment == true); // One of the items has the field DontFragment set to true
        }
    }
}
