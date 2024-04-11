using System;
using System.Collections.Generic;

namespace AbstractionYouTubeVideos
{
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            LengthInSeconds = length;
            Comments = new List<Comment>();
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Create videos and comments
            Video video1 = new Video("Video 1", "Author 1", 120);
            video1.Comments.Add(new Comment("User 1", "Comment 1"));
            video1.Comments.Add(new Comment("User 2", "Comment 2"));

            Video video2 = new Video("Video 2", "Author 2", 180);
            video2.Comments.Add(new Comment("User 3", "Comment 3"));
            video2.Comments.Add(new Comment("User 4", "Comment 4"));

            videos.Add(video1);
            videos.Add(video2);

            // Display video details and comments
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}
