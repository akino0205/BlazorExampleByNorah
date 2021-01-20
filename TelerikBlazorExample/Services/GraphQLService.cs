using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TelerikBlazorExample.Data;
using TelerikBlazorExample.Models;

namespace TelerikBlazorExample.Services
{
    public class GraphQLService
    {
        public WebApiAddress _webApiAddress { get; }
        public string[] patnArr { get; set; }

        public GraphQLService(IOptions<WebApiAddress> webApiAddress)
        {
            _webApiAddress = webApiAddress.Value;
            SetPatnArr();
        }

        public async Task<List<FullTextMainModel.Fulltext_main>> GetFullTextListAsync(bool getOne)
        {
            List<FullTextMainModel.Fulltext_main> fullTextList = new List<FullTextMainModel.Fulltext_main>();
            if (getOne)
            {
                FullTextMainModel.Fulltext_main model = await GetFullTextModel(50);
                fullTextList.Add(model);
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    FullTextMainModel.Fulltext_main model = await GetFullTextModel(i);
                    model.idx = i + 1;
                    fullTextList.Add(model);
                }
            }            
            return fullTextList;
        }

        public async Task<FullTextMainModel.Fulltext_main> GetFullTextModel(int idx = 0)
        {
            GraphQLResponse<FullTextMainModel> graphQLResponse = null;
            try
            {
                var graphQLClient = new GraphQLHttpClient(_webApiAddress.GraphQLTester, new NewtonsoftJsonSerializer());
                graphQLResponse = await graphQLClient.SendQueryAsync<FullTextMainModel>(GetQuery(idx));
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return graphQLResponse.Data.fulltext_main;

            /* HttpClient로 했을 경우 */
            //var response = await _httpClient.GetAsync(string.Format("?query={0}", GetQuery(idx)));
            //FullTextMainModel model = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonString = await response.Content.ReadAsStringAsync();
            //    JObject jobj = JObject.Parse(jsonString);
            //    var data = jobj["data"]["fulltext_main"];
            //    try
            //    {
            //        model = JsonConvert.DeserializeObject<FullTextMainModel>(data.ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.Error.WriteLine(ex.Message);
            //    }
            //}
            //return model;
        }

        private GraphQLRequest GetQuery(int idx = 50)
        {

            GraphQLRequest query = null;
            if(idx < 50)
            {
                query = new GraphQLRequest
                {
                    Query = @"
query ($patn: String!){
    fulltext_main(patn: $patn) {
        patentNumber 
        applicationDate 
        collection
        title
    }
}",
                    Variables = new
                    {
                        patn = patnArr[idx]
                    }
                };
            }
            else
            {
                query = new GraphQLRequest
                {
                    Query = @"
query {
    fulltext_main(patn: ""US03930271A1"") {
        patentNumber 
        applicationDate 
        collection
        title
    }
}",
                };
            }
            
            return query;
        }

        private void SetPatnArr()
        {
            patnArr = new string[] {
                "US03930271A1",
"US03930272A1",
"US03930273A1",
"US03930274A1",
"US03930275A1",
"US03930276A1",
"US03930277A1",
"US03930278A1",
"US03930279A1",
"US03930280A1",
"US03930281A1",
"US03930282A1",
"US03930283A1",
"US03930284A1",
"US03930285A1",
"US03930286A1",
"US03930287A1",
"US03930288A1",
"US03930289A1",
"US03930290A1",
"US03930291A1",
"US03930292A1",
"US03930293A1",
"US03930294A1",
"US03930295A1",
"US03930296A1",
"US03930297A1",
"US03930298A1",
"US03930299A1",
"US03930300A1",
"US03930301A1",
"US03930302A1",
"US03930303A1",
"US03930304A1",
"US03930305A1",
"US03930306A1",
"US03930307A1",
"US03930308A1",
"US03930309A1",
"US03930310A1",
"US03930311A1",
"US03930312A1",
"US03930313A1",
"US03930314A1",
"US03930315A1",
"US03930316A1",
"US03930317A1",
"US03930318A1",
"US03930319A1",
"US03930320A1"};
        }
    }

}
