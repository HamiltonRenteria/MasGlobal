using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Test.Web.Models.Entity;

namespace Test.Web.Models
{
    public class DBApi
    {

        public static dynamic GetEmployees(string url, string json, string authorization = null)
        {
            try
            {
                #region Consumming Rest API
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json");
                if (json != "")
                {
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                }

                if (authorization != null)
                {
                    request.AddHeader("Authorization", authorization);
                }

                IRestResponse response = client.Execute(request);

                dynamic dataEmployees = JsonConvert.DeserializeObject<List<EmployeeEntity>>(response.Content);

                return dataEmployees;
                #endregion
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
    }
}