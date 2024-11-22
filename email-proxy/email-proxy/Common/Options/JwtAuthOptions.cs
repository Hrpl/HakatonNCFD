using System;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace email_proxy.Common.Options;

public class JwtAuthOptions
{
    public const string Key = "JwtConfigurations";
    
    private string? _audience;
    private string _issuer = null!;
    private string _rsaPublicKeyPath = null!;
    private string _validAccessToken = null!;

    public string Issuer
    {
        get => _issuer;
        set
        {
            _issuer = value;
            ValidateIssuer = !string.IsNullOrEmpty(_issuer);
        }
    }

    public bool ValidateIssuer { get; private set; }

    public string? Audience
    {
        get => _audience;
        set
        {
            _audience = value;
            ValidateAudience = !string.IsNullOrEmpty(_audience);
        }
    }

    public bool ValidateAudience { get; private set; }

    public string ValidAccessToken
    {
        get => _validAccessToken;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "Не указан JWT токен для проверки сигнатуры. Значение ожидаеться в 'JwtConfiguration:ValidAccessToken' ");
            }

            _validAccessToken = value;
        }
    }

    public string RsaPublicKeyPath
    {
        get => _rsaPublicKeyPath;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "Не указаны пути для публичных ключей для проверки сигнатуры JWT. Значение ожидается в 'JwtConfiguration:RsaPublicKeyPath' ");
            }

            _rsaPublicKeyPath = value;
        }
    }

    public bool ValidateLifeTime { get; set; }

    public int ExpiresHours { get; set; }

    public SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(File.OpenText(RsaPublicKeyPath).ReadToEnd()));
}