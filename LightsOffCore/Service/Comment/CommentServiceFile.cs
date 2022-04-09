using LightsOffCore.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace LightsOffCore.Service
{
    public class CommentServiceFile : ICommentService
    {
        private const string FileName = "comment.bin";

        private IList<Comment> _comments = new List<Comment>();

        void ICommentService.AddComment(Comment comment)
        {
            _comments.Add(comment);
            SaveComments();
        }

        IList<Comment> ICommentService.GetComments()
        {
            LoadComments();
            return _comments.ToList();
        }

        void ICommentService.ResetComment()
        {
            _comments.Clear();
            File.Delete(FileName);
        }

        private void SaveComments()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _comments);
            }
        }

        private void LoadComments()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _comments = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }
    }
}
