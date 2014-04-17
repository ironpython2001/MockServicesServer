using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using Fiddler;
using MockServices.Contracts;

namespace MockServices.Server
{
    public static class ExtensionsMethods
    {

        public static string utilGetResponseBodyFromHandler(this Session oSession)
        {

            #region Get Handler Related Information
            XDocument xdoc = XDocument.Load(@"MockServices.xml");
            var Handler = (from h in xdoc.Descendants("Handler")
                           where h.Attribute("RequestUrl").Value == oSession.fullUrl
                           select new
                           {
                               Name = h.Attribute("Name").Value,
                               Description = h.Attribute("Description").Value,
                               RequestUrl = h.Attribute("RequestUrl").Value,
                               HandlerType = (from r in h.Descendants("Response")
                                              select r.Attribute("HandlerType").Value).FirstOrDefault(),
                               FileName = (from r in h.Descendants("Response")
                                           select r.Attribute("FileName").Value).FirstOrDefault(),

                           }).FirstOrDefault(); 
            #endregion

            string responseBody = string.Empty;

            if (Handler == null)
            {
                //nothing to do
            }
            else
            {
                switch (Handler.HandlerType)
                {
                    case "Static":
                        responseBody = File.ReadAllText(Handler.FileName);
                        break;
                    case "FromAssembly":

                        var assemblyName = Handler.FileName.Split(',')[0].ToString();
                        var className = Handler.FileName.Split(',')[1].ToString();

                        Assembly MyDALL = Assembly.LoadFrom(assemblyName + ".dll");
                        Type MyLoadClass = MyDALL.GetType(className);
                        IMockService myCode = (IMockService)Activator.CreateInstance(MyLoadClass);
                        responseBody =  myCode.Run();
                        break;
                    default:
                        break;
                }
            }

            return responseBody;

        }

    }
}
