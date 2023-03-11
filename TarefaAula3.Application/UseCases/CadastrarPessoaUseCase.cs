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
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private readonly IRepository<Pessoa> _pessoaRepository;
        public CadastrarPessoaUseCase(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public UseCaseOutput Execute(CadastrarPessoaInput input)
        {
            var pessoa = new Pessoa
            (
                input.Nome, 
                input.Cidade
            );

            if(!_pessoaRepository.Save( pessoa))
            {
                return new UseCaseOutput(HttpStatusCode.BadRequest, pessoa.Validations);
            }


            var pessoaPresenter = new PessoaPresenter(pessoa);
            return new UseCaseOutput(HttpStatusCode.Created, pessoaPresenter);
        }
    }
}
