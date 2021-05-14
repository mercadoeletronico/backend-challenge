using System.Collections.Generic;
namespace Infra.BD
{
    public class BDPedidos
    {
        public string IdPedido { get; set; }


        public List<BDItensPedidos> ItensPedido { get; set; }


    }
    
}