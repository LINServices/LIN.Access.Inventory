﻿namespace LIN.Access.Inventory.Controllers;


public class Authentication
{


    /// <summary>
    /// Iniciar sesión.
    /// </summary>
    /// <param name="cuenta">Cuenta.</param>
    /// <param name="password">Contraseña.</param>
    public async static Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string cuenta, string password)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("auth/credentials");

        // Headers.
        client.AddParameter("user", cuenta);
        client.AddParameter("password", password);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<AuthModel<ProfileModel>>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener una sesión por medio del token.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("auth/token");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<AuthModel<ProfileModel>>>();

        // Retornar.
        return Content;

    }



}