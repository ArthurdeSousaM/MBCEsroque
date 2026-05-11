using System.ComponentModel.DataAnnotations;

namespace MBCEstoque.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome Obrigatório")]
        [MaxLength(100,ErrorMessage ="Esse campo pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [MaxLength(500)]
        
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
