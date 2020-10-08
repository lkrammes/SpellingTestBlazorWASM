namespace SpellingTestBlazor.Controllers
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Services;
    using Microsoft.AspNetCore.Mvc;
    using Shared;

    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class SpellingTestController : ControllerBase
    {
        private readonly SpellingTestService _spellingTestService;

        public SpellingTestController(SpellingTestService spellingTestService)
        {
           _spellingTestService = spellingTestService;
        }

        [HttpPost("AddSpellingTest")]
        public async Task AddSpellingTest(SpellingTest test)
        {
            await _spellingTestService.AddSpellingTestAsync(test);
        }

        [HttpGet("GetSpellingTest")]
        public async Task<SpellingTest> GetSpellingTest(Guid testId)
        {
            return await _spellingTestService.GetSpellingTestAsync(testId);
        }

        [HttpGet("GetSpellingTests")]
        public async Task<IEnumerable<SpellingTest>> GetSpellingTests()
        {
            return await _spellingTestService.GetSpellingTestsAsync();
        }

        [HttpPut("UpdateSpellingTest")]
        public async Task UpdateSpellingTest(SpellingTest test)
        {
            await _spellingTestService.UpdateSpellingTestAsync(test);
        }

        [HttpDelete]
        public async Task Delete(Guid testId)
        {
            await _spellingTestService.DeleteAsync(testId);
        }

        [HttpGet("GetSpellingTestQuestions")]
        public async Task<IEnumerable<SpellingTestQuestion>> GetSpellingTestQuestions(Guid testId)
        {
            return await _spellingTestService.GetSpellingTestQuestionsAsync(testId);
        }
    }
}
