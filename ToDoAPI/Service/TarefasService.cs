using ToDoAPI.Entities;
using ToDoAPI.Repositories;

namespace ToDoAPI.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly TarefaRepository _repository;

        public TarefaService(TarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Tarefas>> ListarAsync() => await _repository.ListarAsync();

        public async Task AdicionarAsync(Tarefas tarefa)
        {
            if (string.IsNullOrWhiteSpace(tarefa.Titulo))
                throw new ArgumentException("Título é obrigatório");

            tarefa.DataCriacao = DateTime.Now;

            await _repository.AdicionarAsync(tarefa);
        }

        public async Task AtualizarAsync(Tarefas tarefa)
        {
            await _repository.AtualizarAsync(tarefa);
        }

        public async Task ExcluirAsync(int id)
        {
            await _repository.ExcluirAsync(id);
        }
    }
}
