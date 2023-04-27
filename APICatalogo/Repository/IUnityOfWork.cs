namespace APICatalogo.Repository
{
    public interface IUnityOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        Task Commit();
    }
}
