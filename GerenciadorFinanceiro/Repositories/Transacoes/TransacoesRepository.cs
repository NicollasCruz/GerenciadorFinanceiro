using GerenciadorFinanceiro.Data;
using GerenciadorFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinanceiro.Repositories.Transacoes
{
    public class TransacoesRepository : ITransacoesRepository
    {
        private readonly AppDbContext _context;
        public TransacoesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AtualizarTransacao(Transacao obj, int Id)
        {
            try
            {
                var Transacao = await _context.Transacoes.Where(o => o.Id == Id).FirstOrDefaultAsync();

                if (Transacao == null) return false;

                Transacao.DataRegistro = obj.DataRegistro;
                Transacao.TipoTransacao = obj.TipoTransacao;
                Transacao.Categoria = obj.Categoria;
                Transacao.Valor = obj.Valor;
                Transacao.Recorrencia = obj.Recorrencia;
                Transacao.Parcelado = obj.Parcelado;
                Transacao.NumParcelas = obj.NumParcelas;
                Transacao.ParcelasPagas = obj.ParcelasPagas;

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExcluirTransacao(int Id)
        {
            try
            {
                var Transacao = _context.Transacoes.Where(o => o.Id == Id);

                _context.Remove(Transacao);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Transacao> GetTransacao(int id)
        {
            try
            {
                return await _context.Transacoes.Where(o => o.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Transacao>> GetTransacoes()
        {
            try
            {
                return await _context.Transacoes.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> RegistrarTransacao(Transacao obj)
        {
            try
            {
                obj.DataRegistro = DateTime.Now; 
                var Transacoes =  _context.Transacoes;

                Transacoes.Add(obj);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
