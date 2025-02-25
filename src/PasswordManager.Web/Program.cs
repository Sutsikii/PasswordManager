using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PasswordManager.Transport;
using Refit;
using System;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBlazoredToast();
builder.Services.AddScoped<IPasswordManagerClient>(i => RestService.For<IPasswordManagerClient>("https://localhost:7032"));

await builder.Build().RunAsync();
