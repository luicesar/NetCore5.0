namespace Estacionamento.Domain.EntitiesViews {
  public class ManobristaSlimViewModel {
    public int ID { get; set; }
    public int PessoaId { get; set; }
    public string PessoaNome { get; set; }
    public int CarroId { get; set; }
    public string MarcaNome { get; set; }
    public string ModeloNome { get; set; }
  }
}