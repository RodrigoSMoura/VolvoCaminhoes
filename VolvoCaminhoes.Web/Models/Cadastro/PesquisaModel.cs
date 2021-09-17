using System.Collections.Generic;
using System.ComponentModel;
using VolvoCaminhoes.Domain.Entities;

namespace VolvoCaminhoes.Web.Models.Cadastro
{
    public class PesquisaModel
    {
        [DisplayName("Modelo")]
        public int? IdModelo { get; set; }
        [DisplayName("Ano de Fabricação")]
        public int? AnoFabricacao { get; set; }

        public List<Caminhao> Caminhoes { get; set; }
    }
}
