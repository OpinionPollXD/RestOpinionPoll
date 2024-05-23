using System.ComponentModel.DataAnnotations.Schema;

namespace RestOpinionPoll.Models
{
    public partial class Category
    {
        public string? CategoryName { get; set; }

        [InverseProperty("Category")]
        public virtual Question Question { get; set; }
    }
}
