namespace Keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }

  }
  public class VaultKeepViewModel : Vault
  {
    public int VaultKeepId { get; set; }

  }
}
