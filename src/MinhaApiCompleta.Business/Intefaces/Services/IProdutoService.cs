using MinhaApiCompleta.Business.Models;
using System;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Business.Intefaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Remover(Guid id);
    }
}
