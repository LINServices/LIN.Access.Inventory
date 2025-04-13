namespace LIN.Access.Inventory.Controllers;

public static class OpenStore
{


    public static async Task<CreateResponse> CreateSettings(string token, string mercado, int inventory, string user, string password)
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


    public static async Task<ReadOneResponse<OpenStoreSettings>> ReadSettings(string token, int inventory)
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






    public static async Task<ReadAllResponse<Types.Payments.Models.PayModel>> Payments(string token, int inventory)
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