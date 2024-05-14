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

        public IEnumerable<Question> GetQuestions(string searchQuery = null)
        {
            List<Question> questions = new(context.Question.AsNoTracking().ToList());
            if (searchQuery != null) 
            {
                questions = questions.FindAll(q =>
                q.QuestionText.ToLower().StartsWith(searchQuery.ToLower()) || 
                q.Category.ToLower().StartsWith(searchQuery.ToLower()));
            }
            return questions;
        }

        public Question AddQuestion(Question question)
        {
            question.Validate();
            context.Question.Add(question);
            context.SaveChanges();
            return question;
        }
    }
}
