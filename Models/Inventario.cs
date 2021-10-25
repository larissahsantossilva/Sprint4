using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Models
{
    [Table("Tbl_Inventario")]
    public class Inventario
    {
        [Column("Id"), HiddenInput]
        public int InventarioId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        [Display(Name = "Descrição"), Required, MaxLength(250)]
        public string Descricao { get; set; }

        // RELACIONAMENTO DE MUITOS PARA MUITOS //
        public IList<ItemProduto> ItensProdutos { get; set; }
    }
}
