namespace Task4.Configuration
{
    public static class Configuration
    {
        public static string BaseUri => ServicesBuilder.Configuration[nameof(BaseUri)];
    }
}
