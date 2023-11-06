using AutoMapper;
using BookManagementAPI.DataBase;
using BookManagementAPI.Models;
using BookManagementAPI.Models.DTO;

namespace BookManagementAPI.Implementation
{
    public class CategoryManager : BaseManager
    {
        public CategoryManager(BooksDBContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }

        public void AddCategory(CategoryDTO category)
        {
            Category newCategory = Mapper.Map<Category>(category);

            Context.Categories.Add(newCategory);
            Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = Context.Categories.Find(id);

            Context.Categories.Remove(category);
            Context.SaveChanges();
        }

        public CategoryDTO GetCategory(int id)
        {
            Category category = Context.Categories.Find(id);
            CategoryDTO categoryDTO = Mapper.Map<CategoryDTO>(category);

            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var allCategories = Context.Categories.ToList();
            var map = Mapper.Map<List<Category>, List<CategoryDTO>>(allCategories);

            return map;
        }
    }
}
