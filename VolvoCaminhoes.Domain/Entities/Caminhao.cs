using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VolvoCaminhoes.Domain.Entities.IdEntity;
using VolvoCaminhoes.Domain.Validation;

namespace VolvoCaminhoes.Domain.Entities
{
    public class Caminhao : IIdEntity
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }
        [ForeignKey(nameof(Modelo))]
        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Selecione um Modelo.")]
        public int IdModelo { get; set; }
        [DisplayName("Ano de Fabricação")]
        public int AnoFabricacao { get; set; }
        [DisplayName("Ano do Modelo")]
        [Required(ErrorMessage = "Insira o Ano do Modelo.")]        
        public int AnoModelo { get; set; }

        [ForeignKey(nameof(IdModelo))]
        public virtual Modelo Modelo { get; set; }
    }
}
