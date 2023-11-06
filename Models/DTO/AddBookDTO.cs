namespace BookManagementAPI.Models.DTO
{
    public class AddBookDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int CategoryID { get; set; }

        public IFormFile File { get; set; }
    }
}
