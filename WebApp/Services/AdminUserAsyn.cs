using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;

public class AuthMessageSenderOptions
{
    public string? SendGridKey { get; set; }
}
