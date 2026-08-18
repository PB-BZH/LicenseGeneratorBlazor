using System.Text;
using System.Text.Json;
using LicenseGeneratorBlazor.Models;

namespace LicenseGeneratorBlazor.Services;

public sealed class ProfileStorageService {

  private readonly string _profilesDirectory;

  private static readonly JsonSerializerOptions JsonOptions =
      new() {
        WriteIndented = true
      };

  public ProfileStorageService(IWebHostEnvironment environment) {

    _profilesDirectory =
        Path.Combine(
            environment.ContentRootPath,
            "Data",
            "Profiles");

    Directory.CreateDirectory(_profilesDirectory);
  }

  public async Task<string> SaveAsync(
      LicenseProfile profile) {

    string fileName =
        BuildProfileFileName(profile.ProductId);

    string fullPath =
        Path.Combine(
            _profilesDirectory,
            fileName);

    string json =
        JsonSerializer.Serialize(
            profile,
            JsonOptions);

    await File.WriteAllTextAsync(
        fullPath,
        json,
        Encoding.UTF8);

    return json;
  }

  private static string BuildProfileFileName(
      string productId) {

    string name =
        string.IsNullOrWhiteSpace(productId)
            ? "LicenseProfile"
            : productId.Trim();

    foreach (char invalidChar
             in Path.GetInvalidFileNameChars()) {

      name = name.Replace(
          invalidChar,
          '_');
    }

    return $"{name}.profile.json";
  }
}