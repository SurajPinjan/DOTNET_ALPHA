using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Aspose.Email;
using Aspose.Email.Clients.Smtp;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace AutomateLIMS.Services
{
    public class GetConfigService : IDisposable
    {
        public string getConf(string key, string subKey)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            IConfigurationSection mailConfigurations = configuration.GetSection(key);
            string value = mailConfigurations?.GetValue<string>(subKey);
            return value;
        }

        public void Dispose()
        {

        }

        public SqlCommand getsqlCommand(string procName) {
            SqlCommand cmd = new SqlCommand(procName);
            cmd.CommandTimeout = 4 * 60;
            return cmd;
        }
    }
}
