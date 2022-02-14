using System.Threading.Tasks;
using Distance.Client;
using Distance.FunctionalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Distance.IntegrationTests
{
    [TestClass]
    public class AirportsTests
    {
        [TestMethod]
        public async Task Get_distance_between_airports()
        {
            using var server = new DistanceScenariosBase().CreateServer();

            var serverClient = server.CreateClient();
            var distanceClient = new DistanceServiceClient(serverClient);
            var distance = await distanceClient.GetDistance("AMS", "BER");

            Assert.IsTrue(distance > 0, "Distance is not right");
        }
    }
}