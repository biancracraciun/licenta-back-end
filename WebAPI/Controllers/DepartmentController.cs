using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		 public DepartmentController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		[HttpGet]
		 public JsonResult Get()
		{
			string query = @"
                          select DepartmentId, DepartmentName from dbo.Department";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("AppCon");
			SqlDataReader myReader;
			using(SqlConnection myCon= new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using(SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader); ;

					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult(table);
		   }

		//[HttpGet]
		//public JsonResult GetInvertorData()
		//{
		//	var _solaxService = new SolaxService();
		//	var data = _solaxService.GetCloudData();

			//return new JsonResult(data);
		//}




	}
}
