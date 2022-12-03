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
    public class CharactersController : Controller
    {
        private readonly HavenDbContext _context;

        public CharactersController(HavenDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Include(c => c.Characters).ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<User> users = _context.Users
                .Include(c => c.Characters)
                .ToList();

            foreach (User u in users)
                foreach (Character c in u.Characters)
                    if (c.CharacterId == id)
                        ViewData["User"] = u;

            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            List<User> users = _context.Users
                .Include(c => c.Characters)
                .ToList();
            ViewData["UserNames"] = users;
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterId,Name")] Character character, int userId)
        {
            // Get list of users and send it as UserNames
            List<User> users = _context.Users
                .Include(c => c.Characters)
                .ToList();
            ViewData["UserNames"] = users;

            // Get a single user. This is the user we want the character to belong to from the form
            User user = _context.Users.Where(u => u.UserId == userId)
                .Include(c => c.Characters)
                .SingleOrDefault();

            
            if (ModelState.IsValid && user != null)
            {
                _context.Add(character);
                user.Characters.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Get list of users and send it as UserNames
            List<User> users = _context.Users
                .Include(c => c.Characters)
                .ToList();
            ViewData["UserNames"] = users;

            foreach (User u in users)
                foreach (Character c in u.Characters)
                    if (c.CharacterId == id)
                        ViewData["User"] = u;
                                    

            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,Name")] Character character, int userId)
        {
            

            if (id != character.CharacterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync(); // TODO: The instance of entity type 'Item' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked

                    // Get list of users and send it as UserNames
                    List<User> users = _context.Users
                        .Include(c => c.Characters)
                        .ToList();
                    ViewData["UserNames"] = users;
                    

                    // Find one user from that list. This is the user we are changing the character to
                    User user = users.Find(u => u.UserId == userId);
                    ViewData["User"] = user;

                    // We look by the ID because the other information might be different
                    int i = user.Characters.FindIndex(c => c.CharacterId == character.CharacterId);
                    if (i < 0)
                    {
                        foreach (User u in users)
                        {
                            int j = user.Characters.FindIndex(c => c.CharacterId == character.CharacterId);
                            if (j >= 0)
                            {
                                u.Characters.RemoveAt(j);
                            }
                        }
                        user.Characters.Add(character);
                        await _context.SaveChangesAsync();
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.CharacterId))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
