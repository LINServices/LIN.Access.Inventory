using Microsoft.Extensions.DependencyInjection;

namespace LIN.Access.Inventory;

public static class Build
{

    /// <summary>
    /// Autenticación de la aplicación.
    /// </summary>
    internal static string Application { get; set; } = string.Empty;


    /// <summary>
    /// Utilizar LIN Inventory.
    /// </summary>
    /// <param name="app">Aplicación.</param>
    /// <param name="url">Ruta.</param>
    public static IServiceCollection AddInventoryService(this IServiceCollection service, string? url = null, string? app = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "https://api.linplatform.com/Inventory/");
        Application = app ?? "default";
        return service;
    }

}