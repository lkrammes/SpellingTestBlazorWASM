namespace SpellingTestBlazor.Data.Services
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    #endregion

    #region using

    #endregion

    public class SpellingTestService
    {
        private readonly ApplicationDbContext _dbContext;

        public SpellingTestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SpellingTest>> GetSpellingTestsAsync()
        {
            return await _dbContext.SpellingTests.ToListAsync();
        }

        public async Task AddSpellingTestAsync(SpellingTest test)
        {
            await _dbContext.SpellingTests.AddAsync(test);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SpellingTest> GetSpellingTestAsync(Guid testId)
        {
            return await _dbContext.SpellingTests.FindAsync(testId);
        }

        public async Task<IEnumerable<SpellingTestQuestion>> GetSpellingTestQuestionsAsync(Guid testId)
        {
            SpellingTest test = await _dbContext.SpellingTests.FindAsync(testId);

            string[] words = test.SpellingWords.Split(new[] { "\r\n", "\r", "\n", ",", "|" }, StringSplitOptions.RemoveEmptyEntries);

            return words.Select(word => new SpellingTestQuestion
                                        {
                                            Word = word
                                        })
                        .OrderBy(question => Guid.NewGuid()).ToList();
        }

        public async Task UpdateSpellingTestAsync(SpellingTest test)
        {
            var t = await GetSpellingTestAsync(test.Id);
            t.SpellingWords = test.SpellingWords;
            t.TestName = test.TestName;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid testId)
        {
            SpellingTest test = await GetSpellingTestAsync(testId);
            _dbContext.Remove(test);
            await _dbContext.SaveChangesAsync();
        }
    }
}
