using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dotnet6App.Controllers
{
    [Route("api/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult Save([FromBody] Model req)
        {
            var whatIGot = req.Team;
            return Ok();
        }

        public class Model
        {
            public float Team { get; set; }
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var token = await GetYourBotTokenWithClientCredentialsFlow();
                var keys = await GetYourBotKeys();
                ClaimsPrincipal validateToken = await Authenticate(token);

                JsonSerializerOptions options = new()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    WriteIndented = true
                };

                string dataExtracted = System.Text.Json.JsonSerializer.Serialize(validateToken, options);
                return dataExtracted;
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }

        }

        private async Task<MicrosftPublicKeyList> GetYourBotKeys()
        {
            string tokenUrl = $"https://login.microsoftonline.com/d6d49420-f39b-4df7-a1dc-d59a935871db/discovery/keys?appid=4d7fcb19-e29f-48e0-a58d-96181c11431c";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Get, tokenUrl);

            dynamic json;
            MicrosftPublicKeyList keys;
            HttpClient client = new HttpClient();

            var tokenResponse = await client.SendAsync(tokenRequest);

            json = await tokenResponse.Content.ReadAsStringAsync();
            keys = JsonConvert.DeserializeObject<MicrosftPublicKeyList>(json);

            return keys;
        }
        private async Task<string> GetYourBotTokenWithClientCredentialsFlow()
        {
            string tokenUrl = $"https://login.microsoftonline.com/botframework.com/oauth2/v2.0/token";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);

            tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = "4d7fcb19-e29f-48e0-a58d-96181c11431c",
                ["client_secret"] = "Q4L7Q~u9Cu4fCay1h2bhUiiJ6M7I4KchF9Gv2",
                ["scope"] = "https://api.botframework.com/.default"
            });

            dynamic json;
            dynamic token;
            HttpClient client = new HttpClient();

            var tokenResponse = await client.SendAsync(tokenRequest);

            json = await tokenResponse.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<AccessTokenClass>(json);
            Console.WriteLine("Your Access Token {0}", token.access_token);
            return token.access_token;
        }
        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            //   var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var key = Encoding.ASCII.GetBytes("");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        public async Task<ClaimsPrincipal> Authenticate(string jwt)
        {
            var openIdMetadataAddress = "https://login.microsoftonline.com/botframework.com/v2.0/.well-known/openid-configuration";
            var issuer = "https://sts.windows.net/d6d49420-f39b-4df7-a1dc-d59a935871db/";
            var audience = "https://api.botframework.com";

            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                openIdMetadataAddress,
                new OpenIdConnectConfigurationRetriever());
            var openIdConnectConfiguration = await configurationManager.GetConfigurationAsync();
            var tokenValidationParameters = new TokenValidationParameters
            {
                // Updated validation parameters
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = openIdConnectConfiguration.SigningKeys
            };

            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(jwt, tokenValidationParameters, out _);
                return claimsPrincipal;
            }
            catch (SecurityTokenException e)
            {
                return null;
            }
        }
    }

    public class Key
    {
        public string kty { get; set; }
        public string use { get; set; }
        public string kid { get; set; }
        public string x5t { get; set; }
        public string n { get; set; }
        public string e { get; set; }
        public List<string> x5c { get; set; }
    }

    public class MicrosftPublicKeyList
    {
        public List<Key> keys { get; set; }
    }

}
