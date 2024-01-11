using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using System;
using System.Threading.Tasks;
using System.Linq; // Include this for LINQ operations

namespace Assessment_Test.Controllers
{
    public class TypeAssessController : Controller
    {
        private readonly OpenAIAPI _api;

        // Constructor with IConfiguration parameter
        public TypeAssessController(IConfiguration configuration)
        {
            // Retrieve the API key from the configuration
            var apiKey = configuration["OpenAI:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("OpenAI API key is not configured.");
            }

            _api = new OpenAIAPI(apiKey);
        }

        public async Task<IActionResult> GeneralTypingAssessment()
        {
            string generatedText = await GenerateParagraphWithOpenAI();
            ViewBag.GeneratedText = generatedText;
            return View();
        }

        private async Task<string> GenerateParagraphWithOpenAI()
        {
            var response = await _api.Completions.CreateCompletionAsync("Write a creative paragraph about space exploration.", stopSequences: new string[] { "\n" });
            return response.Text.FirstOrDefault()?.Text.Trim();
        }
    }
}

