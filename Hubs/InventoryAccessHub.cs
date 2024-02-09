namespace LIN.Access.Inventory.Hubs;


public class InventoryAccessHub
{


    /// <summary>
    /// Conexión del HUB
    /// </summary>
    private protected HubConnection? HubConnection { get; set; }



    /// <summary>
    /// Evento ON
    /// </summary>
    public event EventHandler<CommandModel>? On;






    public void Dispose()
    {
        _ = HubConnection?.DisposeAsync();
    }




    /// <summary>
    /// Envía el evento
    /// </summary>
    /// <param name="contenido"></param>
    private protected void SendEvent(CommandModel cm)
    {
        On?.Invoke(null, cm);
    }



    /// <summary>
    /// Id del inventario
    /// </summary>
    public int Inventario { get; set; }


    public string Token { get; set; }
    public DeviceModel Device { get; set; }


    /// <summary>
    /// Nuevo HUB de productos
    /// </summary>
    /// <param name="inventario">Id del inventario</param>
    public InventoryAccessHub(string token, int inventario, DeviceModel device)
    {
        this.Token = token;
        Inventario = inventario;
        Device = device;
        Suscribe();
    }



    /// <summary>
    /// Suscribe
    /// </summary>
    private async void Suscribe()
    {
        try
        {
            // Crea la conexion al HUB
            HubConnection = new HubConnectionBuilder()
                 .WithUrl(Service.PathURL("realtime/inventory"))
                 .WithAutomaticReconnect()
                 .Build();

            // Evento cuando algo cambie
            HubConnection.On<CommandModel>("#command", (i) => SendEvent(i));

            // Inicia la conexion
            await HubConnection.StartAsync();

            // Suscribe al grupo
            await HubConnection.InvokeAsync("Join", Token, Device);
        }
        catch
        {

        }

    }






    public async void SendCommand(CommandModel command)
    {
        try
        {
            await HubConnection!.InvokeAsync("SendCommand", command);
        }
        catch
        {

        }

    }


    public async void SendToDevice(string device, CommandModel command)
    {
        try
        {
            await HubConnection!.InvokeAsync("SendToDevice", device, command);
        }
        catch
        {

        }

    }






}
