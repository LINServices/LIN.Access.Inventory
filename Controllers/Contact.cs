using LIN.Types.Contacts.Models;

namespace LIN.Access.Inventory.Controllers;


public static class Contact
{


    /// <summary>
    /// Crear nuevo contacto.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="modelo">Modelo.</param>
    public async static Task<CreateResponse> Create(string token, ContactModel modelo)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("contact/create");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener un contacto.
    /// </summary>
    /// <param name="id">Id del contacto.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<ContactModel>> Read(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("contact/read");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ContactModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene los contactos asociados a un perfil.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadAllResponse<ContactModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("contact/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ContactModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualiza la información de un contacto.
    /// </summary>
    /// <param name="modelo">Nuevo modelo</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(ContactModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("contact/update");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Patch<ResponseBase>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Elimina un contacto.
    /// </summary>
    /// <param name="id">Id del contacto</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {
        // Cliente HTTP.
        Client client = Service.GetClient("contact/delete");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;
    }



    

    /// <summary>
    /// Contar los contactos asociados.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<int>> Count(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("contact/count");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<int>>();

        // Retornar.
        return Content;

    }



}