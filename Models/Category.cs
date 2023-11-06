using BookManagementAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}
