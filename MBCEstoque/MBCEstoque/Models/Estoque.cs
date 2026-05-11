using MBCEstoque.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Estoque
{
    [Key]
    public int Id { get; set; }

    public int ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto? Produto { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser negativa")]
    public int QuantidadeAtual { get; set; }

    public int EstoqueMinimo { get; set; }
    public int EstoqueMaximo { get; set; } = 9999;

    [MaxLength(100)]
    public string? Localizacao { get; set; }   

    public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;

    [NotMapped]
    public bool EstaBaixo => QuantidadeAtual < EstoqueMinimo;

    [NotMapped]
    public string Status =>
        QuantidadeAtual == 0 ? "Sem Estoque" :
        QuantidadeAtual < EstoqueMinimo ? "Crítico" :
        QuantidadeAtual >= EstoqueMaximo ? "Cheio" : "Normal";
}