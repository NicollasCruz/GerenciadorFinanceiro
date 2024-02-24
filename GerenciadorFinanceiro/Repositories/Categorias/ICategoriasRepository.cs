using GerenciadorFinanceiro.Models;

namespace GerenciadorFinanceiro.Repositories.Categorias
{
    public interface ICategoriasRepository
    {
        public Task<List<Categoria>> GetCategorias();
        public Task<bool> EncontrarCategoria(string nome);
        public Task<bool> RegistrarCategoria(string nome);
        public Task<bool> ExcluirCategoria(int id);
    }
}
