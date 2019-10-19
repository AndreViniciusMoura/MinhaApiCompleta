using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MinhaApiCompleta.Business.Intefaces;
using MinhaApiCompleta.Business.Notificacoes;
using System.Linq;

namespace MinhaApiCompleta.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        #region Propriedades

        private readonly INotificador _notificador;

        #endregion

        #region Contrutor
        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        #endregion

        #region Metodos

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErrorModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        #endregion
    }
}