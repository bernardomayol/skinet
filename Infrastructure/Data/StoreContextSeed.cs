using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAgregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class StoreContextSeed
  {
    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
    {
      try
      {
        if (!context.ProductBrands.Any())
        {
          var brandsData = File.ReadAllText("../Infrastructure/data/seeddata/brands.json");
          var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
          foreach (var item in brands)
          {
            context.ProductBrands.Add(item);
          }
          await context.SaveChangesAsync();
        }
        if (!context.ProductTypes.Any())
        {
          var typesData = File.ReadAllText("../Infrastructure/data/seeddata/types.json");
          var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
          foreach (var item in types)
          {
            context.ProductTypes.Add(item);
          }
          await context.SaveChangesAsync();
        }
        if (!context.Products.Any())
        {
          var productsData = File.ReadAllText("../Infrastructure/data/seeddata/products.json");
          var products = JsonSerializer.Deserialize<List<Product>>(productsData);
          foreach (var item in products)
          {
            context.Products.Add(item);
          }
          await context.SaveChangesAsync();
        }
         if (!context.DeliveryMethods.Any())
        {
          var dmData = File.ReadAllText("../Infrastructure/data/seeddata/delivery.json");
          var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
          foreach (var m in methods)
          {
            context.DeliveryMethods.Add(m);
          }
          await context.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
          var logger = loggerFactory.CreateLogger<StoreContextSeed>();
          logger.LogError(ex.Message);
      }
    }
  }
}