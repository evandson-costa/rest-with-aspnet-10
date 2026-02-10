namespace RestWithAspNet10.Utils;

public class NumberHelper
{
    public static bool IsNumeric(string strNumber)
    {
        double number;
        return double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
    }

    public static decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }
}