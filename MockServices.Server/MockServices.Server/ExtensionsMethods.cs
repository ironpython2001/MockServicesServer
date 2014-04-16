using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fiddler;

namespace MockServices.Server
{
    public static class ExtensionsMethods
    {

        public static string utilGetResponseBodyFromHandler(this Session oSession)
        {
            var responseHandlerFileName = string.Empty;

            #region Get Handler File Name
            {
                XDocument xdoc = XDocument.Load(@"MockServices.xml");
                var request = (from r in xdoc.Descendants("Request")
                               where r.Attribute("Url").Value == oSession.fullUrl
                               select new
                               {
                                   Url = r.Attribute("Url").Value,
                                   FileName = r.Attribute("ResponseHandlerFileName").Value
                               }).FirstOrDefault();

                if (request == null)
                {
                    //nothing to do
                }
                else
                {
                    responseHandlerFileName = request.FileName;
                }
            }
            #endregion

            string responseBody = string.Empty;



            #region Read Response Handler File
            {
                //XDocument xdoc = XDocument.Load(@responseHandlerFileName);
                //var request = (from r in xdoc.Descendants("Response")
                //               where r.Attribute("Url").Value == oSession.fullUrl
                //               select new
                //               {
                //                   Url = r.Attribute("Url").Value,
                //                   FileName = r.Attribute("ResponseHandlerFileName").Value
                //               }).FirstOrDefault();
                
            }
            #endregion



            return responseBody;


        }

    }
}
