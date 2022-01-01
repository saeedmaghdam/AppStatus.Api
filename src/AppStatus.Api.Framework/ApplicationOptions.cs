namespace AppStatus.Api.Framework
{
    public class ApplicationOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string JwtSecret { get; set; } = null!;
        public int MaximumItemsInDashboard { get; set; } = 10;
    }
}
