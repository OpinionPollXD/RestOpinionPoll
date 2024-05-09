using RestOpinionPoll.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestOpinionPoll.Repositories
{
   
    public class QuestionsRepos
    {
        OpinionPollContext context;

        public QuestionsRepos(OpinionPollContext service)
        {
            this.context = service;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return context.Question.AsNoTracking().ToList();
        }
    }
}
