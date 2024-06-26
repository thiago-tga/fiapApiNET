using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            var agendamentos = _context.Agendamentos.ToList();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StatusColeta = new SelectList(Enum.GetValues(typeof(StatusColeta)));
            return View();
        }

        [HttpPost]
        public IActionResult Create(AgendamentoModel agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"O agendamento foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusColeta = new SelectList(Enum.GetValues(typeof(StatusColeta)), agendamento.StatusColeta);
            return View(agendamento);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }
            else
            {
                return View(agendamento);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            ViewBag.StatusColeta = new SelectList(Enum.GetValues(typeof(StatusColeta)), agendamento.StatusColeta);
            return View(agendamento);
        }

        [HttpPost]
        public IActionResult Edit(AgendamentoModel agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Update(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do agendamento foram alterados com sucesso";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusColeta = new SelectList(Enum.GetValues(typeof(StatusColeta)), agendamento.StatusColeta);
            return View(agendamento);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do agendamento foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "OPS !!! Agendamento inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
