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

        /*public Question GetQuestion(int id)
        {
            return context.Question.AsNoTracking().FirstOrDefault(q => q.QuestionId == id);
        }*/

        public Question? UpdateQuestion(int id, Question question)
        {
            Question? questionToUpdate = context.Question.FirstOrDefault(q => q.QuestionId == id);
            if (questionToUpdate != null)
            {
                questionToUpdate.QuestionText = question.QuestionText;
                questionToUpdate.Category = question.Category;
                questionToUpdate.Option1 = question.Option1;
                questionToUpdate.Option2 = question.Option2;
                questionToUpdate.Option3 = question.Option3;
                questionToUpdate.Active = question.Active;
                question.Validate();
                context.SaveChanges();

            }
            return questionToUpdate;
        }

        public Question? DeleteQuestion(int id)
        {
            Question? questionToDelete = context.Question.FirstOrDefault(q => q.QuestionId == id);
            if (questionToDelete != null)
            {
                context.Question.Remove(questionToDelete);
                context.SaveChanges();
            }
            return questionToDelete;
        }

        public Question? SubmitAnswer(int id, int option)
        {
            Question? questionToUpdate = context.Question.FirstOrDefault(q => q.QuestionId == id);
            if (questionToUpdate != null)
            {
                switch (option)
                {
                    case 1:
                        questionToUpdate.Option1Count++;
                        break;
                    case 2:
                        questionToUpdate.Option2Count++;
                        break;
                    case 3:
                        questionToUpdate.Option3Count++;
                        break;
                    default:
                        throw new ArgumentException("Invalid option");
                }
                context.SaveChanges();
            }
            return questionToUpdate;
        }

        public IEnumerable<Question> GetActiveQuestions()
        {
            List<Question> questions = new(context.Question.AsNoTracking().ToList());
            questions = questions.FindAll(q => q.Active == true);
            return questions;

        }
    }
}
