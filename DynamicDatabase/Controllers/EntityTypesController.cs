using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Data.Entities;
using DynamicDatabase.Data.Repos.Abstract;
using DynamicDatabase.Models.ViewModels;
using DynamicDatabase.Utilities;
using Microsoft.AspNetCore.SignalR;

namespace DynamicDatabase.Controllers
{
    public class EntityTypesController : Controller
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public EntityTypesController(IEntityTypeRepository entityTypeRepository,
            IHubContext<SignalRServer> signalRHub)
        {
            _entityTypeRepository = entityTypeRepository;
            _signalRHub = signalRHub;
        }

        // GET: EntityTypes
        public async Task<IActionResult> Index()
        {
            var model = new EntityViewModel
            {
                EntityTypes = await _entityTypeRepository.GetListAsync(),
                EntityType = new EntityType()
            };

            return View(model);
        }

        
        [HttpGet]
        public IActionResult GetEntityTypes()
        {
            var result = _entityTypeRepository
                .GetListAsync().Result;

            return Ok(result);
        }


        // POST: EntityTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create([Bind("Name,IsActive")] EntityType entityType)
        {
            if (!ModelState.IsValid) return;

            _entityTypeRepository.AddAsync(entityType);
            await _signalRHub.Clients.All.SendAsync("loadData");
        }

        // GET: EntityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var entityType = await _entityTypeRepository
                .GetAsync(x => x.Id == id);

            if (entityType == null)
                return NotFound();

            return View(entityType);
        }

        // POST: EntityTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Name,Id,IsActive")] EntityType entityType)
        {
            if (id != entityType.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(entityType);

            try
            {
                await Task.Run(() => _entityTypeRepository
                    .UpdateAsync(entityType));

                await _signalRHub.Clients.All.SendAsync("loadData");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(entityType.Id).Result)
                    return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: EntityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async void DeleteConfirmed(int id)
        {
            var entityType = await _entityTypeRepository
                .GetAsync(x => x.Id == id);
            _entityTypeRepository.DeleteAsync(entityType);

            await _signalRHub.Clients.All.SendAsync("loadData");
        }


        private async Task<bool> DataExists(int id)
        {
            var data = await _entityTypeRepository
                .GetAsync(e => e.Id == id);

            return data != null;
        }
    }
}