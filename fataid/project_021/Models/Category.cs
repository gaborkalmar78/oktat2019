
using System;
using System.Collections.Generic;

namespace project_021.Models
{
    public class Category
    {
        public Category()
        {
            Topics = new List<Topic>();
            ID = Guid.NewGuid();
        }
        /*
        public Category (string title)
        :this()
	    {
            Title=title;

	    }
        public Category (string title, Topic[] topics)
        :this(title)
	    {
            Topics.AddRange(topics);
            for(int i=0; i<topics.Length; i++) {
                Topics.Add(topics[i]);
            }

	    }*/
        public Category (string title, params Topic[] topics)
        :this()
	    {
            Title = title;
            Topics.AddRange(topics);

        }
        public Category(System.Random rnd, params Topic[] topics)
        : this($"title_00{rnd.Next(100)}", topics)
        {
        }
        public static Category[] Factory(int count, Random rnd)
        {
            Category[] categories = new Category[count];
            for(int i=0; i<count; i++)
            {
                categories[i] = new Category(rnd, Topic.Factory(rnd.Next(5), rnd));
            }
            return categories;
        }

        public string Title { get; set; }
        public Guid ID { get; }
        public List<Topic> Topics { get; set; }
    }
}