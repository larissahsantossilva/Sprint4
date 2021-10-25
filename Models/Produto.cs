using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Models
{
    [Table("Tbl_Produto")]
    public class Produto
    {
        [Column("Id"), HiddenInput]
        public int ProdutoId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Column("Dt_compra"), Required, Display(Name = "Data da Compra" ), DataType(DataType.Date)]
        public DateTime DataCompra { get; set; }

        [Column("Dt_validade"), Required, Display(Name = "Data de Validade"), DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

        [Display(Name = "Descrição"), MaxLength(250)]
        public string Descricao { get; set; }

        [Display(Name = "O produto é Vegano")]
        public bool Vegano { get; set; }

        // MUITOS PARA MUITOS //
        public IList<ItemProduto> ItensProdutos { get; set; }

    }
}
