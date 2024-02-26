using GerenciadorFinanceiro.Models;
using GerenciadorFinanceiro.Repositories.Categorias;
using GerenciadorFinanceiro.Repositories.Transacoes;
using Neat.Procedure;

namespace GerenciadorFinanceiro.Services.Transacoes
{
    public class TransacoesService : ITransacoesService
    {
        private ITransacoesRepository _repository;
        private ICategoriasRepository _categoriasRepository;

        public TransacoesService(ITransacoesRepository repository, ICategoriasRepository categoriasRepository)
        {
            _repository = repository;
            _categoriasRepository = categoriasRepository;
        }

        public async Task<bool> AtualizarTransacao(Transacao obj, int Id)
        {
            return await _repository.AtualizarTransacao(obj, Id);
        }

        public async Task<bool> ExcluirTransacao(int Id)
        {
            return await _repository.ExcluirTransacao(Id);
        }

        public async Task<Transacao> GetTransacao(int id)
        {
            return await _repository.GetTransacao(id);
        }

        public async Task<List<Transacao>> GetTransacoes()
        {
            return await _repository.GetTransacoes();
        }

        public async Task<bool> RegistrarTransacao(Transacao obj)
        {
            bool categoriaExistente = await _categoriasRepository.EncontrarCategoria(obj.Categoria);

            if (categoriaExistente == false)
            {
                var IdCategoria = await _categoriasRepository.RegistrarCategoria(obj.Categoria);
                obj.IdCategoria = IdCategoria;
            }
            return await _repository.RegistrarTransacao(obj);
        }

        public async Task<BalançoGeralSemestre> GerarBalancoSemestre(int qtdMeses)
        {
            try
            {
                throw new Exception("Teste");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
