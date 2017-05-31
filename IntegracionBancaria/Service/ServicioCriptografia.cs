using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria.Service
{
    public class ServicioCriptografia
    {
        private readonly ILogger _logger;

        private readonly static string _salt = "#Ffkj#f5454!!";

        public ServicioCriptografia(ILogger<ServicioCriptografia> logger)
        {   
            _logger = logger;
        }

        public string CodificarASha256(string texto)
        {
            var hash = "";
            using (var algorithm = SHA256.Create())
            {
                // Create the at_hash using the access token returned by CreateAccessTokenAsync.
                var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(texto + _salt));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower(); 
            }

            return hash;
        }
    }
}