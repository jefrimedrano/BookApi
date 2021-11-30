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

		#region GetAll

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

		#region GetById

		public async Task<ResultModel> GetById(int id)
		{
			try
			{
				var url = "/api/v1/Books/" + id.ToString();

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
				var data = JsonConvert.DeserializeObject<Book>(result);

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

		#region Create
		public async Task<ResultModel> Create(Book book)
		{
			try
			{
				HttpClient client = ClientRequest();

				var request = JsonConvert.SerializeObject(book);
				var content = new StringContent(request, Encoding.UTF8, "application/json");
				var url = "/api/v1/Books";
				var response = await client.PostAsync(url, content);

				if (!response.IsSuccessStatusCode)
				{
					return new ResultModel
					{
						Success = false,
						Messages = response.ReasonPhrase,
					};
				}

				var result = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<Book>(result);

				return new ResultModel
				{
					Success = true,
					Messages = response.ReasonPhrase,
					Data = data,
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

		#region UpDate
		public async Task<ResultModel> UpDate(Book book)
		{
			try
			{
				HttpClient client = ClientRequest();

				var request = JsonConvert.SerializeObject(book);
				var content = new StringContent(request, Encoding.UTF8, "application/json");
				var url = "/api/v1/Books/"+ book.id;
				var response = await client.PutAsync(url, content);

				if (!response.IsSuccessStatusCode)
				{
					return new ResultModel
					{
						Success = false,
						Messages = response.ReasonPhrase,
					};
				}

				var result = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<Book>(result);

				return new ResultModel
				{
					Success = true,
					Messages = response.ReasonPhrase,
					Data = data,
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


		public async Task<ResultModel> Delete(int Id)
		{
			try
			{
				var url = "/api/v1/Books/" + Id.ToString();

				HttpClient client = ClientRequest();
				HttpResponseMessage response = await client.DeleteAsync(url);

				if (!response.IsSuccessStatusCode)
				{
					return new ResultModel
					{
						Success = false,
						Messages = response.ReasonPhrase
					};
				}

				

				return new ResultModel
				{
					Success = true,
					Messages = response.ReasonPhrase,
					Data = null,
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


	}
}
