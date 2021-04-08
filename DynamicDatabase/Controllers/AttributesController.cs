using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Data.Access;
using DynamicDatabase.Data.Entities;
using DynamicDatabase.Data.Repos.Abstract;
using DynamicDatabase.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using DynamicDatabase.Utilities;

namespace DynamicDatabase.Controllers
{
    public class AttributesController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public AttributesController(RepositoryContext context,
            IHubContext<SignalRServer> signalRHub,
            IAttributeRepository attributeRepository,
            IEntityTypeRepository entityTypeRepository)
        {
            _context = context;
            _signalRHub = signalRHub;
            _attributeRepository = attributeRepository;
            _entityTypeRepository = entityTypeRepository;
        }

        // GET: Attributes
        public async Task<IActionResult> Index()
        {
            var model = new AttributeViewModel
            {
                EntityTypes = await _entityTypeRepository.GetListAsync(),
                Attribute = new Attribute()
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult GetAttributes()
        {
            var result = _context.Attributes
                .ToListAsync().Result;

            return Ok(result);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create([Bind("EntityTypeId,Name,IsActive")] Attribute attribute)
        {
            if (!ModelState.IsValid) return;

            _attributeRepository.AddAsync(attribute);
            await _signalRHub.Clients.All.SendAsync("loadData");
        }

        // GET: Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var attribute = await _attributeRepository
                .GetAsync(x => x.Id == id);

            if (attribute == null)
                return NotFound();

            return View(attribute);
        }

        // POST: Attributes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("EntityTypeId,Name,Id,IsActive")] Attribute attribute)
        {
            if (id != attribute.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(attribute);

            try
            {
                await Task.Run(() => _attributeRepository
                    .UpdateAsync(attribute));

                await _signalRHub.Clients.All.SendAsync("loadData");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(attribute.Id).Result)
                    return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }



        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async void DeleteConfirmed(int id)
        {
            var attribute = await _attributeRepository
                .GetAsync(x => x.Id == id);
            _attributeRepository.DeleteAsync(attribute);

            await _signalRHub.Clients.All.SendAsync("loadData");
        }

        private async Task<bool> DataExists(int id)
        {
            var data = await _attributeRepository
                .GetAsync(e => e.Id == id);

            return data != null;
        }
    }
}