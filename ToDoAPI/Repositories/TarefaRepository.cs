using Dapper;
using System.Data;
using ToDoAPI.Context;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class TarefaRepository
    {
        private readonly DapperContext _context;

        public TarefaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefas>> ListarAsync()
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Tarefas>(
                "gabrieltodo.sp_ListarTarefas",
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public async Task AdicionarAsync(Tarefas tarefa)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(
                "gabrieltodo.sp_AdicionarTarefa",
                new
                {
                    tarefa.Titulo,
                    tarefa.Descricao,
                    tarefa.Concluida,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(
                "gabrieltodo.sp_ExcluirTarefa",
                new { p_id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Tarefas tarefa)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(
                "gabrieltodo.sp_AtualizarTarefa",
                new
                {
                    tarefa.Id,
                    tarefa.Titulo,
                    tarefa.Descricao,
                    tarefa.Concluida,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
