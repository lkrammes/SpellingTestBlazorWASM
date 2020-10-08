namespace SpellingTestBlazor.Data
{
    #region using

    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    #endregion

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpellingTest> SpellingTests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SpellingTest>().HasData(new List<SpellingTest>
                                                   {
                                                       new SpellingTest
                                                       {
                                                           TestName = "Lucas",
                                                           Id = Guid.NewGuid(),
                                                           SpellingWords = string.Join(Environment.NewLine,
                                                                                       new List<string>
                                                                                       {
                                                                                           "test",
                                                                                           "hello"
                                                                                       })
                                                       }
                                                   });
        }
    }
}
