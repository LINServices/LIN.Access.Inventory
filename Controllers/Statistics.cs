namespace LIN.Access.Inventory.Controllers;

public static class Statistics
{

    /// <summary>
    /// Obtener los inventarios asociados a una cuenta.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadOneResponse<HomeDto>> HomeStatistics(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("statistics");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<HomeDto>>();

        // Retornar.
        return Content;

    }

}