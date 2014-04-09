using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;

namespace MockServices.Server
{
    public interface IMockServicesServerApplication
    {

        void Start(int portNo);

        void Shutdown();

    }

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
            Console.WriteLine("Started Server..");

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
            //Assembly MyDALL = Assembly.LoadFrom(assemblyName + ".dll");
            //Type MyLoadClass = MyDALL.GetType(className);
            //IExecuteTask myCode = (IExecuteTask)Activator.CreateInstance(MyLoadClass);

            oSession.utilSetResponseBody("asdfasdF");
            Console.WriteLine(oSession.GetResponseBodyAsString());

        }

    }
}
