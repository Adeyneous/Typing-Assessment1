using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_Test.Controllers
{
    public class DataEntryController : Controller
    {
        private OpenAIAPI _api;

        public DataEntryController()
        {
            // Initialize the OpenAI API with your API key
            _api = new OpenAIAPI("your-api-key");
        }

        public async Task<IActionResult> DataEntry()
        {
            // Ensure each call to GenerateDataWithOpenAI has the correct prompt argument
            ViewBag.FirstName = await GenerateDataWithOpenAI("First Name:");
            ViewBag.LastName = await GenerateDataWithOpenAI("Last Name:");
            ViewBag.Address = await GenerateDataWithOpenAI("Address:");
            ViewBag.City = await GenerateDataWithOpenAI("City:");
            ViewBag.State = await GenerateDataWithOpenAI("State:");
            ViewBag.ZipCode = await GenerateDataWithOpenAI("Zip Code:"); // Make sure you have this line if you need a Zip Code
            ViewBag.Company = await GenerateDataWithOpenAI("Company:");
            ViewBag.Position = await GenerateDataWithOpenAI("Position:");
                
            return View();
        }

        private async Task<string> GenerateDataWithOpenAI(string prompt)
        {
            // Make a call to the API to generate data based on the prompt
            var response = await _api.Completions.CreateCompletionAsync(prompt, stopSequences: new string[] { "\n" });
            
            // Assuming 'response' has a 'Choices' property that contains the generated text
            // The following line may need to be adjusted depending on the structure of 'response'
            return response.Choices.FirstOrDefault()?.Text.Trim(); // This ensures a string is returned
        }
    }
}
