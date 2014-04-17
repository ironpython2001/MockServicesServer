using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockServices.Contracts;


namespace MockServices.Server.Scenario2Test
{
    public class CodeProjectBlocker:IMockService
    {
        public string Run()
        {
            return "Invalid Site";
        }
    }
}
