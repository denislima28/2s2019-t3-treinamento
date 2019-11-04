using System;
using System.Collections.Generic;

namespace razor.Dominios
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }
        public DateTime DataDefeito { get; set; }
        public int TipoEquipamentoId { get; set; }
        public int DefeitoId { get; set; }
        public string Observacao { get; set; }

        public Defeitos Defeito { get; set; }
        public TiposEquipamentos TipoEquipamento { get; set; }
    }
}
