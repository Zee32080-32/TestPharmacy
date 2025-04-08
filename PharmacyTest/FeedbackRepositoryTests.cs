using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using PharmacyApp.Data;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyTest
{
    public class FeedbackRepositoryTests
    {
        private readonly DbContextOptions<ApplicationdbContext> _options;

        public FeedbackRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationdbContext>()
                .UseInMemoryDatabase("FeedbackForm").Options;
        }

        private ApplicationdbContext createDbContext() => new ApplicationdbContext(_options);

        [Fact]
        public async Task addasync_ShouldCreateForm()
        {
            //need db context
            // need feedback repos
            // need an instance of the method I am testing 
            // execute the method 
            //check if we have the value (result)
            //assert 

            var db = createDbContext();
            var repository = new FeedbackFormRepository(db);

            var feedbackform = new FeedbackForm
            {
                Title = "Test Title",
                Description = "Description",
                CustomerID = "1234"

            };

            await repository.AddAsync(feedbackform);
            await db.SaveChangesAsync(); 

            var result = await db.FeedbackForm.SingleOrDefaultAsync(f => f.Title == "Test Title");
            
            Assert.NotNull(result);
            Asset.Equals("Test Title", result.Title);

        }
    }
}

