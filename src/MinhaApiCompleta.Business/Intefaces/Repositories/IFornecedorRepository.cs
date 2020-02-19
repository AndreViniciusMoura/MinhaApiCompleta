using MinhaApiCompleta.Business.Models;
using System;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Business.Intefaces.Repositories
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
