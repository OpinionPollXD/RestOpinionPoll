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
            Question question = new Question()
            {
                QuestionText = "What is your favorite color?",
                Category = "Color",
                Option1 = "Red",
                Option2 = "Blue",
                Option3 = "Green",
                Option1Count = 0,
                Option2Count = 0,
                Option3Count = 0
            };
            Question AddedQuestion = _questionsRepo.AddQuestion(question);
            Assert.AreEqual(6,AddedQuestion.QuestionId);
            Assert.AreEqual(6, _dbContext.Question.Count());
                

        }
    }
}