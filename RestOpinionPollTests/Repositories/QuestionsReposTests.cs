using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOpinionPoll.Models;
using RestOpinionPoll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestOpinionPoll;


namespace RestOpinionPoll.Repositories.Tests
{
    [TestClass()]
    public class QuestionsReposTests
    {
        public static OpinionPollContext _dbContext;
        private QuestionsRepos _questionsRepo;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OpinionPollContext>();
            optionsBuilder.UseSqlServer(SecretDB.connectionString);
            _dbContext = new OpinionPollContext(optionsBuilder.Options);
            
        }

        [TestMethod()]
        public void GetQuestionsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddQuestionTest()
        {
            Assert.Fail();
        }
    }
}