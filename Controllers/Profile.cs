using LIN.Types.Emma.Models;

namespace LIN.Access.Inventory.Controllers;


public static class Profile
{


    /// <summary>
    /// Obtiene los datos de una cuenta especifica
    /// </summary>
    /// <param name="id">Id de la cuenta</param>
    public async static Task<ReadAllResponse<DeviceModel>> ReadDevices(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("device");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<DeviceModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene los datos de una cuenta especifica
    /// </summary>
    /// <param name="id">Id de la cuenta</param>
    public async static Task<ReadOneResponse<ProfileModel>> ReadOne(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profile");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProfileModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Búsqueda de usuarios por medio de su Id
    /// </summary>
    public async static Task<ReadAllResponse<SessionModel<ProfileModel>>> SearhByPattern(string pattern, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("profile/search");

        // Headers.
        client.AddParameter("pattern", pattern);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<SessionModel<ProfileModel>>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Preguntar a Emma.
    /// </summary>
    /// <param name="token">Preguntar a Emma.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<ResponseIAModel>> ToEmma(string modelo, string token)
    {

        // Cliente
        Client client = Service.GetClient($"emma");

        // Headers.
        client.AddHeader("tokenAuth", token);

        return await client.Post<ReadOneResponse<ResponseIAModel>>(modelo);

    }


}