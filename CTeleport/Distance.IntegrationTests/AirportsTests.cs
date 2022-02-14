using Distance.Client;
using Distance.FunctionalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

        [TestMethod]
        public async Task Throw_429_when_too_many_requests()
        {
            using var server = new DistanceScenariosBase().CreateServer();

            var distanceTasks = Enumerable.Range(0, 5).Select(_ =>
            {
                var request = server.CreateRequest("/airports/AMS/distance/BER");

                return request.GetAsync();
            }).ToList();

            await Task.WhenAll(distanceTasks);

            Assert.IsTrue(distanceTasks.Any(task => task.Result.StatusCode == HttpStatusCode.TooManyRequests));
        }
    }
}