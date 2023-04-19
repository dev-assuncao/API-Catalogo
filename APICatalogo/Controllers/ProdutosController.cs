using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APIContext _context;

        public ProdutosController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();

            if (produtos is null) return NotFound();

            return produtos;
        }

        [HttpGet("{id:int:min(1)}", Name= "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null) return NotFound();

            return produto;
        }


        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await  _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
        }


        [HttpPut("{id:int}")]
        public async  Task<ActionResult> Put(int id, Produto produto)
        {
            if (produto.Id != id)
            {
                return BadRequest();
            }

             _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }

             _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
