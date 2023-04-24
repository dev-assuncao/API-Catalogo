using APICatalogo.Context;

namespace APICatalogo.Repository
{
    public class UnityOfWork : IUnityOfWork
    {

        private IProdutoRepository _produtoRepository;
        private ICategoriaRepository  _categoriaRepositoy;
        public APIContext _context;

        public UnityOfWork(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepositoy, APIContext context)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepositoy = categoriaRepositoy;
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get 
            {
                return _categoriaRepositoy = _categoriaRepositoy ?? new CategoriaRepositoy(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
