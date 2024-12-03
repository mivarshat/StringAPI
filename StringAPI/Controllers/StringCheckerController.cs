using Microsoft.AspNetCore.Mvc;

namespace StringAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringCheckerController : ControllerBase
    {
        [HttpPost("Check-Alphabets")]
        public IActionResult CheckAlphabets([FromBody] String input)
        {
            if (input == null || string.IsNullOrEmpty(input))
                return BadRequest("Input string cannot be null or empty.");

            bool result = CheckAllAlphabets(input);

            return Ok(new { ContainsAllLetters = result });
        }

        private bool CheckAllAlphabets(string input)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            var inputLower = input.ToLower().Where(char.IsLetter).ToHashSet();
            return alphabet.All(inputLower.Contains);
        }
    }
}
