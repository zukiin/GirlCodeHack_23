using System;
using she_innovates.Data;

namespace she_innovates.Models
{
    public class PostService
    {
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Post> GetAllPosts()
        {
            return _dbContext.Posts.ToList();
        }

        public Post GetPostById(int postId)
        {
            return _dbContext.Posts.Find(postId);
        }

        public void CreatePost(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
    }

    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implement methods to handle user-related operations if needed.
    }

}