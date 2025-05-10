namespace LIN.Access.Inventory.Controllers;

public static class OpenStore
{

    /// <summary>
    /// Crear ajuste de inventario con conexión con Open Store.
    /// </summary>
    /// <param name="token">Token de acceso (Inventario).</param>
    /// <param name="mercado">Token de acceso a Mercado Pago.</param>
    /// <param name="inventory">Id del inventario.</param>
    /// <param name="user">Usuario actual.</param>
    /// <param name="password">Contraseña actual.</param>
    public static async Task<CreateResponse> Create(string token, string mercado, int inventory, string user, string password)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("OpenStoreSettings");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("mercadoToken", mercado);


        client.AddParameter("user", user);
        client.AddParameter("password", password);
        client.AddParameter("inventory", inventory);

        // Resultado.
        var Content = await client.Post<CreateResponse>();

        // Retornar.
        return Content;


    }


    /// <summary>
    /// Leer ajuste de inventario con conexión con Open Store.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="inventory">Id del inventario.</param>
    public static async Task<ReadOneResponse<OpenStoreSettings>> Read(string token, int inventory)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("OpenStoreSettings");

        // Headers.
        client.AddHeader("token", token);

        client.AddParameter("inventory", inventory);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<OpenStoreSettings>>();

        // Retornar.
        return Content;
    }


    /// <summary>
    /// Crear salida online
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<CreateResponse> CreateOnline(OutflowDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("connectors/OpenStore/hold");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;


    }

}