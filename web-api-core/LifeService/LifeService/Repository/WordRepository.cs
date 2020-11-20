using LifeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeService.Repository
{
    public class WordRepository : IDataRepository<Word>
    {
        readonly LifeContext _lifeContext;

        public WordRepository(LifeContext context)
        {
            _lifeContext = context;
        }

        public IEnumerable<Word> GetAll()
        {
            return _lifeContext.Words.ToList();
        }

        public Word Get(long id)
        {
            return _lifeContext.Words.FirstOrDefault(w => w.WordId == id);
        }

        public void Add(Word word)
        {
            word.CreationDate = DateTime.Now;
            _lifeContext.Words.Add(word);
            _lifeContext.SaveChanges();
        }

        public void Delete(Word word)
        {
            _lifeContext.Words.Remove(word);
            _lifeContext.SaveChanges();
        }

        public void Update(Word word)
        {
            var oldWord = Get(word.WordId);
            oldWord.Text = word.Text;
            oldWord.Meaning = word.Meaning;

            _lifeContext.SaveChanges();
        }
    }
}
