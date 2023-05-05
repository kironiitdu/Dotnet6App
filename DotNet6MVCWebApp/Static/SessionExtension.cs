using Newtonsoft.Json;

namespace DotNet6MVCWebApp.Static
{
    public static class SessionExtension
    {
        //setting session
        public static void SetComplexObjectSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //getting session
        public static T? GetComplexObjectSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
