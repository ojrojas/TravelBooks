global using System;
global using System.Collections.Generic;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using System.Text.Json;
global using System.Threading.Tasks;
global using Ardalis.Specification;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Cryptography.KeyDerivation;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using Swashbuckle.AspNetCore.Annotations;
global using TravelBooks.Commons.Request;
global using TravelBooks.Identity.Configuration;
global using TravelBooks.Identity.Data;
global using TravelBooks.Identity.DI;
global using TravelBooks.Identity.Dtos;
global using TravelBooks.Identity.Entities;
global using TravelBooks.Identity.Infraestructure;
global using TravelBooks.Identity.Interfaces;
global using TravelBooks.Identity.Services;
global using TravelBooks.Identity.Specifications;
global using TravelBooks.Infraestructure.Data;
global using TravelBooks.Infraestructure.Interfaces;






