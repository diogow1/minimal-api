using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalAPI.Dominio.ModelViews
{
    public class AdmLogado
    {
        public string Email { get; set; } = default;
        public string Perfil { get; set; } = default;

        public string? Token { get; set; }
    }
}