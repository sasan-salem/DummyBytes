using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DotNet.Controller
{
    public class DummyBytesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage Response;

            string UserAgent = HttpContext.Current.Request.UserAgent;
            if(UserAgent.Contains("Instagram"))
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK);
                Response.Content = new ByteArrayContent(new byte[50]);
                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return Response;
            }
            else
            {
                Response = Request.CreateResponse(HttpStatusCode.Redirect);
                Response.Headers.Location = new Uri("https://mywebsite.com");
                return Response;
            }
        }
    }
}
