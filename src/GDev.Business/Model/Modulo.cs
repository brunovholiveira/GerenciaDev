using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model
{
    public class Modulo : Entity
    {
        public string Descricao { get; set; }

        public IEnumerable<Acesso> Acessos { get; set; }
    }
}
