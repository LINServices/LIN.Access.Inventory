namespace LIN.Access.Inventory.Controllers;

public static class Holds
{

    /// <summary>
    /// Obtener todas las reservas asociadas a un inventario.
    /// </summary>
    /// <param name="inventory">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadAllResponse<HoldModel>> ReadAll(int inventory, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("holds/read/all");

        // Headers.
        client.AddHeader("id", inventory);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<HoldModel>>();

        // Retornar.
        return Content;
    }


    /// <summary>
    /// Realizar la devolución de una reserva.
    /// </summary>
    /// <param name="holdGroup">Id del grupo de reserva.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ResponseBase> Return(int holdGroup, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("holds");

        // Headers.
        client.AddHeader("id", holdGroup);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;
    }

}