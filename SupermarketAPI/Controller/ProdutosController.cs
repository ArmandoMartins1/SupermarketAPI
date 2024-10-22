using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Models;
using SupermarketAPI.Services;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _produtoService.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoService.GetById(id);
            if (produto == null)
                return NotFound(new { message = "Produto não encontrado" });

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoService.Create(produtoDTO);
            return CreatedAtAction(nameof(GetById), new { id = produtoDTO.Nome }, produtoDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produtoExistente = _produtoService.GetById(id);
            if (produtoExistente == null)
                return NotFound(new { message = "Produto não encontrado" });

            _produtoService.Update(id, produtoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produtoExistente = _produtoService.GetById(id);
            if (produtoExistente == null)
                return NotFound(new { message = "Produto não encontrado" });

            _produtoService.Delete(id);
            return NoContent();
        }
    }
}
