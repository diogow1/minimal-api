using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.Dominio.DTOs;
using MinimalAPI.Dominio.Entidades;


namespace MinimalAPI.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login (LoginDTO loginDTO);

        Administrador Incluir (Administrador administrador);
        
        Administrador? BuscarPorId(int id);
        List<Administrador> Todos(int? pagina);
    }
}