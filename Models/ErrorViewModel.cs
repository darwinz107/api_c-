using System.Xml.Serialization;
namespace MvcMovie.Models;

[XmlRoot("Resultado")]
public class ErrorViewModel
{
    [XmlElement("GastosTotales")]
    public decimal gasto { get; set; }

}
