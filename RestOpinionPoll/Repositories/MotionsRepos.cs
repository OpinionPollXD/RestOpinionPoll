using Microsoft.EntityFrameworkCore;
using RestOpinionPoll.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace RestOpinionPoll.Repositories
{
    public class MotionsRepos
    {
        OpinionPollContext context;

        public MotionsRepos(OpinionPollContext service)
        {
            this.context = service;
        }

        public Motion AddMotion(Motion motion)
        {
            context.Motion.Add(motion);
            context.SaveChanges();
            return motion;
        }

        public IEnumerable<Motion> GetAllMotions()
        {
            List<Motion> motions = new(context.Motion.AsNoTracking().ToList());
            return motions;

        }
    }
}
