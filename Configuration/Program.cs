﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var configValues = new Dictionary<string, string>()
{
    ["credentials:name"] = "ryan",

    // when uncommented, will provide data for IOptions<Person> instance
    ["PaymentProcessing:ConfigSettings:2:Id"] = "3",
    ["PaymentProcessing:ConfigSettings:2:Name"] = "Payments-C",
    ["PaymentProcessing:ConfigSettings:2:Timeout"] = "200",
    ["PaymentProcessing:ConfigSettings:2:QueuingEnabled"] = "true"
};

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration(config =>
{
    // NOTE: the order matters!

    // load settings from settings.json
    config.AddJsonFile("settings.json");

    // load settings from settings.ini
    config.AddIniFile("settings.ini");

    // load in-memory settings
    config.AddInMemoryCollection(configValues);

    // add environment variables
    config.AddEnvironmentVariables();

    // add local user secrets
    config.AddUserSecrets<Program>();

    // add command line arguments
    config.AddCommandLine(args);
});
    
builder.ConfigureServices((builder, services) =>
{
    // configure IOptions<Person>
    services.Configure<PaymentProcessing>(builder.Configuration.GetSection("PaymentProcessing"));
});

var app = builder.Build();

var configuration = app.Services.GetService<IConfiguration>();

Console.WriteLine($"\nSetting from memory: {configuration["credentials:name"]}");
Console.WriteLine($"Setting from settings.json: {configuration["PaymentProcessing:ConfigSettings:0:Name"]}");

// settings from secrets json file
Console.WriteLine($"\nSettings from secrets.json: {configuration["Username"]}");
Console.WriteLine($"Settings from secrets.json: {configuration["Password"]}");

// values combined from multiple configuration sources
Console.WriteLine($"\nMinInstances: {configuration["PaymentProcessing:MinInstances"]}");
Console.WriteLine($"MaxInstances: {configuration["PaymentProcessing:MaxInstances"]}\n");

var paymentProcessingSettings = app.Services.GetService<IOptions<PaymentProcessing>>();

// optionally, directly create a PaymentProcessing instance that is bound from the configuration section (i.e., not using IOptions<T>)
//var paymentProcessingSettingsAlt = configuration.GetSection("PaymentProcessing").Get<PaymentProcessing>();

foreach (var configSetting in paymentProcessingSettings.Value.ConfigSettings)
{
    Console.WriteLine($"[{configSetting.Id}] => {configSetting.Name} has timeout of {configSetting.Timeout} seconds with queuing value of '{configSetting.QueuingEnabled}'");
}