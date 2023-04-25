using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;

        public CategoriasController(IUnityOfWork context, IMapper mapper)
        {
            _uow = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> Get()
        {
            try
            {
                var categoriaDTO = _mapper.Map<List<CategoriaDTO>>(_uow.CategoriaRepository.Get().ToList());

                return categoriaDTO;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }


        [HttpGet("Produtos")]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {

            var categoriaDTO = _mapper.Map<List<CategoriaDTO>>(_uow.CategoriaRepository.GetCategoriasProdutos().ToList());

            return categoriaDTO;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            var categoriaDTO = _mapper.Map<CategoriaDTO>(_uow.CategoriaRepository.GetById(c => c.Id == id));

            if (categoriaDTO is null) return NotFound();

            return Ok(categoriaDTO);
        }

        [HttpPost]
        public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
        {
            if (categoriaDto is null) return BadRequest();

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _uow.CategoriaRepository.Add(categoria);
            _uow.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoriaDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO.Id != id)
            {
                return BadRequest();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            _uow.CategoriaRepository.Update(categoria);
            _uow.Commit();

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDto);
        }



        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaDTO> Delete(int id)
        {
            var categoria = _uow.CategoriaRepository.GetById(c => c.Id == id);

            if (categoria is null)
            {
                return NotFound("categoria não localizado");
            }

            _uow.CategoriaRepository.Delete(categoria);
            _uow.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDTO);
        }
    }
}
