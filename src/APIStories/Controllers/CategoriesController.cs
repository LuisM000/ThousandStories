using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIStories.Models.Category;
using Databases.Factories;
using Databases.Initializers;
using Model;
using Model.Services;
using Repositories;

namespace APIStories.Controllers
{
    
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET api/categories
        public IHttpActionResult Get()
        {
            var categories = this.categoryService.GetCategories();
            if (categories == null)
                return NotFound();


            return Ok(categories.Select(c => new CategoryResponse(c)).ToList());
        }

    }
}
