using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefaAula3.Application.Inputs;
using TarefaAula3.Application.Interfaces;

namespace TarefaAula3.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ICadastrarPessoaUseCase _cadastrarPessoaUseCase;
        private readonly IListarPessoasUseCase _listarPessoasUseCase;
        private readonly IBuscarPessoaUseCase _buscarPessoaUseCase;
        private readonly IExcluirPessoaUseCase _excluirPessoaUseCase;
        private readonly IAtualizarPessoaUseCase _atualizarPessoaUseCase;
        public PessoaController
        (
            ICadastrarPessoaUseCase cadastrarPessoaUseCase, 
            IListarPessoasUseCase listarPessoasUseCase, 
            IBuscarPessoaUseCase buscarPessoaUseCase,
            IExcluirPessoaUseCase excluirPessoaUseCase,
            IAtualizarPessoaUseCase atualizarPessoaUseCase

        )
        {
            _cadastrarPessoaUseCase = cadastrarPessoaUseCase;
            _listarPessoasUseCase = listarPessoasUseCase;
            _buscarPessoaUseCase = buscarPessoaUseCase;
            _excluirPessoaUseCase = excluirPessoaUseCase;
            _atualizarPessoaUseCase = atualizarPessoaUseCase;
        }

        [HttpPost]
        public IActionResult CadastrarPessoa([FromBody] CadastrarPessoaInput input)
        {
            var response = _cadastrarPessoaUseCase.Execute(input);

            if (response.HasErros)
                return StatusCode((int)response.StatusCode, response.Erros);
                
            return StatusCode((int)response.StatusCode, response.Data);
        }

        [HttpGet]
        public IActionResult ListarPessoas()
        {
            var response = _listarPessoasUseCase.Execute();

            if (response.HasErros)
                return StatusCode((int)response.StatusCode, response.Erros);
            
            return StatusCode((int)response.StatusCode, response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPessoa([FromRoute]Guid id)
        {
            var response = _buscarPessoaUseCase.Execute(id);

            if(response.HasErros)
                return StatusCode((int)response.StatusCode, response.Erros);
            
            return StatusCode((int)response.StatusCode, response.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirPessoa([FromRoute]Guid id)
        {
            var response = _excluirPessoaUseCase.Execute(id);

            if (response.HasErros)
                return StatusCode((int)response.StatusCode, response.Erros);
            
            return StatusCode((int)response.StatusCode, response.Data);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa([FromRoute]Guid id, [FromBody] AtualizarPessoaInput input)
        {
            var response = _atualizarPessoaUseCase.Execute(id, input);

            if (response.HasErros)
                return StatusCode((int)response.StatusCode, response.Erros);
            
            return StatusCode((int)response.StatusCode, response.Data);
        }
    }
}
