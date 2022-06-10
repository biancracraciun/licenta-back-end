using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
	public interface ISolax
	{
		Task<string> GetCloudData();
		Task<bool> PolulateCloudData();
		
		void InsertSolaxData(SolaxDto solaxDto);
		public List<Solax> GetAllDbData();

		public List<int> GetData();
		public List<ChartDisplayModelHourly> GetLineChartData();

		public List<ChartDisplayModelMonthly> GetRadarChartData();
		public List<ChartDisplayModelFeedInEnergy> GetGaugeChartData();
		public List<ChartModel> GetNumberCardTCData();
        public List<ChartModel> GetNumberCardEmisiiData();
		public List<ChartModel> GetNumberCardSavingsData();
		public List<ChartModel> GetNumberCardYTData();
		public List<ChartModel> GetNumberCardStatusData();

	}
}
