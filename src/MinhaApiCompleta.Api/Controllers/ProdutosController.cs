using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhaApiCompleta.Api.ViewModels;
using MinhaApiCompleta.Business.Intefaces;
using MinhaApiCompleta.Business.Intefaces.Repositories;
using MinhaApiCompleta.Business.Intefaces.Services;
using MinhaApiCompleta.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        #region Propriedades

        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public ProdutosController(INotificador notificador,
                                  IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var produtos = await _produtoRepository.ObterProdutosFornecedores();

            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel is null) NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;

            if (!UploadArquivo(produtoViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(produtoViewModel);
            }

            produtoViewModel.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto is null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (arquivo is null || arquivo.Length <= 0)
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = await _produtoRepository.ObterProdutoFornecedor(id);

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        #endregion
    }
}
