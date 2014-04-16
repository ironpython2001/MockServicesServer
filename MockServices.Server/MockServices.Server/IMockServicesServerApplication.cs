using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockServices.Server
{
    public interface IMockServicesServerApplication
    {

        void Start(int portNo);

        void Shutdown();

    }

}
