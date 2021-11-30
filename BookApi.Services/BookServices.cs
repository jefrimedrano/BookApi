using BookApi.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class BookServices
    {
		#region CLIENTE HTTP

		private HttpClient ClientRequest()
		{
			HttpClient client = new HttpClient();

			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			client.BaseAddress = new Uri("https://fakerestapi.azurewebsites.net/api/");

			return client;
		}

		#endregion

		#region GET

		public async Task<ResultModel> GetAll()
		{
			try
			{
				var url = "/api/v1/Books";

				HttpClient client = ClientRequest();
				HttpResponseMessage response = await client.GetAsync(url);

				if (!response.IsSuccessStatusCode)
				{
					return new ResultModel
					{
						Success = false,
						Messages = response.StatusCode.ToString(),
					};
				}

				var result = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<List<Book>>(result);

				return new ResultModel
				{
					Success = true,
					Messages = "OK",
					Data = data
				};
			}
			catch (Exception ex)
			{
				return new ResultModel
				{
					Success = false,
					Messages = ex.Message,
				};
			}
		}

		

		#endregion
	}
}
