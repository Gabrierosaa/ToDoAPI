using ToDoAPI.Entities;

namespace ToDoAPI.Services
{
    public interface ITarefaService
    {
        Task<List<Tarefas>> ListarAsync();
        Task AdicionarAsync(Tarefas tarefa);
        Task AtualizarAsync(Tarefas tarefa);
        Task ExcluirAsync(int id);
    }
}
