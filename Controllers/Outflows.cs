namespace LIN.Access.Inventory.Controllers;


public static class Outflows
{


    /// <summary>
    /// Crear salida.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(OutflowDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("outflow");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;


    }



    /// <summary>
    /// Obtener una salida del inventario.
    /// </summary>
    /// <param name="id">Id de la salida.</param>
    /// <param name="token">Token de acceso.</param>
    /// <param name="details">Incluir los detalles.</param>
    public async static Task<ReadOneResponse<OutflowDataModel>> Read(int id, string token, bool details = false)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("outflow");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);
        client.AddHeader("includeDetails", details.ToString());

        // Resultado.
        var Content = await client.Get<ReadOneResponse<OutflowDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener las salidas asociadas a un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadAllResponse<OutflowDataModel>> ReadAll(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("outflow/all");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<OutflowDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualizar una salida.
    /// </summary>
    /// <param name="id">Id de la salida.</param>
    /// <param name="date">Nueva fecha.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(int id, DateTime date, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("outflow");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Parámetros.
        client.AddParameter("date", date);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;

    }


}
