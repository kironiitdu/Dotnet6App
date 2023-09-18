namespace BlazorServerApp.ExtensionMethod
{
    public interface IAppManager
    {
        public string ReadCookie(string key);
        public void WriteCookie(string key, string value, int? daysToPersist = null);
        public void DeleteCookie(string key);
    }
}
