using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HATC.Data;
using HATC.Models;

namespace HATC.Controllers
{
    public class SessionsController : Controller
    {
        private readonly HavenDbContext _context;

        public SessionsController(HavenDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessions.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,DM,InGameDate,SessionDate")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionId,DM,InGameDate,SessionDate")] Session session)
        {
            if (id != session.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.SessionId))
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
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.SessionId == id);
        }


        public IActionResult Add()
        {
            Session s = new Session();
            this.Data();
            return View(s);
        }
        [HttpPost]
        public IActionResult Add(Session s)
        {
            s.Date = DateTime.Now;
            _context.Sessions.Add(s);
            _context.SaveChanges();

            return View("Index");
        }

        public IActionResult AddAdhoc(Session s)
        {
            s.SessionItems.ToList().Add(new SessionItem());
            this.Data();
            return View("Add", s);
        }

        [Route("DelAdhoc/{index}")]
        public IActionResult DelAdhoc(int index, Session s)
        {

            s.SessionItems.ToList().RemoveAt(index);
            ModelState.Clear();
            this.Data();
            return View("Add", s);
        }
        public IActionResult AddMonster(Session s)
        {
            s.Monsters.ToList().Add(new Monster());
            this.Data();
            return View("Add", s);
        }

        [Route("DelMonster/{index}")]
        public IActionResult DelMonster(int index, Session s)
        {
            s.Monsters.ToList().RemoveAt(index);
            ModelState.Clear();
            this.Data();
            return View("Add", s);
        }
        private void Data()
        {
            ViewData["DMs"] = _context.Users.Where(u => u.Role == Models.User.RoleType.DM).ToList();
            ViewData["Users"] = _context.Users.OrderBy(u => u.UserName).ToList();
            ViewData["Characters"] = _context.Characters.OrderBy(c => c.Name).ToList();
        }

    }
}
