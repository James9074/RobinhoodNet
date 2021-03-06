using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BasicallyMe.RobinhoodNet.Raw
{
    public partial class RawRobinhoodClient
    {
        public Task<JToken>
        DownloadOrders(string cursor = null)
        {
            string url = cursor ?? ORDERS_URL;
            return doGet(url);
        }

        public async Task
        CancelOrder(string orderCancelUrl)
        {
            var r = await doPost_NativeResponse(orderCancelUrl);
            r.EnsureSuccessStatusCode();
        }

        public Task<JToken>
        PlaceOrder(IDictionary<string, string> newOrderSingle)
        {
            return doPost(ORDERS_URL, newOrderSingle);
        }
    }
}
