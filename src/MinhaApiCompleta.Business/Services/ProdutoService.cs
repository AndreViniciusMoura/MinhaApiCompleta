using MinhaApiCompleta.Business.Intefaces;
using MinhaApiCompleta.Business.Intefaces.Repositories;
using MinhaApiCompleta.Business.Intefaces.Services;
using MinhaApiCompleta.Business.Models;
using MinhaApiCompleta.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        #region Propriedades

        private readonly IProdutoRepository _produtoRepository;
        //private readonly IUser _user;

        #endregion

        #region Construtor

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador
                              //IUser user
                              ) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            //_user = user;
        }

        #endregion

        #region Metodos

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            //var user = _user.GetUserId();

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        #endregion
    }
}
