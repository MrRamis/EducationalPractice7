using Microsoft.AspNetCore.Mvc;
using WPFDecstop.Models;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class GetTeacher : ControllerBase
{
    private readonly ILogger<GetTeacher> _logger;

    public GetTeacher(ILogger<GetTeacher> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTeacher")]
    public IEnumerable<Teacher> Get()
    {
        var t = new TimetableContext().Teachers.ToList();
        List<TeacherJs> tr= new List<TeacherJs>(){new TeacherJs(){Surname = ""}};
        foreach (var VARIABLE in t)
        {
            tr.Add( new TeacherJs(){ Surname = VARIABLE.ToString()});
        }
        return t.ToArray();
    }

}


public  class TeacherJs
{
    public string Surname { get; set; }
    public string FirstName { get; set; }
}
