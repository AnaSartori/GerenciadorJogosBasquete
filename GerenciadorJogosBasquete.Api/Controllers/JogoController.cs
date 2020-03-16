using System;
using AutoMapper;
using GerenciadorJogosBasquete.Api.Dto;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorJogosBasquete.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService, IMapper mapper)
        {
            _jogoService = jogoService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] JogoBasqueteDto jogoBasqueteDto)
        {
            if (jogoBasqueteDto.QtdPontos < 0)
            {
                return BadRequest("A quantidade de pontos é inválida.");
            }

            if (jogoBasqueteDto.DataJogo == DateTime.MinValue)
            {
                return BadRequest("A data do jogo é inválida.");
            }

            var jogo = _mapper.Map<JogoBasquete>(jogoBasqueteDto);

            return Ok (_jogoService.AddJogo(jogo));
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetJogos()
        {
            return Ok(_jogoService.GetJogos());
        }

        [HttpGet]
        [Route("resultados")]
        public IActionResult GetResultadoJogos()
        {
            return Ok(_jogoService.GetResultadoJogos());
        }
    }
}