using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.DTO;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository.IRepository;

namespace MiPrimeraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepo;
        private readonly IMapper _Mapper;

        public UsuarioController(IUsuarioRepository UsuarioRepo, IMapper Mapper)
        {
            _Mapper = Mapper;
            _UsuarioRepo = UsuarioRepo;
        }

        [HttpGet]
        public ActionResult GetUsuario(string Correo)
        {
            var ItemUsuario = _UsuarioRepo.GetUsuario(Correo);
            if (ItemUsuario == null)
            {
                return NotFound();
            }
            var UsuarioDTO = _Mapper.Map<UsuarioDTO>(ItemUsuario);
            return Ok(UsuarioDTO);
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody]UsuarioDTO UsuarioDTO)
        {
            if(UsuarioDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_UsuarioRepo.ExisteUsuario(UsuarioDTO.Correo))
            {
                ModelState.AddModelError("","El correo  " + UsuarioDTO.Correo + " ,ya existe");
                return StatusCode(404, ModelState);
            }
            var Usuario = _Mapper.Map<Usuario>(UsuarioDTO);
            int IdUsuario = _UsuarioRepo.CreateUsuario(Usuario);
            if(IdUsuario == 0)
            {
                ModelState.AddModelError("", "El Usuario con correo " + UsuarioDTO.Correo + ", no se pudo crear.");
                return StatusCode(500, ModelState);
            }

            return Ok(IdUsuario);

        }


        [HttpGet("{Correo},{Contrasena}",Name ="Login")]
        public IActionResult Login(string Correo,string Contrasena)
        {
            if (!_UsuarioRepo.ExisteUsuario(Correo))
            {
                ModelState.AddModelError("", "El correo  " + Correo + " ,no existe.");
                return StatusCode(404, ModelState);
            }else if (!_UsuarioRepo.Login(Correo,Contrasena))
            {
                ModelState.AddModelError("", "La contraseña es incorrecta.");
                return StatusCode(401, ModelState);
            }

            return Ok();


        }




    }
}