namespace Reto_Pedidos.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; } = null!;
        public string Cliente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;
    }
}
