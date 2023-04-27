using APICatalogo.Models;
using APICatalogo.Pagination;
using System.Collections.Generic;

namespace APICatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategorias(CategoriaParameters categoriaParameters);
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    }
}
