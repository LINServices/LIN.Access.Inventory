namespace LIN.Access.Inventory;


public sealed class Session
{


    public string Token { get; set; }
    public string ContactsToken { get; set; }


    /// <summary>
    /// Información del usuario
    /// </summary>
    public ProfileModel Informacion { get; private set; } = new();


    /// <summary>
    /// Información del usuario
    /// </summary>
    public LIN.Types.Auth.Models.AccountModel Account { get; private set; } = new();


    public string AccountToken { get; set; }



    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsAccountOpen { get => Instance.Account.ID > 0; }



    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsLocalOpen { get => Instance.Informacion.ID > 0; }




    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string user, string password)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Controllers.Profile.Login(user, password);

        if (response.Response != Responses.Success)
            return (null, response.Response);


        // Datos de la instancia
        Instance.Informacion = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];
        Instance.ContactsToken = response.Model.TokenCollection["contacts"];

        return (Instance, Responses.Success);

    }



    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string token)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Controllers.Profile.Login(token);


        if (response.Response != Responses.Success)
            return (null, response.Response);


        // Datos de la instancia
        Instance.Informacion = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];
        Instance.ContactsToken = response.Model.TokenCollection["contacts"];

        return (Instance, Responses.Success);

    }






    /// <summary>
    /// Cierra la sesión
    /// </summary>
    public static void CloseSession()
    {
        Instance.Informacion = new();
        Instance.Account = new();
    }






    //==================== Singleton ====================//


    private readonly static Session _instance = new();

    private Session()
    {
        Informacion = new();
    }


    public static Session Instance => _instance;
}
