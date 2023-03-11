using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TarefaAula3.Application
{
    public class UseCaseOutput
    {
        public List<string> Erros { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool HasErros;

        public UseCaseOutput(HttpStatusCode statusCode, List<string> erros)
        {
            Erros = erros;
            StatusCode = statusCode;
            HasErros = Erros.Any();
        }

        public UseCaseOutput(HttpStatusCode statusCode, string[] erros)
        {
            Erros = erros.ToList();
            StatusCode = statusCode;
            HasErros = Erros.Any();
        }

        public UseCaseOutput(HttpStatusCode statusCode, object data) 
        {
            Data = data;
            StatusCode = statusCode;
        }
    }
}
