using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly EnderecoService _service;

        public EnderecosController(EnderecoService service)
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

        // GET: /Perfil/Create
        // Formulário para o cliente adicionar um novo endereço
        [HttpGet("CriarMorada")]
        public IActionResult CriarMorada()
        {
            return View();
        }

        // POST: /Perfil/Create
        // Cria um novo endereço
        [HttpPost("CriarMorada")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarMorada(Enderecos endereco)
        {
            if (!ValidarNIF(endereco.NIF))
                ModelState.AddModelError("NIF", "O NIF fornecido não é válido.");

            if (!ValidarCodigoPostal(endereco.CodigoPostal))
                ModelState.AddModelError("CodigoPostal", "O código postal fornecido não é válido.");

            if (!ModelState.IsValid)
                return View(endereco);

            try
            {
                await _service.AddEnderecoAsync(endereco);
                TempData["SuccessMessage"] = "Endereço adicionado com sucesso!";
                return RedirectToAction("Perfil", "Clientes"); // Redireciona para a página do perfil do cliente
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocorreu um erro ao guardar o endereço.";
                return View(endereco);
            }
        }

        // GET: /Perfil/Edit/{id}
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

        // POST: /Perfil/Edit/{id}
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

        // GET: /Perfil/Delete/{id}
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

        // POST: /Perfil/Delete/{id}
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

        // Validação do NIF (simplificada)
        private bool ValidarNIF(string nif)
        {
            return string.IsNullOrEmpty(nif) || (nif.Length == 9 && int.TryParse(nif, out _));
        }

        // Validação do Código Postal (formato 0000-000)
        private bool ValidarCodigoPostal(string codigoPostal)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(codigoPostal, @"^\d{4}-\d{3}$");
        }
    }
}
