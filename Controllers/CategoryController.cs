using BookManagementAPI.Implementation;
using BookManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CategoryDTO> GetCategory(int id)
        {
            try
            {
                return Ok(categoryManager.GetCategory(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            try
            {
                return Ok(categoryManager.GetCategories());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDTO category)
        {
            try
            {
                categoryManager.AddCategory(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                categoryManager.DeleteCategory(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
