using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProgettoConNunzioAspNet.Models;
//using ProgettoConNunzioAspNet.Models;

namespace ProgettoConNunzioAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NunzioAspNetController : ControllerBase
    {
        private readonly ILogger<NunzioAspNetController> _logger;
        private readonly NunzioDbDemoContext _ctx;

        public NunzioAspNetController(ILogger<NunzioAspNetController> logger, NunzioDbDemoContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet(Name = "GetNunzioAspNetDummyData")]
        public IEnumerable<NunzioDataDummy> Get()
        {
            var nunzioDatabases = new List<NunzioDataDummy>
            {
                new NunzioDataDummy { Id = 1, Descrizione = "Descrizione 1", Numero = 100 },
                new NunzioDataDummy { Id = 2, Descrizione = "Descrizione 2", Numero = 200 },
                new NunzioDataDummy { Id = 3, Descrizione = "Descrizione 3", Numero = 300 },
                new NunzioDataDummy { Id = 4, Descrizione = "Descrizione 4", Numero = 400 },
                new NunzioDataDummy { Id = 5, Descrizione = "Descrizione 5", Numero = 500 }
            };

            return nunzioDatabases;
        }

        /*[HttpGet(Name = "GetAllNunzioDataDummy")]
        public IEnumerable<NunzioDataDummy> GetAll()
        {
            return _ctx.NunzioDataDummies.ToList();
        }*/
    }
}

