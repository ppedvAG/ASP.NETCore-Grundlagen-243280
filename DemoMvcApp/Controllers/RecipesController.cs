using BusinessLogic.Contracts;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: RecipesController
        public ActionResult Index()
        {
            var recipes = _recipeService.GetRecipes();
            return View(recipes.Select(r => r.ToViewModel()));
        }

        // GET: RecipesController/Details/5
        public ActionResult Details(int id)
        {
            var recipe = _recipeService.GetRecipe(id);
            return View(recipe.ToViewModel());
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipesViewModel model)
        {
            try
            {
                _recipeService.AddRecipe(model.ToDomainModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipesViewModel model)
        {
            try
            {
                _recipeService.UpdateRecipe(model.ToDomainModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public ActionResult Delete(int id)
        {
            _recipeService.DeleteRecipe(id);
            return View();
        }
    }
}
