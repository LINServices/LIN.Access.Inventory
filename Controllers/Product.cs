﻿using LIN.Access.Inventory;

namespace LIN.Access.Inventory.Controllers;


public static class Product
{


    /// <summary>
    /// Crea un nuevo producto
    /// </summary>
    /// <param name="modelo">Modelo</param>
    public async static Task<CreateResponse> Create(ProductDataTransfer modelo, string token)
    {

        // Variables
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("token", $"{token}");

        string url = ApiServer.PathURL("product/create");
        string json = JsonSerializer.Serialize(modelo);

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<CreateResponse>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Obtiene la lista de productos asociados a un inventario
    /// </summary>
    /// <param name="id">ID del inventario</param>
    public async static Task<ReadAllResponse<ProductDataTransfer>> ReadAll(int id, string token)
    {

        // Crear HttpClient
        var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("product/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");
        request.Headers.Add("token", $"{token}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadAllResponse<ProductDataTransfer>>(responseBody);

            if (obj == null)
                return new();

            obj.Models = obj.Models.OrderBy(T => T.Name).ToList();

            return obj ?? new();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {ex.Message}");
        }


        return new();
    }



    /// <summary>
    /// Obtiene la lista de plantillas de productos
    /// </summary>
    /// <param name="template">Parámetro de búsqueda</param>
    public async static Task<ReadAllResponse<ProductDataTransfer>> ReadTemplates(string template)
    {

        // Crear HttpClient
        var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("product/read/all/templates");

        url = Web.AddParameters(url, new()
        {
            { "template", template }
        });

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);




        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadAllResponse<ProductDataTransfer>>(responseBody);

            if (obj == null)
                return new();

            obj.Models = obj.Models.OrderBy(T => T.Name).ToList();

            return obj ?? new();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {ex.Message}");
        }


        return new();
    }



    /// <summary>
    /// Obtiene un producto por medio del ID
    /// </summary>
    /// <param name="id">ID del producto</param>
    public async static Task<ReadOneResponse<ProductDataTransfer>> Read(int id)
    {

        // Crear HttpClient
        var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("product/read");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<ProductDataTransfer>>(responseBody);

            if (obj == null)
                return new();

            return obj ?? new();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {ex.Message}");
        }


        return new();
    }




    /// <summary>
    /// Obtiene un producto por medio del ID de detalle de producto
    /// </summary>
    /// <param name="id">ID del detalle</param>
    public async static Task<ReadOneResponse<ProductDataTransfer>> ReadOneByDetail(int id)
    {

        // Crear HttpClient
        var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("product/readbydetail");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<ProductDataTransfer>>(responseBody);

            if (obj == null)
                return new();

            return obj ?? new();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {ex.Message}");
        }


        return new();
    }



    /// <summary>
    /// Actualiza la informacion de un producto
    /// </summary>
    public async static Task<ResponseBase> UpdateAsync(ProductDataTransfer modelo, bool isBase)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("product/update");
        string json = JsonSerializer.Serialize(modelo);

        client.DefaultRequestHeaders.Add("isBase", $"{isBase}");

        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
            HttpResponseMessage response = await client.PatchAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Actualiza la informacion de un producto
    /// </summary>
    public async static Task<ResponseBase> Update(ProductDataTransfer modelo)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("product/update");
        string json = JsonSerializer.Serialize(modelo);


        try
        {
            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
            HttpResponseMessage response = await client.PutAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }






    public async static Task<ResponseBase> Delete(int id)
    {

        // Variables
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("id", $"{id}");

        string url = ApiServer.PathURL("product/delete");


        try
        {
            // Envía la solicitud
            HttpResponseMessage response = await client.DeleteAsync(url);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<ResponseBase>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



}
