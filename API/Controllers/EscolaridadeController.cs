using API.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeService _escolaridadeService;
        private readonly IMapper _mapper;

        public EscolaridadeController(IEscolaridadeService service, IMapper mapper)
        {
            _escolaridadeService = service;
            _mapper = mapper;   
        }

        [HttpGet("get-all")]
        public async Task<List<EscolaridadeViewModel>> GetAll()
        {
            return  _mapper.Map<List<EscolaridadeViewModel>>(await _escolaridadeService.GetAll());
        }
    }
}
