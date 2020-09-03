using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiPrimeraApi.DTO;
using MiPrimeraApi.Model;
using MiPrimeraApi.Repository.IRepository;

namespace MiPrimeraApi.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepo;
        private readonly IMapper _Mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public UsuarioController(IUsuarioRepository UsuarioRepo, IMapper Mapper, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _Mapper = Mapper;
            _UsuarioRepo = UsuarioRepo;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUsuarios()
        {
            var LstUsuario = _UsuarioRepo.GetUsuarios();
            var LstUsuarioDTO = new List<UsuarioDTO>();

            foreach (var list in LstUsuario)
            {
                LstUsuarioDTO.Add(_Mapper.Map<UsuarioDTO>(LstUsuario));
            }
            return Ok(LstUsuarioDTO);
        }



        [Authorize]
        [HttpGet("{IdUsuario:int}", Name = "GetUsuarioI")]
        public ActionResult GetUsuario(int IdUsuario)
        {
            var ItemUsuario = _UsuarioRepo.GetUsuario(IdUsuario);
            if (ItemUsuario == null)
            {
                return NotFound();
            }
            var UsuarioDTO = _Mapper.Map<UsuarioDTO>(ItemUsuario);
            return Ok(UsuarioDTO);
        }

        [Authorize]
        [HttpGet("{Correo}", Name = "GetUsuarioC")]
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

        [HttpPost("Registrar")]
        public ActionResult CreateUsuario([FromBody] UsuarioDTO UsuarioDTO)
        {

            if (_UsuarioRepo.ExisteUsuario(UsuarioDTO.ClientId.ToLower()))
            {
                return BadRequest("El usuario " + UsuarioDTO.ClientId + " no esta disponible");
            }

            var CrearUsuario = new Usuario
            {
                Nombre = UsuarioDTO.Nombre,
                ApMaterno = UsuarioDTO.ApMaterno,
                ApPaterno = UsuarioDTO.ApPaterno,
                Contrasena = UsuarioDTO.Contrasena,
                Correo = UsuarioDTO.Correo,
                ClientId = UsuarioDTO.ClientId
            };

            var result = _UsuarioRepo.CreateUsuario(CrearUsuario, UsuarioDTO.Contrasena);


            return Ok(result);

            //if(UsuarioDTO == null)
            //{
            //    return BadRequest(ModelState);
            //}
            //else if (_UsuarioRepo.ExisteUsuario(UsuarioDTO.Correo))
            //{
            //    ModelState.AddModelError("","El correo  " + UsuarioDTO.Correo + " ,ya existe");
            //    return StatusCode(404, ModelState);
            //}
            //var Usuario = _Mapper.Map<Usuario>(UsuarioDTO);
            //int IdUsuario = _UsuarioRepo.CreateUsuario(Usuario, password);
            //if(IdUsuario == 0)
            //{
            //    ModelState.AddModelError("", "El Usuario con correo " + UsuarioDTO.Correo + ", no se pudo crear.");
            //    return StatusCode(500, ModelState);
            //}

            //return Ok(IdUsuario);

        }


        [HttpGet("Login")]
        public IActionResult Login(UsuarioAuthLoginDTO DatosRegistro)
        {

            var usuarioCredencial = _UsuarioRepo.Login(DatosRegistro.ClientId, DatosRegistro.Password);

            if (usuarioCredencial == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,usuarioCredencial.ClientId.ToString()),
            new Claim(ClaimTypes.Name, usuarioCredencial.ClientId)
            };
            //Secret para token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:TokenKey").Value));

            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var DescriptiorToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credencial

            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(DescriptiorToken);

            return Ok(new
            {
                token = tokenHandle.WriteToken(token)
            });


        }

    }





}





