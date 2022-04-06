using System;

namespace myApp.core
{
    public class DatabaseSettings
    {
        public string Server { get; set; }
        public string Provider { get; set; }
        public string Database { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }





        public DatabaseSettings OptionsMethodA(DatabaseSettings options)
        {
            if (options.Provider.ToLower().Trim().Equals("mysqlserver"))
            {
                options.Provider = "serkanlkaymadfasdfajdgkıjasldkgfklasdjf";

            }
            else
            {
                Console.WriteLine("false");

            }
            return options;
        }


    }
}
