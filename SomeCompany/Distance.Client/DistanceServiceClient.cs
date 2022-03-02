namespace Distance.Client
{
    public class DistanceServiceClient: IDistanceServiceClient
    {
        private readonly HttpClient _apiClient;

        public DistanceServiceClient(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<double> GetDistance(string fromIata, string toIata)
        {
            var response = await _apiClient.GetAsync($"airports/{fromIata}/distance/{toIata}");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = double.Parse(responseBody);

            return result;
        }
    }
}