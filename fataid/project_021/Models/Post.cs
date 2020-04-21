
using System;

namespace project_021.Models
{
    public class Post
    {
        public Post()
        {
        }

        public Post(string createdBy, string content)
            : this()
        {
            CreatedBy = createdBy;
            Content = content;
            CreatedAt = DateTime.Now;
        }
        public Post(string createdBy, string content, DateTime dateTime)
            : this(createdBy, content)
        {
            CreatedAt = dateTime;
        }
        public Post(Random rnd)
            : this($"user_00{rnd.Next(100)}", $"content_00{rnd.Next(10000)}", DateTime.Now.AddDays(7))
        {
        }
        public static Post[] Factory(int count, Random rnd)
        {
            Post[] posts = new Post[count];
            for (int i = 0; i < count; i++)
            {
                posts[i] = new Post(rnd);
            }
            return posts;
        }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
    }
}