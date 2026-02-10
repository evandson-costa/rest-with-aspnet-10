using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace RestWithAspNet10.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("sum/{first}/{second}")]
    public IActionResult Sum(string first, string second)
    {
        if (isNumeric(first) && isNumeric(second))
        {
            var result = ConvertToDecimal(first) + ConvertToDecimal(second);
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{first}/{second}")]
    public IActionResult Subtraction(string first, string second)
    {
        if (isNumeric(first) && isNumeric(second))
        {
            var result = ConvertToDecimal(first) - ConvertToDecimal(second);
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{first}/{second}")]
    public IActionResult Multiplication(string first, string second)
    {
        if (isNumeric(first) && isNumeric(second))
        {
            var result = ConvertToDecimal(first) * ConvertToDecimal(second);
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{first}/{second}")]
    public IActionResult Division(string first, string second)
    {
        if (isNumeric(first) && isNumeric(second))
        {
            var divisor = ConvertToDecimal(second);
            if (divisor == 0)
                return BadRequest("Division by zero is not allowed.");

            var result = ConvertToDecimal(first) / divisor;
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("mean/{first}/{second}")]
    public IActionResult Mean(string first, string second)
    {
        if (isNumeric(first) && isNumeric(second))
        {
            var result = (ConvertToDecimal(first) + ConvertToDecimal(second)) / 2;
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("square-root/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (isNumeric(number))
        {
            var value = ConvertToDecimal(number);
            if (value < 0)
                return BadRequest("Square root of a negative number is not allowed.");

            var result = Math.Sqrt((double)value);
            return Ok(result);
        }

        return BadRequest("Invalid Input");
    }

    private bool isNumeric(string value)
    {
        decimal number;
        bool isNUmber = decimal.TryParse(
            value,
            NumberStyles.Any,
            NumberFormatInfo.InvariantInfo,
             out number);
        return isNUmber;
    }

    private decimal ConvertToDecimal(string value)
    {
        if (decimal.TryParse(value,
            NumberStyles.Any,
            NumberFormatInfo.InvariantInfo,
            out var number))
        {
            return number;
        }
        return 0;
    }
}
