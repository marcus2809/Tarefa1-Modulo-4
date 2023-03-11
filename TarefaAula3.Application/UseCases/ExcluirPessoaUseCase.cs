using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Application.Interfaces;
using TarefaAula3.Application.Outputs;
using TarefaAula3.Core;
using TarefaAula3.Repository.Interfaces;

namespace TarefaAula3.Application.UseCases
{
    public class ExcluirPessoaUseCase : IExcluirPessoaUseCase
    {
        private readonly IRepository<Pessoa> _pessoaRepository;
        public ExcluirPessoaUseCase(IRepository<Pessoa> pessoaRepository, IBuscarPessoaUseCase buscarPessoaUseCase)
        {
            _pessoaRepository = pessoaRepository;
        }
        public UseCaseOutput Execute(Guid id)
        {
            var pessoa = _pessoaRepository.GetById(id);
            if (pessoa == null)
                return new UseCaseOutput(HttpStatusCode.NotFound, "Pessoa não encontrada");

            if (!_pessoaRepository.Delete(pessoa))
                return new UseCaseOutput(HttpStatusCode.InternalServerError, "Erro ao deletar pessoa");

            var pessoaPresenter = new PessoaPresenter(pessoa);
            return new UseCaseOutput(HttpStatusCode.OK, pessoaPresenter);
        }
    }
}
