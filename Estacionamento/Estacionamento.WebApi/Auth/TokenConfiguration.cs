namespace Estacionamento.WebApi.Auth {
  public class TokenConfiguration {
    public TokenConfiguration () { }
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int Seconds { get; set; }
    public string SecretyKey { get; set; }
  }
}