namespace LIN.Access.Inventory.Controllers;


public static class Inventories
{


    /// <summary>
    /// Crear inventario.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<CreateResponse> Create(InventoryDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener los inventarios asociados a una cuenta.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadAllResponse<InventoryDataModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<InventoryDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadOneResponse<InventoryDataModel>> Read(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<InventoryDataModel>>();

        // Retornar.
        return Content;


    }


    /// <summary>
    /// Obtener un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ResponseBase> Update(int id, string name, string description, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);
        client.AddParameter("name", name);
        client.AddParameter("description", description);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;


    }


}