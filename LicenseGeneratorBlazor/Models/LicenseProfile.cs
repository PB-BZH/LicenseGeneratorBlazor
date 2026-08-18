namespace LicenseGeneratorBlazor.Models;

public sealed class LicenseProfile {
  public string ProductId { get; set; } = "";
  public string LicenseId { get; set; } = "";
  public string CustomerName { get; set; } = "";
  public string Site { get; set; } = "";
  public string EmailContact { get; set; } = "";
  public string MachineHash { get; set; } = "";
  public DateTime ValidUntil { get; set; }
  public bool ValidUnlimited { get; set; }
  public DateTime MaintenanceUntil { get; set; }
  public bool MaintenanceUnlimited { get; set; }
}