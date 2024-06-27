using Fiap.Web.Alunos.Data;

using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly DatabaseContext _context;

        public AgendamentoController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Carrega todos os agendamentos com os dados necessários
            var agendamentos = _context.Agendamentos.ToList();
            return View(agendamentos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var agendamentoModel = new AgendamentoModel();
            return View(agendamentoModel);
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(AgendamentoModel agendamentoModel)
        {
          /*  _context.Agendamentos.Add(agendamentoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"O agendamento no endereço {agendamentoModel.Endereco} foi cadastrado com sucesso";
            return RedirectToAction(nameof(Index));*/
            if (ModelState.IsValid)
            {
                _context.Agendamentos.Add(agendamentoModel);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O agendamento no endereço {agendamentoModel.Endereco} foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(agendamentoModel);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Detail(long id)
        {
            var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == id); // Encontra o agendamento pelo id

            if (agendamento == null)
            {
                return NotFound(); // Retorna um erro 404 se o agendamento não for encontrado
            }
            else
            {
                return View(agendamento); // Retorna a view com os dados do agendamento
            }
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Edit(long id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            else
            {
                return View(agendamento);
            }
        }

        [HttpPost]
        public IActionResult Edit(AgendamentoModel agendamentoModel)
        {
            _context.Update(agendamentoModel);
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados do agendamento no endereço {agendamentoModel.Endereco} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do agendamento no endereço {agendamento.Endereco} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemErro"] = "OPS !!! Agendamento inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
