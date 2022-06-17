using API.ViewModels;
using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public UsuarioController(IUsuarioService service, IMapper mapper, IWebHostEnvironment environment)
        {
            _usuarioService = service;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("get-all")]
        public async Task<List<UsuarioViewModel>> GetAll()
        {
            return _mapper.Map<List<UsuarioViewModel>>(await _usuarioService.GetAll());
        }

        [HttpGet("get")]
        public async Task<UsuarioViewModel> GetById(int id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioService.GetById(id));
        }

        [HttpPost("create"),DisableRequestSizeLimit]
        public async Task<IActionResult> Create([FromForm] UsuarioCreateViewModel usuario)
        {
            try
            {
                await SaveFile(usuario.HistoricoEscolar);

                var user = _mapper.Map<Usuario>(usuario);

                await _usuarioService.Create(user);

                return Ok(new
                {
                    success = true,
                    data = usuario
                });

            }
            catch(DuplicateWaitObjectException ed)
            {
                return BadRequest(ed.Message);
            }
            catch (FormatException f)
            {
                return BadRequest(f.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro inesperado");
            }            
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UsuarioCreateViewModel usuario)
        {
            try
            {
                await SaveFile(usuario.HistoricoEscolar);

                var user = _mapper.Map<Usuario>(usuario);

                await _usuarioService.Update(user);

                return Ok(new
                {
                    success = true,
                    data = usuario,
                    message = "ok"
                });
            }
            catch (DuplicateWaitObjectException ed)
            {
                return BadRequest(ed.Message);
            }
            catch(FormatException f)
            {
                return BadRequest(f.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro inesperado");
            }           
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.Delete(id);

            return Ok(new
            {
                success = true,
                data = id
            });
        }

        private async Task SaveFile(IFormFile file)
        {
            //adicionar no appsettings
            var fileTypes = new [] { "application/pdf", "application/msword" };

            if (fileTypes.Any(f=> f.Equals(file.ContentType)))
            {
                var filePath = Path.Combine(_environment.ContentRootPath, "Resources\\Historicos", file.FileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);

                return;
            }

            throw new FormatException("Tipo de arquivo inválido.");            
        }

    }
}
