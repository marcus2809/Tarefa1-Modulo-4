using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TarefaAula3.Application.Inputs;
using TarefaAula3.Application.Interfaces;
using TarefaAula3.Application.Outputs;
using TarefaAula3.Core;
using TarefaAula3.Repository.Interfaces;

namespace TarefaAula3.Application.UseCases
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private readonly IRepository<Pessoa> _pessoaRepository;
        public AtualizarPessoaUseCase(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public UseCaseOutput Execute(Guid id, AtualizarPessoaInput input)
        {
            var pessoa = _pessoaRepository.GetById(id);
            if (pessoa == null)
                return new UseCaseOutput(HttpStatusCode.NotFound, "Pessoa não encontrada");

            var pessoaAtualizada = new Pessoa()
            {
                Id = id,
                Nome = string.IsNullOrWhiteSpace(input.Nome) ? pessoa.Nome : input.Nome,
                Cidade = string.IsNullOrWhiteSpace(input.Cidade) ? pessoa.Cidade : input.Cidade,
            };

            if (!_pessoaRepository.Update(pessoaAtualizada))
            {
                return new UseCaseOutput(HttpStatusCode.BadRequest, pessoaAtualizada.Validations);
            }

            var pessoaPresenter = new PessoaPresenter(pessoaAtualizada);
            return new UseCaseOutput(HttpStatusCode.Created, pessoaPresenter);
        }
    }
}
