using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.DTO;
using MiPrimeraApi.Repository.IRepository;

namespace MiPrimeraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "CatalogoCategoriaAPI")]

    public class Categoria : ControllerBase
    {
        private readonly ICategoriaRepository _CategoriaRepo;
        private readonly IMapper _Mapper;

        public Categoria(ICategoriaRepository CategoriaRepo, IMapper Mapper)
        {
            _CategoriaRepo = CategoriaRepo;
            _Mapper = Mapper;
        }


        /// <summary>
        /// Aqui va la descripcion para lo que sirve este metodo
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult GetCategoria()
        {
            var LstCategoria = _CategoriaRepo.GetCategoria();
            var LstCategoriaDTO = new List<CategoriaDTO>();
            foreach (var lst in LstCategoria)
            {
                LstCategoriaDTO.Add(_Mapper.Map<CategoriaDTO>(lst));
            }
            return Ok(LstCategoriaDTO);
        }


        [HttpGet("{IdCategoria:int}",Name ="GetCategoria")]
        public ActionResult GetCategoria(int IdCategoria)
        {
            var itemCateogoria = _CategoriaRepo.GetCategoria(IdCategoria);

            if (itemCateogoria == null)
            {
                return NotFound();
            }
            var CategoriaDTO = _Mapper.Map<CategoriaDTO>(itemCateogoria);
            return Ok(CategoriaDTO);
        }

        [HttpPost]
        public IActionResult CreateCategoria([FromBody] CategoriaDTO CategoriaDTO)
        {
            if (CategoriaDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_CategoriaRepo.ExisteCategoria(CategoriaDTO.Nombre))
            {
                ModelState.AddModelError("", "La categoria" + CategoriaDTO.Nombre + ", ya existe");
                return StatusCode(404, ModelState);
            }
            var Categoria = _Mapper.Map<Model.Categoria>(CategoriaDTO);
            int IdCategoria = _CategoriaRepo.CreateCategoria(Categoria);
            if (IdCategoria == 0)
            {
                ModelState.AddModelError("", "La categoria " + CategoriaDTO.Nombre + ", no se pudo crear.");
                return StatusCode(500, ModelState);

            }
            return Ok(IdCategoria);
        }


        [HttpPatch("{IdCategoria:int}", Name = "UpdateCategoria")]
        public IActionResult UpdateCategoria(int IdCategoria, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Categoria = _Mapper.Map<Model.Categoria>(categoriaDTO);

            var item = _CategoriaRepo.UpdateCategoria(Categoria);

            if (item == null)
            {
                ModelState.AddModelError("", "La categoria no se pudo actualizar");
                return StatusCode(500, ModelState);
            }
            return Ok(Categoria);
        }

        [HttpDelete("{IdCategoria:int}",Name = "DeleteCategoria")]
        public IActionResult DeleteCategoria(int IdCategoria)
        {
            if (!_CategoriaRepo.ExisteCategoria(IdCategoria))
            {
                return NotFound();
            }

            if (!_CategoriaRepo.DeleteCategoria(IdCategoria))
            {
                ModelState.AddModelError("", "La categoria no se pudo borrar.");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





    }
}
