using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VolvoCaminhoes.Domain.Entities.IdEntity;

namespace VolvoCaminhoes.Domain.Entities
{
    public class Caminhao : IIdEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Modelo))]
        public int IdModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        
        [ForeignKey(nameof(IdModelo))]
        public virtual Modelo Modelo { get; set; }
    }
}
