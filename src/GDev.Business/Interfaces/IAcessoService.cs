﻿using GDev.Business.Model;
using System;
using System.Threading.Tasks;

namespace GDev.Business.Interfaces
{
    public interface IAcessoService : IDisposable
    {
        Task Adicionar(Acesso acesso);
        Task Atualizar(Acesso acesso);
        Task Remover(Guid id);
    }
}
