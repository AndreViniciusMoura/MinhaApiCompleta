using Microsoft.EntityFrameworkCore;
using MinhaApiCompleta.Business.Intefaces.Repositories;
using MinhaApiCompleta.Business.Models;
using MinhaApiCompleta.Data.Context;
using System;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
