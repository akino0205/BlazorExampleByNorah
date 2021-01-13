using BlazorExampleByNorah.Data;
using BlazorExampleByNorah.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Services
{
    //https://www.data.go.kr/data/15000415/openapi.do
    public class WeatherService
    {
        public AppSettings _appSettings { get; }
        public HttpClient _httpClient { get; }

        public WeatherService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_appSettings.WeatherAPIAddress);
        }

        //기상특보목록조회
        public async Task<string> GetWthrWrnListStr(WeatherInfoParam Input)
        {
            string addressAndParam =
                string.Format("{0}/getWthrWrnList?serviceKey={1}&pageNo={2}&numOfRows={3}&dataType={4}&stnId={5}&fromTmFc={6}&toTmFc={7}",
                                _appSettings.WeatherAPIAddress,
                                Input.ServiceKey, 
                                Input.PageNo.ToString(), 
                                Input.NumOfRows.ToString(), 
                                Input.DataType,
                                Input.StnId.ToString(), 
                                Input.FromTmFc.ToString("yyyyMMdd"),
                                Input.ToTmFc.ToString("yyyyMMdd"));

            var response = await _httpClient.GetAsync(addressAndParam);
            string result = null;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                //result = await response.Content.ReadAsStringAsync<WeatherInfoResult>();
                //result = JsonConvert.DeserializeObject<GroupItem>(response.Result);
            }
            return result;
        }
    }
}
