using System.Xml.Serialization;
namespace MvcMovie.Models;

[XmlRoot("RecaudadoPorFecha")]
public class RecaudadoPorFecha
{
   
    [XmlElement("Total")]
    public decimal total { get; set; }
    
}