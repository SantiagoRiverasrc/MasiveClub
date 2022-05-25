using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MasiveApi.Api.Data
{
    public partial class Detalles
    {
        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public int CodigoFactura { get; set; }
        public int Cantidad { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }

        public virtual Factura CodigoFacturaNavigation { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
