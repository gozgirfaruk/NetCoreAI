using _020_RecipeSuggestion.Models;
using Microsoft.AspNetCore.Mvc;

namespace _020_RecipeSuggestion.Controllers
{
    public class DefaultController : Controller
    {
        private readonly OpenAIService _openAiService;

        public DefaultController(OpenAIService openAiService)
        {
            _openAiService = openAiService;
        }


        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string ingredients)
        {
            var result = await _openAiService.GetRecipeAsync(ingredients);
            ViewBag.Recipe = result;
            return View();
        }
    }
}
