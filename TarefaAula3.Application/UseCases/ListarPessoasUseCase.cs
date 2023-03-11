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
    public class ListarPessoasUseCase : IListarPessoasUseCase
    {
        private readonly IRepository<Pessoa> _pessoaRepository;
        public ListarPessoasUseCase(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public UseCaseOutput Execute()
        {
            var data = _pessoaRepository.GetAll();
            var pessoasPresenter = new PessoasPresenter(data);
            var listaPessoasPresenter = pessoasPresenter.pessoasPresenter;
            return new UseCaseOutput(HttpStatusCode.OK, listaPessoasPresenter);
        }
    }
}
