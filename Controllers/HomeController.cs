using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MySql.Data.MySqlClient;


namespace MvcMovie.Controllers;

[ApiController]
[Route("app/xd")]
public class HomeController : Controller
{
      const string connectionString =
            "Server=localhost;Database=dbdar;"
            + "Uid=root;Pwd=root;";

    [HttpGet]
    [Produces("application/xml")]
    public IActionResult GetGastos([FromBody] ErrorViewModel body )
    {
        int cedula = body.Cedula;
        decimal total = 0;
        

        using ( MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand("obtenerGastoTotal", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cedula", cedula);

            MySqlParameter getOutPut = new MySqlParameter("resultado", MySqlDbType.Decimal);
            getOutPut.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(getOutPut);


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                total = (decimal)command.Parameters["resultado"].Value;
            }
            catch (System.Exception)
            {

                throw;

            }
    }
        var listGastos = new List<ProcedureResultsModel>();
        listGastos.Add(new
        ProcedureResultsModel{
            TotalDeGastos = total
        });
        
 return Ok(listGastos);
       
    }
}
