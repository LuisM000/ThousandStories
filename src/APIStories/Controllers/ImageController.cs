using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Model;
using Model.Services;

namespace APIStories.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        private readonly IImageService imageService;
        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        // GET api/image/5
        public IHttpActionResult Get(int id)
        {
            Image image = imageService.GetImage(id);
            if (image == null)
                return NotFound();

            var response = CreateImageResponse(image.ImageData?.Content);
            return ResponseMessage(response);
        }

        private static HttpResponseMessage CreateImageResponse(byte[] imageData)
        {
            if (imageData == null)
                return new HttpResponseMessage(HttpStatusCode.NoContent);

            MemoryStream ms = new MemoryStream(imageData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}
