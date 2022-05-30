using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaTecnica3.Data;
using ProvaTecnica3.Models;

namespace ProvaTecnica3.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly ProvaTecnica3Context _context;

        public PagamentosController(ProvaTecnica3Context context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            var provaTecnica3Context = _context.Pagamento.Include(p => p.Clientes).Include(p => p.Emprestimos);
            return View(await provaTecnica3Context.ToListAsync());
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Clientes)
                .Include(p => p.Emprestimos)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "CPF");
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoId,EmprestimoId,ClienteId,DtPagamento,ValorParcela,IsPago")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "CPF", pagamento.ClienteId);
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", pagamento.EmprestimoId);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "CPF", pagamento.ClienteId);
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", pagamento.EmprestimoId);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoId,EmprestimoId,ClienteId,DtPagamento,ValorParcela,IsPago")] Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PagamentoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "CPF", pagamento.ClienteId);
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", pagamento.EmprestimoId);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamento == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Clientes)
                .Include(p => p.Emprestimos)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamento == null)
            {
                return Problem("Entity set 'ProvaTecnica3Context.Pagamento'  is null.");
            }
            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamento.Remove(pagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
          return (_context.Pagamento?.Any(e => e.PagamentoId == id)).GetValueOrDefault();
        }
    }
}
