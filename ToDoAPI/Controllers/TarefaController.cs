using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entities;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaRepository _repo;

        public TarefasController(TarefaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _repo.ListarAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarefas tarefa)
        {
            await _repo.AdicionarAsync(tarefa);
            return Created("", tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarefas tarefa)
        {
            tarefa.Id = id;
            await _repo.AtualizarAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.ExcluirAsync(id);
            return NoContent();
        }
    }
}
