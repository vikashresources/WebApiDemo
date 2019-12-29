using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiDemo
{
    public class CustomMediaTypeMapping : MediaTypeMapping
    {
        public CustomMediaTypeMapping(MediaTypeHeaderValue mediaType)
            : base(mediaType)
        { }

        //protected override double OnTryMatchMediaType(HttpResponseMessage response)
        //{
        //    if (response.RequestMessage.Headers.Accept.Count(m => m.MediaType == "text/custom-type") > 0)
        //        return 1.0;
        //    return 0.0;
        //}
        
        public override double TryMatchMediaType(HttpRequestMessage request)
        {
           // return (request.Headers.Accept.ToString() == "text/custom-type") ? 1.0 : 0.0;
           return (request.Headers.AcceptLanguage.ToString() == "en-FR") ? 1.0 : 0.0;
       
        }
    }
}