using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WPFDecstop.Models;
using IKey = Microsoft.AspNetCore.DataProtection.KeyManagement.IKey;
using Key = Renci.SshNet.Security.Key;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class GetKey : ControllerBase
{
    
    private readonly ILogger<GetKey> _logger;

    public GetKey(ILogger<GetKey> logger)
    {
        _logger = logger;
    }
    // GET
    [HttpGet("{key}" )]
    public IEnumerable<String> Get( string key)
    {
        if (new TimetableContext().Keys.Where(p => p.key == key).ToList().Count() == 1)
            return new[] { "ok", };
        return new string[] {"false" };
    }
}