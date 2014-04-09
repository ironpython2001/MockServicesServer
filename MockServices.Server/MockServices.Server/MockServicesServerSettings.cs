using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MockServices.Server
{
    public class MockServicesServerSettings:IMockServicesServerSettings
    {
        public int Port
        {
            get 
            {
                return int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            }
        }
    }
}
