using System.Xml.Serialization;
namespace MvcMovie.Models;

[XmlRoot("Resultado")]
public class ErrorViewModel
{
    [XmlElement("Gastos totales")]
    public decimal gasto { get; set; }

}
