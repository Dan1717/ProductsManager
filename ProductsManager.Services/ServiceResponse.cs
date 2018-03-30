using System.Collections.Generic;

namespace ProductsManager.Services
{
	public class ServiceResponse<TResponse>
	{
		public ServiceResponse()
		{
			Errors = new Dictionary<string, string>();
			ResultCode = 200;
		}

		public TResponse Response { get; set; }

		public IDictionary<string, string> Errors { get; }
		public int ResultCode { get; set; }

		public bool IsValid => Errors.Count == 0;

		public void AddError(string key, string value)
		{
			ResultCode = 400;
			Errors.Add(key, value);
		}
	}

	
}
