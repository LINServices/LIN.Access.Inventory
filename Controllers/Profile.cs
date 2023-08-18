namespace LIN.Access.Inventory.Controllers;


public static class Profile
{


    /// <summary>
    /// Obtiene los datos de una cuenta especifica
    /// </summary>
    /// <param name="id">ID de la cuenta</param>
    public async static Task<ReadOneResponse<ProfileModel>> ReadOne(int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("user/read/id");

        url = Web.AddParameters(url, new(){
            {"id",id.ToString() }
        });

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);



        try
        {

            // Hacer la solicitud GET
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();


            var obj = JsonConvert.DeserializeObject<ReadOneResponse<ProfileModel>>(responseBody);

            return obj ?? new();


        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();
    }




    /// <summary>
    /// Inicia una sesión
    /// </summary>
    public async static Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string cuenta, string password)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/login");

        url = Web.AddParameters(url, new()
        {
            {"user",cuenta },
            {"password",password }
        });


        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.GetAsync(url);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<AuthModel<ProfileModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }




    /// <summary>
    /// Inicia una sesión por medio de un token
    /// </summary>
    public async static Task<ReadOneResponse<AuthModel<ProfileModel>>> Login(string token)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("profile/LoginWithToken");


        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("token", $"{token}");

        try
        {

            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<AuthModel<ProfileModel>>>(responseBody);

            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }

















    /// <summary>
    /// Obtiene la cantidad de las ventas en un plazo determinado
    /// </summary>
    /// <param name="user">ID del usuario</param>
    /// <param name="days">Dias atras</param>
    public async static Task<ReadOneResponse<HomeDto>> TotalSales(int user, int days)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("Inventory/home");

        client.DefaultRequestHeaders.Add("id", $"{user}");
        client.DefaultRequestHeaders.Add("days", $"{days}");

        try
        {
            // Envía la solicitud
            HttpResponseMessage response = await client.GetAsync(url);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<HomeDto>>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }




    /// <summary>
    /// Obtiene la valuacion de los inventarios donde un usuario es admin
    /// </summary>
    public async static Task<ReadOneResponse<decimal>> ValueInventorys(int user)
    {

        // Variables
        var client = new HttpClient();

        string url = ApiServer.PathURL("Inventory/valuation");

        client.DefaultRequestHeaders.Add("id", $"{user}");

        try
        {
            // Envía la solicitud
            HttpResponseMessage response = await client.GetAsync(url);

            // Lee la respuesta del servidor
            string responseContent = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadOneResponse<decimal>>(responseContent);

            return obj ?? new();

        }
        catch
        {
        }

        return new();

    }






    /// <summary>
    /// Busqueda de usuarios por medio de su ID
    /// </summary>
    public async static Task<ReadAllResponse<SessionModel<ProfileModel>>> SearhByPattern(string pattern, int id)
    {

        // Crear HttpClient
        using var httpClient = new HttpClient();

        // ApiServer de la solicitud GET
        string url = ApiServer.PathURL("user/searchByPattern");

        // Crear HttpRequestMessage y agregar el encabezado
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("pattern", $"{pattern}");
        request.Headers.Add("id", $"{id}");

        try
        {
            // Hacer la solicitud GET
            var response = await httpClient.SendAsync(request);

            // Leer la respuesta como una cadena
            string responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<ReadAllResponse<SessionModel<ProfileModel>>>(responseBody) ?? new();


            return obj ?? new();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer la solicitud GET: {e.Message}");
        }


        return new();





    }








}
