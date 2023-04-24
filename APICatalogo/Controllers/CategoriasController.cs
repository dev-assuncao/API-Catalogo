using APICatalogo.Models;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnityOfWork _uow;

        public CategoriasController(IUnityOfWork context)
        {
            _uow = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _uow.CategoriaRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }


        [HttpGet("Produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _uow.CategoriaRepository.GetCategoriasProdutos().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _uow.CategoriaRepository.GetById(c => c.Id == id);

            if (categoria is null) return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null) return BadRequest();

            _uow.CategoriaRepository.Add(categoria);
            _uow.Commit();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (categoria.Id != id)
            {
                return BadRequest();
            }

            _uow.CategoriaRepository.Update(categoria);
            _uow.Commit();

            return Ok(categoria);
        }



        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _uow.CategoriaRepository.GetById(c => c.Id == id);

            if (categoria is null)
            {
                return NotFound("categoria não localizado");
            }

            _uow.CategoriaRepository.Delete(categoria);
            _uow.Commit();

            return Ok(categoria);
        }
    }
}
