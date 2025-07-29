using System.Xml.Serialization;
namespace MvcMovie.Models;


public class ProcedureInsertar
{
   
    [XmlElement("NumeroDeFactura")]
    public int numFactura { get; set; }
    [XmlElement("Fecha")]
    public DateTime fecha { get; set; }
   
    
}
