using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;


namespace Model.Services
{
    public interface IStoryService
    {
        Story GetStory(int idStory);
        IEnumerable<Story> GetLastestStories(string language, Pagination pagination);
    }
}
