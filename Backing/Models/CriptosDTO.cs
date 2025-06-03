namespace Backing.Models
{
    public class CriptosDTO
    {
        public int PrcId { get; set; }
        public int CrmId { get; set; }
        public string? CrmNombre { get; set; }
        public string? CrmSimbolo { get; set; }
        public int MonId { get; set; }
        public string? MonSimbolo { get; set; }
        public string? MonNombre { get; set; }
        public decimal PrcPrecio { get; set; }
        public DateTime PrcPrecioFecha { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Actualizacion { get; set; }
    }
}
