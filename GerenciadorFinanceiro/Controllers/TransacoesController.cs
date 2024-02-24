using GerenciadorFinanceiro.Data;
using GerenciadorFinanceiro.Models;
using GerenciadorFinanceiro.Services.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanceiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacoesService _service;

        public TransacoesController(ITransacoesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTransacao([FromBody] Transacao obj)
        {
            try
            {
                bool sucesso = await _service.RegistrarTransacao(obj);

                if (sucesso) return Ok();

                throw new Exception(nameof(RegistrarTransacao));
            }
            catch (Exception ex)
            {
                return BadRequest(nameof(RegistrarTransacao));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes()
        {
            try
            {
                var Transacoes = await _service.GetTransacoes();

                return Ok(Transacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransacoes(int Id)
        {
            try
            {
                var Transacao = await _service.GetTransacao(Id);

                if (Transacao == null) return BadRequest("Não foi encontrada nenhuma transação com esse identificador.");

                return Ok(Transacao);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTransacao([FromBody] Transacao transacao)
        {
            try
            {
                bool sucesso = await _service.AtualizarTransacao(transacao, transacao.Id);

                if (sucesso) return Ok();

                throw new Exception(nameof(AtualizarTransacao));
            }
            catch(Exception ex)
            {
                throw new Exception(nameof(AtualizarTransacao));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirTransacao(int Id)
        {
            try
            {
                bool sucesso = await _service.ExcluirTransacao(Id);

                if (sucesso) return Ok();

                throw new Exception("Erro ao excluir a transação");
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(ExcluirTransacao));
            }
        }


    }
}
