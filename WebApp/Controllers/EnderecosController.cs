using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        // GET: /Enderecos
        // Lista todos os endereços
        public async Task<IActionResult> Index()
        {
            var enderecos = await _service.GetAllEnderecosAsync();
            return View(enderecos);
        }

        // GET: /Enderecos/Details/{id}
        // Mostra detalhes de um endereço pelo ID
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var endereco = await _service.GetEnderecoByIdAsync(id);

            if (endereco == null)
                return NotFound();

            return View(endereco);
        }

        // GET: /Enderecos/Create
        // Formulário para criar um novo endereço
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Enderecos/Create
        // Cria um novo endereço
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enderecos endereco)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddEnderecoAsync(endereco);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return View(endereco);
        }

        // GET: /Enderecos/Edit/{id}
        // Carrega o formulário para editar um endereço existente
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var endereco = await _service.GetEnderecoByIdAsync(id);
            if (endereco == null)
                return NotFound();

            return View(endereco);
        }

        // POST: /Enderecos/Edit/{id}
        // Salva as alterações de um endereço editado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Enderecos endereco)
        {
            if (id != endereco.EnderecoID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _service.UpdateEnderecoAsync(endereco);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return View(endereco);
        }

        // GET: /Enderecos/Delete/{id}
        // Mostra a página de confirmação para deletar um endereço
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var endereco = await _service.GetEnderecoByIdAsync(id);
            if (endereco == null)
                return NotFound();

            return View(endereco);
        }

        // POST: /Enderecos/Delete/{id}
        // Confirma a exclusão do endereço
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _service.DeleteEnderecoAsync(id);
            if (result)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
