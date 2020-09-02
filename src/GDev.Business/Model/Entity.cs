using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model
{
    public class Entity 
    {
        public Guid Id { get; set; }
        public DateTime DiaCadastro { get; set; }
        public DateTime? DiaAlteracao { get; set; }

        public Entity()
        {
            Id = new Guid();
            DiaCadastro = DateTime.Now;
        }
    }
}
