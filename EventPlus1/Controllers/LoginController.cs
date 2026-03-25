using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface; // Ajustado para Interface (singular ou conforme sua pasta)
using EventPlus1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDto)
    {
        try
        {
            
            Usuario usuarioBuscado = _usuarioRepository.BuscarEmailESenha(loginDto.Email!, loginDto.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation?.Titulo ?? "Comum")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-dev"));

            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken
            (
                issuer: "eventplus_api",
                audience: "eventplus_api",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}