using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
    }
}
