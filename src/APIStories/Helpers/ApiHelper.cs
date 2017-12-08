using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIStories.Helpers
{
    public static class ApiHelper
    {
        public static string GetImageRoute(this ApiController apiController, int idImage)
        {
            return apiController.Url.Link("Image", new {id = idImage});
        }
    }
}