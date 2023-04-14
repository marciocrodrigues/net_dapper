using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Role]")]
    public class Role : BaseModel
    {
        public string Name { get; set; }
    }
}
