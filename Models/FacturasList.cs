using System.Xml.Serialization;
namespace MvcMovie.Models;

[XmlRoot("Facturas ingresadas")]
public class FacturasList
{
    [XmlElement("Factura")]
    public List<ProcedureInsertar> facturas { get; set; } = new List<ProcedureInsertar>();
    
}
