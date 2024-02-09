namespace LIN.Access.Inventory.Controllers;


public static class Product
{


    /// <summary>
    /// Crea un nuevo producto
    /// </summary>
    /// <param name="modelo">Modelo</param>
    public async static Task<CreateResponse> Create(ProductModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/create");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtiene la lista de productos asociados a un inventario
    /// </summary>
    /// <param name="id">Id del inventario</param>
    public async static Task<ReadAllResponse<ProductModel>> ReadAll(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/read/all");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<ProductModel>>();

        // Retornar.
        return Content;

    }



 

    /// <summary>
    /// Obtiene un producto por medio del Id
    /// </summary>
    /// <param name="id">Id del producto</param>
    public async static Task<ReadOneResponse<ProductModel>> Read(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/read");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProductModel>>();

        // Retornar.
        return Content;

    }




    /// <summary>
    /// Obtiene un producto por medio del Id de detalle de producto
    /// </summary>
    /// <param name="id">Id del detalle</param>
    public async static Task<ReadOneResponse<ProductModel>> ReadOneByDetail(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/readByDetail");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProductModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualiza la informacion de un producto
    /// </summary>
    public async static Task<ResponseBase> UpdateAsync(ProductModel modelo, bool isBase, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/update");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("isBase", $"{isBase}");

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualiza la informacion de un producto
    /// </summary>
    public async static Task<ResponseBase> Update(ProductModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/update");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>(modelo);

        // Retornar.
        return Content;

    }






    public async static Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product/detele");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }



}
