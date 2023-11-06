using AutoMapper;
using BookManagementAPI.DataBase;

namespace BookManagementAPI.Implementation
{
    public class BaseManager
    {
        protected BooksDBContext Context { get; set; }

        protected IMapper Mapper { get; set; }

        public BaseManager(BooksDBContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
    }
}
