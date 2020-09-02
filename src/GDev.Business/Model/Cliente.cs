using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model
{
    public class Cliente : Entity
    {
        public string RazaoSocial { get; set; }
        public IEnumerable<Acesso> Acessos { get; set; }
    }
}
