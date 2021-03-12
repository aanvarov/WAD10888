using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD._10888.APP
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var user1 = new LibraryUser("Jonh", "Smith", "jonny", "john2288@gmail.com", "nimagap");
            SubscribeUser.SubscribeLibUser(user1.Email);
            GetAllPropertiesValue.GetPropertyValues(user1);


            Console.WriteLine(user1.Email);
            Console.WriteLine(user1.Name);
            Console.WriteLine(user1.Surname);
            Console.WriteLine(user1.Password);
            Console.WriteLine(user1.Nickname);




            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
    }
}
