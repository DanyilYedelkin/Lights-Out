using System.Collections.Generic;
using LightsOffCore.Entity;


namespace LightsOffCore.Service
{
    public interface ICommentService
    {
        void AddComment(Comment comment);

        IList<Comment> GetComments();

        void ResetComment();
    }
}
