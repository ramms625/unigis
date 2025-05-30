﻿using Unigis.PuntoVentas.BackEnd;


var builder = WebApplication.CreateBuilder(args);


var startUp = new Startup(builder.Configuration);
startUp.ConfigureServices(builder.Services);



var app = builder.Build();
startUp.Configure(app);