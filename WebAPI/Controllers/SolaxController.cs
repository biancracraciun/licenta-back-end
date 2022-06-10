using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[Route("api/solax/")]
	[ApiController]
	public class SolaxController : ControllerBase
	{
		private ISolax _solaxService = new SolaxService();

		[HttpGet]
		[Route("StartPopulateData")]
		public void StartPopulateData()
		{
			var data = _solaxService.PolulateCloudData();
		}


		[HttpGet]
		[Route("GetInvertorData")]
		public async Task<JsonResult> GetInvertorData()
		{
			var data = await _solaxService.GetCloudData().ConfigureAwait(false);

			SolaxDto solaxdata = JsonConvert.DeserializeObject<SolaxDto>(data);

			_solaxService.InsertSolaxData(solaxdata);

			return new JsonResult(data);
		}

		[HttpGet]
		[Route("GetStoredData")]
		public async Task<JsonResult> GetDbData()
		{
			var data = _solaxService.GetAllDbData();
				return new JsonResult(data);

		}
		[HttpGet]
		[Route("GetStoredDataChart")]
		public async Task<JsonResult> GetDataChart()
		{
			var data = _solaxService.GetData();
			return new JsonResult(data);

		}
		[HttpGet]
		[Route("GetStoredDataLineChart")]
		public async Task<JsonResult> GetAllDataForLineChart()
		{
			var data = _solaxService.GetLineChartData();
			return new JsonResult(data);

		}

		[HttpGet]
		[Route("GetStoredDataRadarChart")]
		public async Task<JsonResult> GetAllDataForRadarChart()
		{
			var data = _solaxService.GetRadarChartData();
			return new JsonResult(data);

		}

		[HttpGet]
		[Route("GetStoredDataGaugeChart")]
		public async Task<JsonResult> GetAllDataForGaugeChart()
		{
			var data = _solaxService.GetGaugeChartData();
			return new JsonResult(data);

		}

		[HttpGet]
		[Route("GetStoredDataNumberCard")]
		public async Task<JsonResult> GetAllDataForNumberCard()
		{
			var data = _solaxService.GetNumberCardTCData();
			return new JsonResult(data);

		}

		[HttpGet]
		[Route("GetStoredDataNumberYieldTodayCard")]
		public async Task<JsonResult> GetAllDataForNumberYTCard()
		{
			var data = _solaxService.GetNumberCardYTData();
			return new JsonResult(data);


		}

		[HttpGet]
		[Route("GetStoredDataNumberEmisiiCard")]
		public async Task<JsonResult> GetNumberCardEmisiiData()
		{
			var data = _solaxService.GetNumberCardEmisiiData();
			return new JsonResult(data);

		}
		[HttpGet]
		[Route("GetStoredDataNumberSavingsCard")]
		public async Task<JsonResult> GetNumberCardSavingsData()
		{
			var data = _solaxService.GetNumberCardSavingsData();
			return new JsonResult(data);

		}
		[HttpGet]
		[Route("GetStoredDataPieChart")]
		public async Task<JsonResult> GetNumberCardStatusData()
		{
			var data = _solaxService.GetNumberCardStatusData();
			return new JsonResult(data);

		}
		[HttpGet]
		[Route("GetUser")]
		public string GetUser(string username, string password)
		{
			return null;
		}


	}
}
