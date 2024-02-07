using System.Net.Http;

namespace Lokata.Mobile.Legacy.Services.Abstractions
{
    public abstract class ADataStore
    {
        protected swaggerClient webapi;

        public ADataStore()
        {
            webapi = new swaggerClient("http://192.168.193.3:5090/", new HttpClient());
            //webapi = new swaggerClient("https://localhost:7233/", new HttpClient());
        }
    }
}
