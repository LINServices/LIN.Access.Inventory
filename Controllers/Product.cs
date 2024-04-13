namespace LIN.Access.Inventory.Controllers;


public static class Product
{


    /// <summary>
    /// Crear un producto.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(ProductModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener los productos asociados a un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
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
    /// Obtener un producto.
    /// </summary>
    /// <param name="id">Id del producto.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<ProductModel>> Read(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<ProductModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener un producto según su detalle.
    /// </summary>
    /// <param name="id">Id del detalle.</param>
    /// <param name="token">Token de acceso.</param>
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
    /// Actualizar un producto.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="isBase">Es base.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> UpdateAsync(ProductModel modelo, bool isBase, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("isBase", $"{isBase}");

        // Resultado.
        var Content = await client.Patch<ResponseBase>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualizar un producto.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(ProductModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Eliminar un producto.
    /// </summary>
    /// <param name="id">Id del producto.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("product");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }



}