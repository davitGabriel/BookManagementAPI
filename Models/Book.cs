using BookManagementAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }
    }
}
