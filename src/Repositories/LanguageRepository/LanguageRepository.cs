using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databases.Factories;
using Model;

namespace Repositories.LanguageRepository
{
    public class LanguageRepository: BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(IFactoryDB factoryDB) : base(factoryDB)
        {
        }
    }
}
