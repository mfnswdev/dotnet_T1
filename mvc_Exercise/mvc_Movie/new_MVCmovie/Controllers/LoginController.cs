using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using new_MVCmovie.Models;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;


namespace new_MVCmovie.Controllers;
public class LoginController : Controller
{
    private readonly MvcMovieContext _context;
    private readonly IConfiguration _configuration;
    public LoginController(MvcMovieContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public IActionResult Index()
    {
        return View();
    }
  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login([Bind("username,password")] Login login)
    {
  
        string token = Auth(login);
       
        Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddMinutes(30)
        });
        
        //add token ao response http
        
        return RedirectToAction("Index", "Home");


    }
    

     public string GenerateJwtToken(string email, string role)
    {
        var issuer = "MvcMovie";
        var audience = "user";
        var key = "Esta é a chave secreta do MvcMovie.WebAPI2024residenciatic18";
        //cria uma chave utilizando criptografia simétrica
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? ""));
        //cria as credenciais do token
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
         new Claim("userName", email),
         new Claim(ClaimTypes.Role, role)
      };

        var token = new JwtSecurityToken( //cria o token
           issuer: issuer, //emissor do token
           audience: audience, //destinatário do token
           claims: claims, //informações do usuário
           expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
           signingCredentials: credentials); //credenciais do token


        var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }

     public string Auth(Login login)
        {
        
        if (login.username == null || login.password == null)
            throw new ValidationException("Email e/ou senha inválidos");
        if (_context.User.Any(x => x.username  == login.username)
        && _context.User.Any(x => x.password == login.password))
        {
            User? _user = _context.User.FirstOrDefault(x => x.username == login.username);
            
            string _token = GenerateJwtToken(login.username, _user!.role ?? "user");
            return _token;
           
        }
        else
        {
            throw new ValidationException("Username e/ou senha inválidos");

        }
}
}

