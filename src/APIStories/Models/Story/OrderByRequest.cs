﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIStories.Models.Enums;
using Infrastructure.Order;
using Model;

namespace APIStories.Models.Story
{
    public class OrderByRequest
    {
        public OrderByRequest(OrderBy order)
        {
            this.Order = order;
        }
        public OrderBy Order { get; }

        public IOrdering<Model.Story> GetOrdering()
        {
            switch (Order)
            {
                case OrderBy.Date:
                    return new StoryOrderByDate();
                case OrderBy.Rating:
                    return new StoryOrderByRating();
                default:
                    return new StoryOrderByDate();
            }
        }
    }
}