﻿using Databases.Factories;
using Infrastructure;
using Infrastructure.Order;
using Infrastructure.Specification;
using Model;
using System.Collections.Generic;

namespace Repositories.StoryRepository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(IFactoryDB factoryDB) : base(factoryDB) { }
 
    }
}
