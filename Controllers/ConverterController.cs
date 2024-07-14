namespace Converter.Controllers;

public class ConverterController : Controller
{
    private readonly IConverterService _converterService;

    public ConverterController(IConverterService converterService)
    {
        _converterService = converterService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Convert([FromBody] UnitConversion unitConversion)
    {
        try
        {
            var result = _converterService.Convert(unitConversion);
            return Json(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet]
    public IActionResult GetOutputUnits(ConversionType outputType)
    {
        try
        {
            return Json(_converterService.GetOutputUnits(outputType));
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}
