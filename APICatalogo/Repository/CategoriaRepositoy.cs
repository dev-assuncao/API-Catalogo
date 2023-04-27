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

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await Get().Include(x => x.Produtos).ToListAsync();
        }

        public async Task<PagedList<Categoria>> GetCategorias(CategoriaParameters categoriaParameters)
        {
            return await PagedList<Categoria>.ToPagedList(Get().OrderBy(cat => cat.Id), categoriaParameters.PageNumber, categoriaParameters.PageSize);
        }
    }
}
