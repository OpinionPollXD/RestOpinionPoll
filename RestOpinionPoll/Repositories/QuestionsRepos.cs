﻿using RestOpinionPoll.Models;
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
            question.Validate();
            context.Question.Add(question);
            context.SaveChanges();
            return question;
        }

        /*public Question GetQuestion(int id)
        {
            return context.Question.AsNoTracking().FirstOrDefault(q => q.QuestionId == id);
        }*/

        public Question? UpdateQuestion(Question question)
        {
            Question? questionToUpdate = context.Question.FirstOrDefault(q => q.QuestionId == question.QuestionId);
            if (questionToUpdate != null)
            {
                questionToUpdate.QuestionText = question.QuestionText;
                questionToUpdate.Category = question.Category;
                questionToUpdate.Option1 = question.Option1;
                questionToUpdate.Option2 = question.Option2;
                questionToUpdate.Option3 = question.Option3;
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
    }
}
