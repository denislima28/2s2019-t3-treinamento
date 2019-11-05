using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace razor.Dominios
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "Informe a data do defeito")]
        [DataType(DataType.Date)] //Transforma o input num date. Muda como as datas são exibidas, mas é preciso fazer outros comandos.
        [Display(Name = "Data do Defeito")]
        public DateTime DataDefeito { get; set; }

        [Display(Name = "Tipo de equipamento")]
        public int TipoEquipamentoId { get; set; }

        [Display(Name = "Tipo de defeito")]
        public int DefeitoId { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Tipo de defeito")]
        public Defeitos Defeito { get; set; }

        [Display(Name = "Tipo de equipamento")]
        public TiposEquipamentos TipoEquipamento { get; set; }
    }
}
