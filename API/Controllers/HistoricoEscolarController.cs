using API.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoEscolarController : Controller
    {
        private readonly IHistoricoEscolarService _historicoEscolarService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public HistoricoEscolarController(IHistoricoEscolarService service, IMapper mapper, IWebHostEnvironment environment)
        {
            _historicoEscolarService = service;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("get-all")]
        public async Task<List<HistoricoEscolarViewModel>> GetAll()
        {
            return _mapper.Map<List<HistoricoEscolarViewModel>>(await _historicoEscolarService.GetAll());
        }

        [HttpGet("download")]

        public async Task<ActionResult> Download(int id)
        {
            var historico = await _historicoEscolarService.GetById(id);

            if(historico == null)
            {
                return NotFound("Arquivo não encontrado");
            }

            var filePath = Path.Combine(_environment.ContentRootPath, "Resources\\Historicos", historico.Nome);

            if (!System.IO.File.Exists(filePath))
                return NotFound();
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            //return File(memory, GetContentType(filePath), filePath);            
            return File(memory, "application/pdf", filePath);

        }

    }
}
