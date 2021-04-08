using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Data.Access;
using DynamicDatabase.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using DynamicDatabase.Utilities;

namespace DynamicDatabase.Controllers
{
    public class AttributesController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public AttributesController(RepositoryContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        // GET: Attributes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attributes.ToListAsync());
        }


        [HttpGet]
        public IActionResult GetAttributes()
        {
            var result = _context.Attributes.ToListAsync().Result;
            return Ok(result);
        }








        // GET: Attributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // GET: Attributes/Create
        public IActionResult Create()
        {
            var model = new AttributeViewModel
            {
                Attribute = new Data.Entities.Attribute(),
                EntityTypes = _context.EntityTypes.ToList()
            };

            return View(model);
        }

        // POST: Attributes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttributeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Add(model.Attribute);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("loadData");
            return RedirectToAction(nameof(Index));
        }

        // GET: Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }
            return View(attribute);
        }

        // POST: Attributes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityTypeId,Name,Id,IsActive")] Data.Entities.Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribute);
                    await _context.SaveChangesAsync();
                    await _signalRHub.Clients.All.SendAsync("loadData");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(attribute.Id))
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
            return View(attribute);
        }

        // GET: Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attribute = await _context.Attributes.FindAsync(id);
            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("loadData");
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.Id == id);
        }
    }
}
