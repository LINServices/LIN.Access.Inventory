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
        Client client = Service.GetClient("outflow/create");

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
        Client client = Service.GetClient("outflow/read");

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
        Client client = Service.GetClient("outflow/read/all");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<OutflowDataModel>>();

        // Retornar.
        return Content;

    }










    public async static Task<ReadOneResponse<List<byte>>> InformeMonth(int contextUser, int id, int mes, int año)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = "outflow/info";

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("month", $"{mes}");
        request.Headers.Add("year", $"{año}");
        request.Headers.Add("contextUser", $"{contextUser}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<List<byte>>>(responseBody);

            return obj ?? new();


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }




    public async static Task<ResponseBase> Update(int id, DateTime date, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("outflow");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);
        client.AddParameter("date", date.ToString("yyyy-MM-ddTHH:mm:ss"));

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;

    }






    public async static Task<ReadAllResponse<SalesModel>> Sales(int contextUser, int days)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/sales");

        // Headers.
        client.AddHeader("id", contextUser);
        client.AddHeader("days", days);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<SalesModel>>();

        // Retornar.
        return Content;

    }



}
