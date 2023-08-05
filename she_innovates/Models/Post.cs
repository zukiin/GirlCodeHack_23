using System;
namespace she_innovates.Models
{
	public class Post
	{
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreationDate { get; set; }
        // Other properties like UserId, MediaUrl, etc., depending on your requirements.
    }
}

