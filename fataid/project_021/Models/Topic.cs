
using System;
using System.Collections.Generic;
namespace project_021.Models
{
    public class Topic
    {
        public Topic()
        {
            ID = Guid.NewGuid();
            Posts = new List<Post>();
        }
        //public Topic(bool isPrivate, bool isEnabled, string title)
        //:this() {
        //    IsPrivate=isPrivate;
        //    IsEnabled=isEnabled;
        //    Title=title;
        //}
        public Topic(bool isPrivate, bool isEnabled, string title, params Post[] posts)
        : this()
        {
            IsPrivate = isPrivate;
            IsEnabled = isEnabled;
            Title = title;
            Posts.AddRange(posts);
        }
        public Topic(Random rnd, params Post[] posts)
        : this(rnd.Next(2) == 1, rnd.Next(2) == 1, $"title_{ rnd.Next(100)}", posts)
        {
        }
        public static Topic[] Factory(int count, Random rnd)
        {
            Topic[] topics = new Topic[count];
            for (int i = 0; i < count; i++)
            {
                topics[i] = new Topic(rnd, Post.Factory(rnd.Next(5),rnd));
            }
            return topics;
        }
        public Guid ID { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsEnabled { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}