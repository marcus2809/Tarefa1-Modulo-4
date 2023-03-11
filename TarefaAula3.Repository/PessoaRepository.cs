using TarefaAula3.Core;
using TarefaAula3.Repository.Interfaces;

namespace TarefaAula3.Repository
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        private readonly List<Pessoa> _pessoas = new List<Pessoa>();

        public bool Delete(Pessoa entity)
        {
            return _pessoas.Remove(entity);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoas;
        }

        public Pessoa? GetById(Guid id)
        {
            return _pessoas.FirstOrDefault(p => p.Id == id);
        }

        public bool Save(Pessoa entity)
        {
            if (!entity.IsValid)
                return false;
            _pessoas.Add(entity);
            return true;
        }

        public bool Update(Pessoa entity)
        {
            if (!entity.IsValid)
                return false;
            var pessoaAtualizada = GetById(entity.Id);
            _pessoas.Remove(pessoaAtualizada);
            _pessoas.Add(entity);
            return true;
        }
    }
}