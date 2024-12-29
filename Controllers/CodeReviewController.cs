using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviewEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeReviewController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CodeReviewController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("review")]
        public async Task<IActionResult> ReviewCode([FromBody] CodeReviewRequest request)
        {
            string llmApiUrl = "https://api.openai.com/v1/completions";
            string apiKey = "YOUR_OPENAI_API_KEY"; // Replace with your API key

            var llmRequest = new
            {
                model = "gpt-4",
                prompt = $"Please review the following code for any bugs, optimization opportunities, security issues, and documentation improvements. Provide suggestions for each.\n\n{request.Code}",
                max_tokens = 500
            };

            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(llmRequest),
                Encoding.UTF8,
                "application/json"
            );

            content.Headers.Add("Authorization", $"Bearer {apiKey}");

            var response = await _httpClient.PostAsync(llmApiUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            return Ok(new { feedback = responseBody });
        }
    }

    public class CodeReviewRequest
    {
        public string Code { get; set; }
    }
}
