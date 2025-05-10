namespace LIN.Access.Inventory.Controllers;

public class Payments
{

    /// <summary>
    /// Obtener los pagos asociados a un inventario.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="inventory">Id del inventario.</param>
    public static async Task<ReadAllResponse<Types.Payments.Models.PayModel>> ReadAll(string token, int inventory)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("OpenStoreSettings/payments");

        // Headers.
        client.AddHeader("token", token);

        client.AddParameter("inventory", inventory);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<Types.Payments.Models.PayModel>>();

        // Retornar.
        return Content;
    }

}