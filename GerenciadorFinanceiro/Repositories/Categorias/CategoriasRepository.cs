using GerenciadorFinanceiro.Data;
using GerenciadorFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinanceiro.Repositories.Categorias
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly AppDbContext _context;

        public CategoriasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EncontrarCategoria(string nome)
        {
            try
            {
                return await _context.Categorias.Where(o => o.Nome == nome).FirstOrDefaultAsync() != null ? true : false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ExcluirCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(o => o.Id == id);

                if (categoria == null) return false;

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> RegistrarCategoria(string nome)
        {
            try
            {
                var categorias = _context.Categorias;

                var novaCategoria = new Categoria()
                {
                    Nome = nome
                };

                categorias.Add(novaCategoria);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
