using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Azure.Storage.Blobs;
using Azure.Identity;
using Portfolio.Client;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//DI for the Resume link to Azure Storage
// builder.Services.AddSingleton(new BlobServiceClient(new Uri("https://lsnpersonalstorage.blob.core.windows.net/jobrelatedfiles/Lawrence%20Neris%20Software%20Engineer%20Resume.pdf?sp=r&st=2023-12-06T05:35:08Z&se=2024-12-06T13:35:08Z&spr=https&sv=2022-11-02&sr=b&sig=PpV0xNR8s7Y4VI%2BC%2BSwVd7PXYvowfPSEJm9vPJLRUmo%3D"), new DefaultAzureCredential()));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
