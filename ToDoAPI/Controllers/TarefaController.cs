using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entities;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarefas = await _service.ListarAsync();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarefas tarefa)
        {
            await _service.AdicionarAsync(tarefa);
            return Created("", tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarefas tarefa)
        {
            tarefa.Id = id;
            await _service.AtualizarAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.ExcluirAsync(id);
            return NoContent();
        }
    }
}
