namespace Converter.Models;

public class UnitConversion
{
    public ConversionType ConversionType { get; set; }
    public double InputValue { get; set; }
    public double OutputValue { get; set; }
    public OutputConversionType InputUnitType { get; set; }
    public string InputUnitTypeString 
    {
        get
        {
            return InputUnitType.GetDescription();
        } 
    }
    public OutputConversionType OutputUnitType { get; set; }
    public string OutputUnitTypeString
    {
        get
        {
            return OutputUnitType.GetDescription();
        }
    }
    public string ResponseMessage { get; set; }
}
