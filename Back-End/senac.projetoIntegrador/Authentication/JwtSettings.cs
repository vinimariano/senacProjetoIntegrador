namespace senac.projetoIntegrador.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SenhaPadrao { get; set; }
        public double MinutesToExpiration { get; set; }
    }
}