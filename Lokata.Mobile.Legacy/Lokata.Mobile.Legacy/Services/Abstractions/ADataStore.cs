using System.Net.Http;

namespace Lokata.Mobile.Legacy.Services.Abstractions
{
    public abstract class ADataStore
    {
        protected Webapi webapi;

        public ADataStore()
        {
            webapi = new Webapi("http://192.168.193.3:5090/", new HttpClient());
        }
    }
}
