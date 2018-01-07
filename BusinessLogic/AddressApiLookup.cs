using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BusinessLogic
{
    public class AddressApiLookup
    {
	    private const string Url = "http://myurl.com";

	    public AddressPoco Get(int personId)
	    {
		    using (var webClient = new WebClient())
		    {
			    webClient.Headers["Accept-Encoding"] = "UTF-8";
			    webClient.Headers["Content-Type"] = "application/json";

			    var arr = webClient.DownloadData(new Uri($"{Url}/api/GetAddress/{personId}"));
			    return JsonConvert.DeserializeObject<AddressPoco>(Encoding.ASCII.GetString(arr));
		    }
	    }
    }
}
