using BancoApp.Application.DTOs;
using BancoApp.Application.Interface;
using BancoApp.Application.Services;
using BancoApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace BancoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        // GET: api/Boleto/5
        /// <summary>
        /// Busca boleto por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoletoById(long id)
        {
            var boleto = await _boletoService.GetBoletoByIdAsync(id);

            if (boleto == null)
            {
                return NotFound();
            }

            return boleto;
        }
        // GET: api/Boleto
        /// <summary>
        /// Lista todos os boletos cadastrados no sistema.
        /// </summary>
        /// <param name="isAcesdent">Crescente ou decrescente</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetAllBoletos(bool isAcesdent = true, int page = 1, int pageSize = 10)
        {
            return await _boletoService.GetAllBoletosAsync(nomeCampo: "Id", isAcesdent, page, pageSize);
        }
        // GET: api/Boleto
        /// <summary>
        /// Lista todos os boletos cadastrados no sistema com campos para Ordenação.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo para ordenação</param>
        /// <param name="isAscendente">Ordenação ascendente ou descendente</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        [HttpGet("BoletosOrdenado")]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletoOrdenado(string nomeCampo, bool isAscendente, int pageNumber = 1, int pageSize = 10)
        {
            var boletos = await _boletoService.GetAllBoletosAsync(nomeCampo, isAscendente, pageNumber, pageSize);
            return Ok(boletos);
        }
        // POST: api/Boleto
        /// <summary>
        /// Cria um novo boleto
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Boleto>> CreateBoleto(BoletoDTO boletoDTO)
        {
            var boleto = await _boletoService.CriaBoletoAsync(boletoDTO);
            return CreatedAtAction(nameof(GetBoletoById), new { id = boleto.Id }, boleto);
        }

        // PUT: api/Boleto/5
        /// <summary>
        /// Cria um novo banco
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoleto(long id, BoletoDTO boletoDTO)
        {
            if (id != boletoDTO.Id)
            {
                return BadRequest();
            }

            await _boletoService.AtualizaBoletoAsync(boletoDTO);
            return NoContent();
        }

    }
}
