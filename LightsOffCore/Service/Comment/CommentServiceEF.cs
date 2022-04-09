using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LightsOffCore.Entity;


namespace LightsOffCore.Service
{
    public class CommentServiceEF : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using (var context = new LightsOffDbContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public IList<Comment> GetComments()
        {
            using (var context = new LightsOffDbContext())
            {
                //return context.Comments.ToList();
                return context.Comments.OrderByDescending(c => c.PlayedAt).ToList();
            }
        }

        public void ResetComment()
        {
            using (var context = new LightsOffDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Comments");
            }
        }
    }
}