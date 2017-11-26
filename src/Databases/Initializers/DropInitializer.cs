﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Databases.Initializers
{
    public class DropInitializer : DropCreateDatabaseAlways<DataBaseSQL>
    {
        protected override void Seed(DataBaseSQL context)
        {
            base.Seed(context);
            context.Languages.AddRange(new List<Language>()
            {
                new Language() {LanguageIdentifier = "es"},
                new Language() {LanguageIdentifier = "en"},
            });

            context.Stories.AddRange(new List<Story>()
            {
                new StoryBuilder().WithTitle("Historia 1").WithLanguage(Languages.es).WithPublishDate(DateTime.Now),
                new StoryBuilder().WithTitle("Historia 2").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(1)),
                new StoryBuilder().WithTitle("Historia 3").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(2)),
                new StoryBuilder().WithTitle("Historia 4").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(3)),
                new StoryBuilder().WithTitle("Historia 5").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(4)),
                new StoryBuilder().WithTitle("Historia 6").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(5)),
                new StoryBuilder().WithTitle("Historia 7").WithLanguage(Languages.es).WithPublishDate(DateTime.Now.AddSeconds(6)),
            });

        }
    }

    }