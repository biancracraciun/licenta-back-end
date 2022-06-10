using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
	public class SolaxService : ISolax
	{
		private readonly SolaxRepository solaxRepository = new SolaxRepository();
		public async Task<string> GetCloudData()
		{
			HttpClient client = new HttpClient();
			var request = new HttpRequestMessage
			  {
				  Method = HttpMethod.Get,
				  RequestUri = new Uri("https://www.eu.solaxcloud.com:9443/proxy/api/getRealtimeInfo.do?tokenId=202110011819363389873111&sn=SWWHG9UQPG")
			  };

			var response = await client.SendAsync(request).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return responseBody;
		}

		public async Task<bool> PolulateCloudData()
		{
			while (true)
			{

				HttpClient client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://www.eu.solaxcloud.com:9443/proxy/api/getRealtimeInfo.do?tokenId=202110011819363389873111&sn=SWWHG9UQPG")
				};

				var response = await client.SendAsync(request).ConfigureAwait(false);
				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				SolaxDto solaxdata = JsonConvert.DeserializeObject<SolaxDto>(responseBody);

				InsertSolaxData(solaxdata);

				new Task(() => { }).Wait(60000);
			}


			return true; 
		}

		public void InsertSolaxData(SolaxDto solaxDto)
		 {
			Solax newSolax = new Solax()
			{
				InverterSn = solaxDto.result.InverterSn,
				AcPower = solaxDto.result.AcPower,
				YieldToday = solaxDto.result.YieldToday,
				YieldTotal = solaxDto.result.YieldTotal,
				FeedInPower = solaxDto.result.FeedInPower,
				FeedInEnergy = solaxDto.result.FeedInPower,
				ConsumeEnergy = solaxDto.result.ConsumeEnergy,
				InverterType = solaxDto.result.InverterType,
				InverterStatus = solaxDto.result.InverterStatus,
				UploadTime = solaxDto.result.UploadTime,
				PowerDc1 = solaxDto.result.PowerDc1,
				PowerDc2 = solaxDto.result.PowerDc2
			};

			solaxRepository.Add(newSolax);

			return;
		}

		public List<Solax> GetAllDbData()
		{
			return solaxRepository.GetAll();
		}

        public List<int> GetData()
        {
          
			return solaxRepository.GetAllData();
		}
	

		public List<ChartDisplayModelHourly> GetLineChartData()
		{
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderBy(o => o.UploadTime);
			var data = alldata.Select(s => s.FeedInPower).ToArray();
			var labels = alldata.Select(s => s.UploadTime.Value.Hour.ToString()).Distinct();

			var seriesList = alldata.Select(s => new Series() { name = s.UploadTime.Value.Hour.ToString(), value = s.FeedInEnergy }).ToList();
			var result = new ChartDisplayModelHourly() { name = "Energie Livrata",  series = seriesList};

			return new List<ChartDisplayModelHourly> { result };
		
		}

        public List<ChartDisplayModelMonthly> GetRadarChartData()
        {
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Month == DateTime.Now.Month).OrderBy(o => o.UploadTime);
			//var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderBy(o => o.UploadTime);
			//var data = alldata.Select(s => s.FeedInPower).ToArray();
			var data = alldata.Select(s => s.YieldToday).ToArray();
			var labels = alldata.Select(s => s.UploadTime.Value.Day.ToString()).Distinct();
			var seriesList = alldata.Select(s => new ChartDisplayModelMonthly() { name = s.UploadTime.Value.Day.ToString(), value = s.YieldToday }).ToList();
			//var seriesList = alldata.Select(s => new ChartDisplayModelMonthly() { name = s.UploadTime.Value.Hour.ToString(), value = s.YieldToday }).ToList();
			//var result = alldata.Select(s => new ChartDisplayModelMonthly() { name = s.UploadTime.Value.Month.ToString(), value = s.FeedInEnergy });

			//return new List<ChartDisplayModelMonthly> { result };
			return seriesList;

		}
	

		public List<ChartDisplayModelFeedInEnergy> GetGaugeChartData()
        {   
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderByDescending(o => o.UploadTime);
			var data = alldata.Select(s => s.FeedInPower).FirstOrDefault();
            var result = new ChartDisplayModelFeedInEnergy() { name = "Energie Livrata", value = (float)data }; 

			return new List<ChartDisplayModelFeedInEnergy> { result };

		}
		public List<ChartModel> GetNumberCardTCData()
		{

			String[] names = new String[] { "Consume energy", "Yield today" };
			float[] values = new float[3];
			var seriesList= new ChartModel();
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderByDescending(o => o.UploadTime);
			var data = alldata.Select(s => s.ConsumeEnergy).FirstOrDefault();
			values[0] = (float)data;
			var data1 = alldata.Select(s => s.YieldToday).FirstOrDefault();
			values[1] = (float)data1;
	
			var nameList = names.Select(s => new ChartModel() { name = s }).ToList();

			var result = new ChartModel() { name = "Consume energy", value = (float)data };
			return new List<ChartModel> { result };
		}
		public List<ChartModel> GetNumberCardYTData()
		{


			var seriesList = new ChartModel();
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Month == DateTime.Now.Month).OrderByDescending(o => o.UploadTime);

			var data = alldata.Select(s => s.YieldToday).FirstOrDefault();
			var result = new ChartModel() { name = "Yield today", value = (float)data };
			return new List<ChartModel> { result };

		}
		public List<ChartModel> GetNumberCardEmisiiData()
		{
		  const double indiceCO2 = 0.997;
		    var seriesList = new ChartModel();
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderByDescending(o => o.UploadTime);

			var data = alldata.Select(s => s.YieldTotal).FirstOrDefault();
			var total = data* indiceCO2;
			var result = new ChartModel() { name = "Reducere emisii carbon", value = (float)total/1000 };
			return new List<ChartModel> { result };

		}
		public List<ChartModel> GetNumberCardSavingsData()
		{
			const double indicePlata = 0.71;
			var seriesList = new ChartModel();
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderByDescending(o => o.UploadTime);

			var data = alldata.Select(s => s.YieldTotal).FirstOrDefault();
			var result = new ChartModel() { name = "Savings", value = (float)(data*indicePlata)};
			return new List<ChartModel> { result };

		}
		public List<ChartModel> GetNumberCardStatusData()
		{
			var seriesList = new ChartModel();
			var alldata = solaxRepository.GetAll().Where(d => d.UploadTime.Value.Date == DateTime.Now.Date).OrderByDescending(o => o.UploadTime);
			 string  status= null;
			var data = alldata.Select(s => s.InverterStatus).FirstOrDefault();
			 switch(data)
            {
				case 102: status = "Status invertor activ";
					      break;
				case 101:
					status = "Status invertor inactiv";
					break;
				case 105:
					status = "Status invertor defect";
					break;
			}
			var result = new ChartModel() { name = status, value = (float)data };
			return new List<ChartModel> { result };

		}

    }
}
