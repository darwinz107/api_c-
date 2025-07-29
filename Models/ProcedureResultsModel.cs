using System.Xml.Serialization;
namespace MvcMovie.Models;

[XmlRoot("Insertar")]
public class ProcedureResultsModel
{
   
    [XmlElement("cantidad")]
    public int cantidad { get; set; }
    [XmlElement("precio")]
    public decimal precio { get; set; }
    [XmlElement("cedula")]
    public int cedula { get; set; }
    
}
