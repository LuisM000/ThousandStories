using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Order;


namespace Model.Services
{
    public interface IStoryService
    {
        Story GetStory(int idStory);
        IPagedList<Story> GetLastestStories(string language, Pagination pagination);

        IPagedList<Story> GetStoriesWithText(string text, string language, Pagination pagination,
            IOrdering<Story> orderBy);

        void InsertAndSave(Story story);
    }
}
