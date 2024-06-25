using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProgettoConNunzioAspNet.Models;
using System.Collections.Generic;

namespace ProgettoConNunzioAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NunzioAspNetController : ControllerBase
    {
        private readonly ILogger<NunzioAspNetController> _logger;

        public NunzioAspNetController(ILogger<NunzioAspNetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNunzioAspNetDummyData")]
        public IEnumerable<NunzioDataDummy> GetFakeNunzioDataDummy()
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


        [HttpGet("GetAllNunzioDummyData")]
        public IActionResult GetAllNunzioDataDummy()
        {
            using (var Db = new NunzioDbDemoContext() )
            {
                return Ok(Db.NunzioDataDummies.ToList());
            }
        }

        [HttpPost("PostNunzioDummyData")]
        public IActionResult PostFakeNunzioDummyData()
        {
            NunzioDataDummy _dataDummy = new NunzioDataDummy();

            _dataDummy.Numero = 100;
            _dataDummy.Descrizione = "Vuolsi così colà dove si puote";

            using (var Db = new NunzioDbDemoContext())
            {
                Db.NunzioDataDummies.Add(_dataDummy);
                Db.SaveChanges();
            }

            return Ok(_dataDummy);
        }

        [HttpPost("Post100NunzioDummyData")]
        public IActionResult Post100FakeNunzioDummyData()
        {
            List<NunzioDataDummy> _dataDummyList = new List<NunzioDataDummy>();

            for (int i = 0; i < 100; i++)
            {
                var _dataDummy = new NunzioDataDummy
                {
                    Numero = i * 5,
                    Descrizione = $"Dummy data n°{i + 1}"
                };
                _dataDummyList.Add(_dataDummy);
            }

            using (var Db = new NunzioDbDemoContext())
            {

                foreach (var item in _dataDummyList)
                {
                    Db.NunzioDataDummies.Add(item);
                }

                Db.SaveChanges();
            }

            return Ok(_dataDummyList);
        }

        [HttpPost("Post100000NunzioDummyData")]
        public IActionResult Post100000FakeNunzioDummyData()
        {
            List<NunzioDataDummy> _dataDummyList = new List<NunzioDataDummy>();
            List<NunzioDataDummy> returndataDummyList = new List<NunzioDataDummy>();

            for (int i = 0; i < 100000; i++)
            {

                var _dataDummy = new NunzioDataDummy
                {
                    Numero = i * 5^2,
                    Descrizione = $"Dummy data n°{i + 1}"
                };
                _dataDummyList.Add(_dataDummy);

                if (i == 0) returndataDummyList.Add(_dataDummy);
                if (i == 99999) returndataDummyList.Add(_dataDummy);
            }

            using (var Db = new NunzioDbDemoContext())
            {

                foreach (var item in _dataDummyList)
                {
                    Db.NunzioDataDummies.Add(item);
                }

                Db.SaveChanges();
            }

            return Ok(returndataDummyList);
        }

        [HttpPost("PostRealNunzioDummyData")]
        public IActionResult PostRealNunzioDummyData([FromBody] NunzioDataDummyModel model)
        {
            // Crea un nuovo inventario
            NunzioDataDummy _dataDummy = new NunzioDataDummy()
            {
                Numero = model.Numero,
                Descrizione = model.Descrizione
            };

            // Aggiunge l'inventario al contesto e salva le modifiche
            using (var Db = new NunzioDbDemoContext())
            {
                Db.NunzioDataDummies.Add(_dataDummy);
                Db.SaveChanges();
            }

            return Ok(_dataDummy);
        }
    }
}

