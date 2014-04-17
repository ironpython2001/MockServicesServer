using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Xml.Linq;

namespace MockServices.Server
{

    public class MockServicesServerApplication:IMockServicesServerApplication
    {

        public MockServicesServerApplication()
        {
            FiddlerApplication.BeforeRequest += new SessionStateHandler(FiddlerApplication_BeforeRequest);
            FiddlerApplication.BeforeResponse += new SessionStateHandler(FiddlerApplication_BeforeResponse);
        }


        public void Start(int portNo)
        {
            FiddlerApplication.Startup(portNo, FiddlerCoreStartupFlags.Default);
            Console.WriteLine("Started Server at Port No.. " + portNo.ToString() );

        }


        public void Shutdown()
        {
            FiddlerApplication.Shutdown();
        }


        static void FiddlerApplication_BeforeRequest(Session oSession)
        {
            //FiddlerApplication.Log.LogFormat(oSession.fullUrl);
            Console.WriteLine(oSession.fullUrl);

        }


        static void FiddlerApplication_BeforeResponse(Session oSession)
        {

            string s = string.Empty;

            s = oSession.utilGetResponseBodyFromHandler();
            if (s == string.Empty)
            { }
            else
            { oSession.utilSetResponseBody(s); }
            Console.WriteLine(oSession.GetResponseBodyAsString());

        }

    }
}
