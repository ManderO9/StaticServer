using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async (context) =>
{
    // Set status code to 200
    context.Response.StatusCode = 200;

    // Get the path of the web root folder
    var path = context.RequestServices.GetRequiredService<IWebHostEnvironment>().WebRootPath;
    
    // Open the index.html file for read
    await File.OpenRead(path + Path.DirectorySeparatorChar + "index.html")
               // Write the content of the file to the response body          
               .CopyToAsync(context.Response.Body);

    // Set content to type to html
    context.Response.ContentType = MediaTypeNames.Text.Html;;
});

app.Run();
