﻿using LIN.Types.Contacts.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LIN.Access.Inventory.Controllers;


public static class Contact
{



    /// <summary>
    /// Crea un nuevo contacto
    /// </summary>
    /// <param name="modelo">Modelo del contacto</param>
    public async static Task<CreateResponse> Create(string token, ContactModel modelo)
    {

        var http = new HttpClient();
        http.DefaultRequestHeaders.Add("token", token);

        // Url del servicio /
        string url = ApiServer.PathURL("contact/create");

        // Objeto JSON
        string json = JsonSerializer.Serialize(modelo);


        // Ejecución
        try
        {

            // Contenido
            StringContent content = new(json, Encoding.UTF8, "application/json");

            // Envía la solicitud
            var response = await http.PostAsync(url, content);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            CreateResponse obj = JsonSerializer.Deserialize<CreateResponse>(responseContent) ?? new();

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }



    /// <summary>
    /// Obtiene un contacto
    /// </summary>
    /// <param name="id">ID del contacto</param>
    public async static Task<ReadOneResponse<ContactModel>> Read(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("contact/read");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("id", $"{id}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<ContactModel>>(responseBody);

            return obj ?? new();


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Obtiene los contactos asociados a una cuenta
    /// </summary>
    /// <param name="id">ID de la cuenta</param>
    public async static Task<ReadAllResponse<ContactModel>> ReadAll(string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("contact/read/all");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("token", $"{token}");

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();



            var obj = JsonSerializer.Deserialize<ReadAllResponse<ContactModel>>(responseBody);
            if (obj == null)
                return new();

            obj.Models = obj.Models.OrderBy(T => T.Nombre).ToList();

            return obj ?? new();


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }



    /// <summary>
    /// Actualiza la información de un contacto
    /// </summary>
    /// <param name="modelo">Nuevo modelo</param>
    public async static Task<ResponseBase> Update(ContactModel modelo)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("contact/update");
        string json = JsonSerializer.Serialize(modelo);


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
    /// Elimina un contacto
    /// </summary>
    /// <param name="id">ID del contacto</param>
    /// <param name="token">Token</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {
        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("contact/delete");
        client.DefaultRequestHeaders.Add("token", token);
        client.DefaultRequestHeaders.Add("id", id.ToString());

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



    /// <summary>
    /// Elimina un contacto en la papelera
    /// </summary>
    /// <param name="id">ID del contacto</param>
    /// <param name="token">Token</param>
    public async static Task<ResponseBase> ToTrash(int id, string token)
    {
        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("contact/trash");
        client.DefaultRequestHeaders.Add("token", token);
        client.DefaultRequestHeaders.Add("id", id.ToString());

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



    /// <summary>
    /// Obtiene un contacto
    /// </summary>
    /// <param name="id">ID del contacto</param>
    public async static Task<ReadOneResponse<int>> Count(string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("token", token);


        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("contact/count");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        try
        {
            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonSerializer.Deserialize<ReadOneResponse<int>>(responseBody);

            return obj ?? new();


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }


}