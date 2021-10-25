using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Models
{
    [Table("Tbl_Item_Produto")]
    public class ItemProduto
    {
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public Inventario Inventario { get; set; }
        public int InventarioId { get; set; }
    }
}
