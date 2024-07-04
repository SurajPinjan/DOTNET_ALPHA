using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Aspose.Email;
using Aspose.Email.Clients.Smtp;
using System.IO;

namespace AutomateLIMS.Services
{
    static class UtilService
    {
        public static bool isDayOfWeek(string day)
        {
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            return true;
        }
    }
}
