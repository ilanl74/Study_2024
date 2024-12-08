using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Microsoft.Extensions.Options;

namespace Clothing;
[ApiController]
[Route("/api/[Controller]")]
public class ShirtController : ControllerBase
{
    private static List<ShirtModel> _shirts = new List<ShirtModel>(){
            new(){ExternalId="1",  Brand="new brand", Model="not much of a model" , Size=44},
            new(){ ExternalId="2",Brand="second brand", Model="second model" , Size=40},
            new(){ExternalId="3", Brand="second brand", Model="first model" , Size=40},
            new(){ExternalId="4",Brand="new brand", Model="first model" , Size=40}



            };
    private readonly CSettings _settings;
    private readonly string _defaultConnectionString;
    public ShirtController(IOptions<CSettings> s, string defaultConnectionString)
    {
        _settings = s.Value;
        _defaultConnectionString = defaultConnectionString;
    }

    [HttpPost("init")]
    public async Task<IActionResult> InitialLoad([FromBody] Rdata da)
    {
        var x = HttpContext.Items["Stam"] as AData;
        var shirtDb = new DT_ShirtModel(_defaultConnectionString);
        await shirtDb.Add(_shirts.ConvertAll(s => (s.ExternalId, s.Size, s.Model, s.Brand)));
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        Console.WriteLine("GetAll shirts");
        await Task.Delay(2000);
        return Ok(_shirts);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Add([FromBody] ShirtModel shirt)// best to use ActionResult over IActionResult because of type safty
    {
        // if(ModelState.Select(x=> x.[""].err IsValid)
        var internalId = _shirts.Max(s => s.InternalId) + 1;
        shirt.InternalId = internalId;
        _shirts.Add(shirt);
        await Task.Delay(100);
        return NotFound();
        //return bad();
        //return Ok($"the list contains {_shirts.Count} elements");
    }
}
