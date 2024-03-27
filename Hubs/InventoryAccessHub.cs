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
            // Crea la conexión al HUB
            HubConnection = new HubConnectionBuilder()
                 .WithUrl(Service._Service.PathURL("Realtime/inventory"))
                 .WithAutomaticReconnect()
                 .Build();

            // Evento cuando algo cambie
            HubConnection.On<CommandModel>("#command", SendEvent);

            // Inicia la conexión.
            await HubConnection.StartAsync();

            // Suscribe al grupo
            await HubConnection.InvokeAsync("Join", Token, Device);
        }
        catch (Exception)
        {
        }

    }


    public async Task JoinInventory(int inventory)
    {
        try
        {

            if (HubConnection == null || HubConnection.State != HubConnectionState.Connected)
            {
                return;
            }

            // Suscribe al grupo
            await HubConnection.InvokeAsync("JoinInventory", Token, inventory);

        }
        catch (Exception)
        {
        }

    }




    public async Task Notification(int inventory)
    {
        try
        {

            if (HubConnection == null || HubConnection.State != HubConnectionState.Connected)
            {
                return;
            }

            // Suscribe al grupo
            await HubConnection.InvokeAsync("Notification", Token, inventory);

        }
        catch (Exception)
        {
        }

    }






    public async Task SendCommand(CommandModel command)
    {
        try
        {
            await HubConnection!.InvokeAsync("SendCommand", Token, command);
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
