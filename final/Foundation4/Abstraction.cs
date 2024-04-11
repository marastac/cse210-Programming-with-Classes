using System;
using System.Collections.Generic;

namespace YouTubeVideoAbstraction
{
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
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

            Video video1 = new Video("Video 1", "Author 1", 120);
            video1.Comments.Add(new Comment("User1", "Great video!"));
            video1.Comments.Add(new Comment("User2", "Awesome content!"));
            videos.Add(video1);

            Video video2 = new Video("Video 2", "Author 2", 180);
            video2.Comments.Add(new Comment("User3", "Nice job!"));
            videos.Add(video2);

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine();
            }
        }
    }
}
