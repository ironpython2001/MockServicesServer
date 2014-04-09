using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;

namespace MockServices.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            ////http://blogs.telerik.com/fiddler/posts/13-01-14/manipulating-traffic-with-fiddler-extensions
            //#region ATTACH EVENT LISTENERS
            //FiddlerApplication.BeforeRequest += new SessionStateHandler(FiddlerApplication_BeforeRequest);
            //FiddlerApplication.BeforeResponse += new SessionStateHandler(FiddlerApplication_BeforeResponse);
            //#endregion

            //IMockServicesServerSettings imss = new MockServicesServerSettings();

            //int portNo = imss.Port ;

            //FiddlerApplication.Startup(portNo, FiddlerCoreStartupFlags.Default);

            //Console.WriteLine("Started Server..");



            //Console.WriteLine("Hit CTRL+C to end session.");
            //for (; ; )
            //{ }



            IMockServicesServerSettings serverSettings = new MockServicesServerSettings();

            IMockServicesServerApplication server = new MockServicesServerApplication();
            server.Start(serverSettings.Port);


            Console.WriteLine("Hit CTRL+C to end session.");

            ConsoleKeyInfo cki;

            for (; ; )
            {
                cki = Console.ReadKey();

                if (cki.Modifiers == ConsoleModifiers.Control)
                {
                    if (cki.Key.ToString() == "c")
                    {
                        server.Shutdown();
                        break;
                    }
                }
            }




        }

        //static void FiddlerApplication_BeforeRequest(Session oSession)
        //{
        //    //FiddlerApplication.Log.LogFormat(oSession.fullUrl);
        //    Console.WriteLine(oSession.fullUrl);

        //}


        //static void FiddlerApplication_BeforeResponse(Session oSession)
        //{
        //    oSession.utilSetResponseBody("asdfasdF");
        //    Console.WriteLine(oSession.GetResponseBodyAsString());

        //}
    }
}
