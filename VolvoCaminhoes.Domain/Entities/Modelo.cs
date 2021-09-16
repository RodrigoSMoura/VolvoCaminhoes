using System.ComponentModel.DataAnnotations;
using VolvoCaminhoes.Domain.Entities.IdEntity;

namespace VolvoCaminhoes.Domain.Entities
{
    public class Modelo : IIdEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]        
        public string Nome { get; set; }
    }
}
