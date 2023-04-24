using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Repository;

namespace APICatalogo.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnityOfWork _uof;

        public ProdutosController(IUnityOfWork context)
        {
            _uof = context;
        }


        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPreco()
        {
            return _uof.ProdutoRepository.GetProdutosPorPreco().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _uof.ProdutoRepository.Get().ToList();

            if (produtos is null) return NotFound();

            return produtos;
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _uof.ProdutoRepository.GetById(p => p.Id == id);

            if (produto == null) return NotFound();

            return produto;
        }


        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (produto.Id != id)
            {
                return BadRequest();
            }

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _uof.ProdutoRepository.GetById(x => x.Id == id);

            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }

            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();

            return Ok(produto);
        }
    }
}
