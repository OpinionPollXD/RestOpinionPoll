using RestOpinionPoll.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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

        public Question AddQuestion(Question question)
        {
            context.Question.Add(question);
            question.Validate();
            context.SaveChanges();
            return question;
        }
    }
}
