using BancoApp.Application.DTOs;
using BancoApp.Application.Interface;
using BancoApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        // GET: api/Banco
        /// <summary>
        /// Lista todos os Bancos cadastrados no sistema.
        /// </summary>
        /// <param name="isAcesdent">Crescente ou decrescente</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetAllBancos(bool isAcesdent = true, int page = 1, int pageSize = 10)
        {
            return await _bancoService.GetAllBancosAsync(nomeCampo: "Id", isAcesdent, page, pageSize);
        }
        // GET: api/Bancos
        /// <summary>
        /// Lista todos os bancos cadastrados no sistema com campos para Ordenação.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo para ordenação</param>
        /// <param name="isAscendente">Ordenação ascendente ou descendente</param>
        /// <param name="pageNumber">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        [HttpGet("BancosOrdenado")]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancoOrdenado(string nomeCampo, bool isAscendente, int pageNumber = 1, int pageSize = 10)
        {
            var bancos = await _bancoService.GetAllBancosAsync(nomeCampo, isAscendente, pageNumber, pageSize);
            return Ok(bancos);
        }

        // GET: api/Banco/5
        /// <summary>
        /// Busca banco por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Banco>> GetBancoById(long id)
        {
            var banco = await _bancoService.GetBancoByIdAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

        // POST: api/Banco
        /// <summary>
        /// Cria um novo banco
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Banco>> CreateBanco(BancoDTO bancoDTO)
        {
            var banco = await _bancoService.CriaBancoAsync(bancoDTO);
            return CreatedAtAction(nameof(GetBancoById), new { id = banco.Id }, banco);
        }

        // PUT: api/Banco/5
        /// <summary>
        /// Atualiza um banco
        /// </summary>
        /// <param name="id">O ID do banco</param>
        /// <param name="bancoDto">O DTO do banco</param>
        /// <returns>Um objeto IActionResult representando o resultado da operação</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanco(long id, BancoDTO bancoDTO)
        {
            if (id != bancoDTO.Id)
            {
                return BadRequest();
            }

            await _bancoService.AtualizaBancoAsync(bancoDTO);
            return NoContent();
        }
    }
}
