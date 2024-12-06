namespace LIN.Access.Inventory.Controllers;

public class Authentication
{

    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="cuenta">Cuenta.</param>
    /// <param name="password">Contraseña.</param>
    public static async Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string cuenta, string password)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("Authentication/credentials");

        // TimeOut.
        client.TimeOut = 20;

        // Headers.
        client.AddParameter("user", cuenta);
        client.AddParameter("password", password);

        var content = await client.Get<ReadOneResponse<AuthModel<ProfileModel>>>();

        // Retornar.
        return content;

    }


    /// <summary>
    /// Obtener una sesión por medio del token.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public static async Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("Authentication/token");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<AuthModel<ProfileModel>>>();

        // Retornar.
        return Content;

    }

}