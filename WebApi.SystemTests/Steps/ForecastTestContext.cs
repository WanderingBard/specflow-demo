namespace WebApi.SystemTests.Steps
{
    public class ForecastTestContext : IDisposable
    {
        public string PlaceName { get; internal set; }
        public HttpResponseMessage ApiResponse { get; internal set; }

        public void Dispose()
        {
            ApiResponse.Dispose();
        }
    }
}