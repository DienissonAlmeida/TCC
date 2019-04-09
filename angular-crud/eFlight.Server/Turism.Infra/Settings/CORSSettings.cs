using System;

namespace Turism.Infra
{
    public class CORSSettings
    {

        public string[] Origins { get; set; }
        public string[] Methods { get; set; }
        public string[] Headers { get; set; }

        public CORSSettings()
        {
        }

        public CORSSettings Default()
        {
            Origins = new string[] { "*" };
            Methods = new string[] { "*" };
            Headers = new string[] { "*" };

            return this;
        }
    }
}
