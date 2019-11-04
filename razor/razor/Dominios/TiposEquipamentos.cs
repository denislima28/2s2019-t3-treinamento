﻿using System;
using System.Collections.Generic;

namespace razor.Dominios
{
    public partial class TiposEquipamentos
    {
        public TiposEquipamentos()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }
    }
}
