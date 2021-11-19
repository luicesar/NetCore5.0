using System.Linq;
using System.Security.Claims;
using Estacionamento.Repository.Models;
using Newtonsoft.Json;

namespace Estacionamento.WebApi.Auth {
  public class AuthIdenty {
    public static UsuarioLogadoModel UsuarioLogado (ClaimsPrincipal identity) {
      var user = JsonConvert.DeserializeObject<UsuarioLogadoModel> (identity.Claims.Where (x => x.Type == "userInfo").FirstOrDefault ().Value);
      return user;
    }
  }
}