using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.LanguageRepository;

namespace Model.Services
{
    public class LanguageService:ILanguageService
    {
        private readonly ILanguageRepository languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }
        public IList<Language> GetLanguages()
        {
            return languageRepository.GetAll().ToList();
        }
    }
}
