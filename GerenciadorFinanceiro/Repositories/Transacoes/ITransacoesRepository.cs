using GerenciadorFinanceiro.Models;

namespace GerenciadorFinanceiro.Repositories.Transacoes
{
    public interface ITransacoesRepository
    {
        public Task<bool> RegistrarTransacao(Transacao obj);
        public Task<bool> AtualizarTransacao(Transacao obj, int Id);
        public Task<bool> ExcluirTransacao(int Id);
        public Task<List<Transacao>> GetTransacoes();
        public Task<Transacao> GetTransacao(int id);
    }
}
