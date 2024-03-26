namespace LIN.Access.Inventory.Controllers;


public static class Inventories
{


    /// <summary>
    /// Crear inventario.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(InventoryDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/create");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene los inventarios que están asociados a una cuenta
    /// </summary>
    /// <param name="id">Id de la cuenta</param>
    public async static Task<ReadAllResponse<InventoryDataModel>> ReadAll(string token)
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
    /// Cambia el estado de un usuario en un inventario
    /// </summary>
    /// <param name="id">Id del usuario</param>
    /// <param name="estado">Nuevo estado</param>
    public async static Task<ResponseBase> UpdateState(int id, InventoryAccessState estado)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/update/state");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("estado", (int)estado);

        // Resultado.
        var Content = await client.Put<ResponseBase>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualiza el rol de un usuario en un inventario
    /// </summary>
    /// <param name="id">Id del inventario</param>
    /// <param name="rol">Nuevo rol</param>
    /// <param name="token">Token de acceso</param>
    public async static Task<ResponseBase> UpdateRol(int id, InventoryRoles rol, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/update/rol");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("newRol", (int)rol);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene las invitaciones de un usuario.
    /// /// </summary>
    public async static Task<ReadAllResponse<Notificacion>> ReadNotifications(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<Notificacion>>();

        // Retornar.
        return Content;

    }




    /// <summary>
    /// Obtiene los inregrantes de un inventario
    /// </summary>
    /// <param name="inv">Id del inventario</param>
    /// <param name="user">Id del usuario que esta consultando</param>
    public async static Task<ReadAllResponse<IntegrantDataModel>> GetIntegrants(int inv, string tokenLocal, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/members");

        // Headers.
        client.AddHeader("token", tokenLocal);
        client.AddHeader("tokenAuth", token);
        client.AddHeader("inventario", inv);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<IntegrantDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Elimina a alguien de el inventario
    /// </summary>
    /// <param name="inv">Id del inventario</param>
    /// <param name="user">Id del usuario que va a ser eliminado</param>
    /// <param name="inv">Id del usuario que va a realizar la accion</param>
    public async static Task<ResponseBase> DeleteSomeOne(int inv, int user, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/delete/one");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("inventario", inv);
        client.AddHeader("usuario", user);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }


}
