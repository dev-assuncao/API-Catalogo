using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository
{
    public class CategoriaRepositoy : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepositoy(APIContext context) : base(context)
        {
        }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }

        PagedList<Categoria> ICategoriaRepository.GetCategorias(CategoriaParameters categoriaParameters)
        {
            return PagedList<Categoria>.ToPagedList(Get().OrderBy(cat => cat.Id), categoriaParameters.PageNumber, categoriaParameters.PageSize);
        }
    }
}
