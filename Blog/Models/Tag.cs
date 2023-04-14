using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
