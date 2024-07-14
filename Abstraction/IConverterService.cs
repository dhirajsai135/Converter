namespace Converter.Abstraction;

public interface IConverterService
{
    UnitConversion Convert(UnitConversion unitConversion);
    List<SelectListItem> GetOutputUnits(ConversionType conversionType);
}
