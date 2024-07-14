namespace Converter.Service;

public class ConverterService : IConverterService
{
    public UnitConversion Convert(UnitConversion conversion)
    {
        var result = conversion as UnitConversion;
        switch (result.ConversionType)
        {
            case ConversionType.Length:
                result.OutputValue = convertLength(result.InputValue, result.InputUnitType, result.OutputUnitType);
                break;
            case ConversionType.Weight:
                result.OutputValue = convertWeight(result.InputValue, result.InputUnitType, result.OutputUnitType);
                break;
            case ConversionType.Temperature:
                result.OutputValue = convertTemperature(result.InputValue, result.InputUnitType, result.OutputUnitType);
                break;
            default:
                break;
        }
        result.OutputValue = Math.Round(result.OutputValue, 2);
        return result;
    }

    public List<SelectListItem> GetOutputUnits(ConversionType conversionType)
    {
        List<SelectListItem> outputUnits = [];

        switch (conversionType)
        {
            case ConversionType.Length:
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Kilometer.GetHashCode().ToString(), Text = OutputConversionType.Kilometer.GetDescription() });
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Meter.GetHashCode().ToString(), Text = OutputConversionType.Meter.GetDescription() });
                break;
            case ConversionType.Weight:
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Kilogram.GetHashCode().ToString(), Text = OutputConversionType.Kilogram.GetDescription() });
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Gram.GetHashCode().ToString(), Text = OutputConversionType.Gram.GetDescription() });
                break;
            case ConversionType.Temperature:
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Fahrenheit.GetHashCode().ToString(), Text = OutputConversionType.Fahrenheit.GetDescription() });
                outputUnits.Add(new SelectListItem { Value = OutputConversionType.Celsius.GetHashCode().ToString(), Text = OutputConversionType.Celsius.GetDescription() });
                break;
            default:
                break;
        }
        return outputUnits;
    }

    #region Private methods
    private double convertLength(double inputValue, OutputConversionType inputUnit, OutputConversionType outputUnit)
    {
        if (inputUnit == OutputConversionType.Meter && outputUnit == OutputConversionType.Kilometer)
        {
            return inputValue / 1000;
        }
        else if (inputUnit == OutputConversionType.Kilometer && outputUnit == OutputConversionType.Meter)
        {
            return inputValue * 1000;
        }
        return inputValue;
    }

    private double convertWeight(double inputValue, OutputConversionType inputUnit, OutputConversionType outputUnit)
    {
        if (inputUnit == OutputConversionType.Gram && outputUnit == OutputConversionType.Kilogram)
        {
            return inputValue / 1000;
        }
        else if (inputUnit == OutputConversionType.Kilogram && outputUnit == OutputConversionType.Gram)
        {
            return inputValue * 1000;
        }
        return inputValue;
    }

    private double convertTemperature(double inputValue, OutputConversionType inputUnit, OutputConversionType outputUnit)
    {
        if (inputUnit == OutputConversionType.Celsius && outputUnit == OutputConversionType.Fahrenheit)
        {
            return (inputValue * 9 / 5) + 32;
        }
        else if (inputUnit == OutputConversionType.Fahrenheit && outputUnit == OutputConversionType.Celsius)
        {
            return (inputValue - 32) * 5 / 9;
        }
        return inputValue;
    }
    #endregion
}
