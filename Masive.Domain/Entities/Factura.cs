using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MasiveApi.Api.Data
{
    public partial class Factura
    {
        public Factura()
        {
            Detalles = new HashSet<Detalles>();
        }

        public int CodigoFactura { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Detalles> Detalles { get; set; }
    }
}
