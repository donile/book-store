using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BookStore.Api.Tests.Integration;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    var contentRoot 
      = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
        ?? throw new NullReferenceException();

    builder.UseContentRoot(contentRoot);
    
    base.ConfigureWebHost(builder);
  }
}
