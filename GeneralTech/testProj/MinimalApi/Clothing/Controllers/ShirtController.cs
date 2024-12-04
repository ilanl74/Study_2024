using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Clothing;
[ApiController]
[Route("/api/[Controller]")]
public class ShirtController : ControllerBase
{
    private static List<ShirtModel> _shirts = new List<ShirtModel>(){
            new(){ InternalId=0, Brnd="new brand", Model="not much of a model" , Size=44},
            new(){InternalId=1, Brnd="second brand", Model="second model" , Size=40},
            new(){InternalId=2, Brnd="second brand", Model="first model" , Size=40},
            new(){InternalId =3,Brnd="new brand", Model="first model" , Size=40}



            };
    [HttpGet]
    public IActionResult GetAll()
    {


        return Ok(_shirts);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<string> Add([FromBody] ShirtModel shirt)// best to use ActionResult over IActionResult because of type safty
    {
        // if(ModelState.Select(x=> x.[""].err IsValid)
        var internalId = _shirts.Max(s => s.InternalId) + 1;
        shirt.InternalId = internalId;
        _shirts.Add(shirt);
        return NotFound();
        //return bad();
        //return Ok($"the list contains {_shirts.Count} elements");
    }
}
