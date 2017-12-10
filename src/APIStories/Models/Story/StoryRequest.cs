using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIStories.Models.VisualRepresentation;
using Model;
using Language = APIStories.Models.Enums.Language;

namespace APIStories.Models.Story
{ 
    public class StoryRequest
    {
        [Required]
        public Language Language { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public ImagesResponse ImagesResponse { get; set; }

        public Model.Story CreateStory(IList<Model.Language> languages)
        {
            if (languages == null)
                throw new ArgumentNullException(nameof(languages));

            var languageStory = languages.FirstOrDefault(l => l.IsThisLanguage(this.Language.ToString().ToLower()));
            if(languageStory==null)
                throw new Exception("Invalid selected language");


            var story = new Model.Story(this.Title, this.Text, languageStory)
            {
                VisualRepresentation = this.ImagesResponse?.CreateVisualRepresentation()
            };

            return story;
        }
    }


}