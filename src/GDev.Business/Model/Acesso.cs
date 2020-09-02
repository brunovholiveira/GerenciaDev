using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model
{
    public class Acesso : Entity
    {
        public Guid ModuloId { get; set; }
        public Guid ClienteId { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public Modulo Modulo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
