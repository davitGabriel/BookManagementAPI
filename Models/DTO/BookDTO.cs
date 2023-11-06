namespace BookManagementAPI.Models.DTO
{
    public class BookDTO  : BaseDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }
    }
}
