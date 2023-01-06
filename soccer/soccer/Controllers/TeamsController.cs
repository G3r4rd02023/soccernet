using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soccer.Data;
using soccer.Data.Entities;
using soccer.Helpers;
using soccer.Models;
using Vereyon.Web;

namespace soccer.Controllers
{
    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;


        public TeamsController(DataContext context, IFlashMessage flashMessage, IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _flashMessage = flashMessage;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                }

                var team = _converterHelper.ToTeam(model, path, true);
                _context.Add(team);

                try
                {                    
                    await _context.SaveChangesAsync();
                    _flashMessage.Confirmation("Equipo creado!");
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un equipo con ese nombre!");
                    }
                    else
                    {
                        _flashMessage.Danger(string.Empty, ex.InnerException.Message);
                    }
                }

            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            TeamViewModel model = _converterHelper.ToTeamViewModel(team);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var path = model.LogoPath;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                }

                Team team = _converterHelper.ToTeam(model, path, false);
                _context.Update(team);

                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                    _flashMessage.Warning("Equipo actualizado!");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger(string.Empty, "Ya existe un equipo con ese nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(string.Empty, ex.InnerException.Message);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var edificio = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (edificio == null)
            {
                return NotFound();
            }

            try
            {
                _context.Teams.Remove(edificio);
                await _context.SaveChangesAsync();
                _flashMessage.Info("Registro borrado.");

            }
            catch
            {
                _flashMessage.Danger("No se puede borrar el equipo porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
