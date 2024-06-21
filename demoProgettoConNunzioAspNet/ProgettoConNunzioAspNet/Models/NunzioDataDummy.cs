using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgettoConNunzioAspNet.Models;

public partial class NunzioDataDummy
{
    public int Id { get; set; }

    public string? Descrizione { get; set; }

    public int? Numero { get; set; }

    public NunzioDataDummy NunzioDataDummyBuilder()
    {
        NunzioDataDummy _dataDummy = new NunzioDataDummy();

        _dataDummy.Numero = 100;
        _dataDummy.Descrizione = "Vuolsi così colà dove si puote";

        return _dataDummy;
    }
}
