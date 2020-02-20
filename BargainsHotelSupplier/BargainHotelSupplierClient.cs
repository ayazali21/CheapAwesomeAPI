using BargainHotelSupplier.Models.BargainSupplierModel.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace BargainHotelSupplier
{
    public class BargainHotelSupplierClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL;
        private readonly string _key;
        private readonly ILogger _logger;
        public BargainHotelSupplierClient(string baseUrl, string key, ILogger _logger)
        {
            _httpClient = new HttpClient();
            _baseURL = baseUrl;
            _key = key;
            this._logger = _logger;
        }

        public async Task<List<FindBargainsApiResponse>> findBargain(int destId, int noOfNights)
        {
            var response = await _httpClient.GetAsync($"{_baseURL}/findBargain?destinationId={destId}&nights={noOfNights}&code={_key}");
            var timer = new Stopwatch();
            timer.Start();
            var res =await response.Content.ReadAsStringAsync();
           
            var apiRespnseModel = JsonConvert.DeserializeObject<List<FindBargainsApiResponse>>(res);
            timer.Stop();
            _logger.LogInformation($"{_baseURL}/findBargain?destinationId={destId}&nights={noOfNights}-> took {timer.ElapsedMilliseconds} mili seconds");
            return apiRespnseModel;
        }

    }
}
