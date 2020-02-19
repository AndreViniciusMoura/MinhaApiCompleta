using MinhaApiCompleta.Business.Models;
using System;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Business.Intefaces.Repositories
{
    public interface IEnderecoRepository: IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
