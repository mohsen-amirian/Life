using LifeService.Models;
using LifeService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeService.Controllers
{
    [Route("api/Word")]
    [ApiController]
    public class WordController: ControllerBase
    {

        private readonly IDataRepository<Word> _wordRepository;
        public WordController(IDataRepository<Word> wordRepository)
        {
            _wordRepository = wordRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Word> Words = _wordRepository.GetAll();
            return Ok(Words);
        }

        // GET: api/Word/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Word Word = _wordRepository.Get(id);
            if (Word == null)
            {
                return NotFound("The Word record couldn't be found.");
            }
            return Ok(Word);
        }

        // POST: api/Word
        [HttpPost]
        public IActionResult Post([FromBody] Word Word)
        {
            if (Word == null)
            {
                return BadRequest("Word is null.");
            }
            _wordRepository.Add(Word);
            return CreatedAtRoute(
                  "Get",
                  new { Id = Word.WordId },
                  Word);
        }

        // PUT: api/Word/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Word Word)
        {
            if (Word == null)
            {
                return BadRequest("Word is null.");
            }

            Word WordToUpdate = _wordRepository.Get(id);
            if (WordToUpdate == null)
            {
                return NotFound("The Word record couldn't be found.");
            }
            _wordRepository.Update(Word);
            return NoContent();
        }

        // DELETE: api/Word/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Word Word = _wordRepository.Get(id);
            if (Word == null)
            {
                return NotFound("The Word record couldn't be found.");
            }
            _wordRepository.Delete(Word);
            return NoContent();
        }
    }
}
