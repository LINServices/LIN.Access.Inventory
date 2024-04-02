﻿namespace LIN.Access.Inventory.Controllers;


public static class Inflows
{


    /// <summary>
    /// Crear un movimiento de entrada.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(InflowDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inflow/create");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene una entrada y sus detalles por medio del Id.
    /// </summary>
    /// <param name="id">Id de la entrada.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<InflowDataModel>> Read(int id, string token, bool details = false)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inflow/read");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);
        client.AddHeader("includeDetails", details.ToString());

        // Resultado.
        var Content = await client.Get<ReadOneResponse<InflowDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene la lista de entradas asociadas a un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadAllResponse<InflowDataModel>> ReadAll(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inflow/read/all");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<InflowDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualizar.
    /// </summary>
    /// <param name="id">Id de la entrada.</param>
    /// <param name="date">Nueva fecha.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(int id, DateTime date, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inflow");

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