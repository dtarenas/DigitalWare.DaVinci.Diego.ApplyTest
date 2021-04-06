namespace DigitalWare.DaVinci.Diego.ApplyTest.Presentation
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Program Class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Host Instance</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}