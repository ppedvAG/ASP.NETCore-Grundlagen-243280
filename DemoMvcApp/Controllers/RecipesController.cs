﻿using BusinessLogic.Contracts;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
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
        public ActionResult Create(CreateRecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _recipeService.AddRecipe(model.ToDomainModel());
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError("Recipe could not be created: " + ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            } 
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, errors));
            }

            // Wir muessen das Model zurueckgeben, damit der Benutzer die Formulardaten nicht erneut eintrage muss.
            return View(model);
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
