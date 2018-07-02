using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string Greet();
    }

    public class Greeter : IGreeter
    {
        IConfiguration configuration;

        public Greeter(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string Greet()
        {
            return configuration["Greeting"];
        }
    }
}