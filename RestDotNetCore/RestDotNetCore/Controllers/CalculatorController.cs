using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("{firstNumer}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber);
                return Ok(sum);
            }

            return BadRequest("Invalid number");
        }

        private decimal ConverToDecimal(string number)
        {
            if (decimal.TryParse(number, out decimal decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string number)
        {
            bool isnumber = double.TryParse(number, System.Globalization.NumberStyles.Any, NumberFormatInfo.InvariantInfo, out _);

            return isnumber;
        }
    }
}
