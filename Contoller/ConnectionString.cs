﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LakesApp
{
    class ConnectionString
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LakesApp.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}