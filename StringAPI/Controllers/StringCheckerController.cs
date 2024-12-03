using Microsoft.AspNetCore.Mvc;

namespace StringAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringCheckerController : ControllerBase
    {
        [HttpPost("Check-Alphabets")]
        public int CheckAlphabets([FromBody] String input)
        {
            if (input == null || string.IsNullOrEmpty(input))
                return StatusCodes.Status400BadRequest;

            bool result = CheckAllAlphabets(input);
            if(result) 
            {
                return StatusCodes.Status200OK; 
            }
            else
            {
                return StatusCodes.Status400BadRequest;
            }

        }

        private bool CheckAllAlphabets(string input)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            var inputLower = input.ToLower().Where(char.IsLetter).ToHashSet();
            return alphabet.All(inputLower.Contains);
        }
    }
}
