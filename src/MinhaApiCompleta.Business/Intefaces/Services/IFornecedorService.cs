using MinhaApiCompleta.Business.Models;
using System;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Business.Intefaces.Services
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);

        Task<bool> Atualizar(Fornecedor fornecedor);

        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
