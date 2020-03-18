using GerenciadorJogosBasquete.Api.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using GerenciadorJogosBasquete.Comum;

namespace GerenciadorJogosBasquete.Api.Controllers
{
    /// <summary>
    ///     Controller responsável pelo gerenciamento de Jogos de Basquete.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        /// <summary>
        ///     Adiciona novo jogo de basquete.
        /// </summary>
        /// <param name="jogoBasqueteRequestDto">Dto contendo data do jogo e quantidade de pontos.</param>
        /// <response code="200">O jogo foi adicionado com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao adicionar novo jogo.</response>
        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] JogoBasqueteRequestDto jogoBasqueteRequestDto)
        {
            try
            {
                if (jogoBasqueteRequestDto.QtdPontos < 0)
                    return BadRequest(new ResultBag("A quantidade de pontos é inválida.", false));

                if (jogoBasqueteRequestDto.DataJogo == DateTime.MinValue)
                    return BadRequest(new ResultBag("A data do jogo é inválida.", false));

                var response = _jogoService.AddJogo(jogoBasqueteRequestDto.DataJogo, jogoBasqueteRequestDto.QtdPontos);

                return response.IsSuccess ? (IActionResult)Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultBag(ex.Message, false));
            }
        }

        /// <summary>
        ///     Retornar todos os jogos de basquete cadastrados.
        /// </summary>
        /// <response code="200">Os jogos foram retornados com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao retornos os jogos.</response>
        [HttpGet]
        [Route("")]
        public IActionResult GetJogos()
        {
            try
            {
                var response = _jogoService.GetJogos();

                return response.IsSuccess ? (IActionResult)Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultBag(ex.Message, false));
            }
        }

        /// <summary>
        ///     Retornar cálculos de resultados dos jogos de basquete.
        /// </summary>
        /// <response code="200">Os resultados foram retornados com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao retornar os resultados.</response>
        [HttpGet]
        [Route("resultados")]
        public IActionResult GetResultadoJogos()
        {
            try
            {
                var response = _jogoService.GetResultadoJogos();

                return response.IsSuccess ? (IActionResult)Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultBag(ex.Message, false));
            }
        }
    }
}