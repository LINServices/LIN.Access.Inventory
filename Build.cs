namespace LIN.Access.Inventory;


public class Build
{


    public static void Init(string? url = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "http://api.inventory.linapps.co/");
        //Service._Service.SetDefault("http://localhost:5089/");
    }


}