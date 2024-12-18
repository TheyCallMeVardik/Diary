using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ClassesController : Controller
{
    private readonly DatabaseService _databaseService;

    public ClassesController(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // Получить все классы
    public async Task<IActionResult> Index()
    {
        var classes = await _databaseService.GetClassesAsync();
        return Ok(classes); // Возвращает JSON
    }

    // Добавить новый класс
    [HttpPost]
    public async Task<IActionResult> CreateClass([FromBody] Class newClass)
    {
        await _databaseService.InsertClassAsync(newClass);
        return Ok();
    }
}
