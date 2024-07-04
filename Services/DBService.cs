using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using AutomateLIMS.Services;

namespace AutomateLIMS.Jobs
{

    // create a job class which extends IJob
    public class DBJob
    {
        public void runDBQuery(string query)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");

            IConfiguration configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnectionString") ?? string.Empty;

            System.Console.WriteLine(connectionString);

            using (GetConfigService configService = new GetConfigService())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = configService.getsqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                System.Console.WriteLine(sdr[0]);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}
