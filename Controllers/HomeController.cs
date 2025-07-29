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

    [HttpGet("{ced}")]
    [Produces("application/xml")]
    public IActionResult GetGastos(int ced)
    {
        int cedula = ced;
        decimal total = 0;
       

        using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        ErrorViewModel errorViewModel = new ErrorViewModel();
        errorViewModel.gasto = total;

        return Ok(errorViewModel);

    }

    [HttpPost]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    public IActionResult insertarFactura([FromBody] ProcedureResultsModel procedureResultsModel)
    {

        var listRecibos = new List<object>();
        
        FacturasList facturas = new FacturasList();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                MySqlCommand command = new MySqlCommand("nathaly_zhinin_ingresarFactura", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@cantidad", procedureResultsModel.cantidad);
                command.Parameters.AddWithValue("@precio", procedureResultsModel.precio);
                command.Parameters.AddWithValue("@cedula", procedureResultsModel.cedula);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProcedureInsertar insertar = new ProcedureInsertar();
                    insertar.numFactura = reader.GetInt16(0);
                    insertar.fecha = reader.GetDateTime(1);

                    facturas.facturas.Add(insertar);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
        

        return Ok(facturas);
    }
}
