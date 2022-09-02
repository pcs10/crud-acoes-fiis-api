using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Controllers
{
    
  //  [Authorize]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosAsync()
        {
            try
            {
                return Ok(await _usuarioService.BuscarTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }// listar todos


        [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var erro = await _usuarioService.Inserir(usuario);

                if ((erro == null) || erro == "")
                {
                    usuario.Senha = "";
                    return Created($"v1/usuarios/{usuario.Id}", usuario);
                }
                else
                    return BadRequest("ERRO -> " + erro.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//inserir

        [HttpPut(template: ("{id}"))]
        public async Task<IActionResult> AlterarAsync([FromBody] Usuario usuarioModel, [FromRoute] int id)
        {
            try
            {
                var usuario = await _usuarioService.Alterar(usuarioModel, id);

                if ((usuario == null) || usuario == "")
                    return Ok(usuario);
                else
                    return BadRequest("ERRO -> " + usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        } //alterar

        [HttpGet]
        [Route(template: "{id}")]
        public async Task<IActionResult> ListarPorIdAsync([FromRoute] int id)
        {
            try
            {
                var usuario = await _usuarioService.BuscarPorId(id);

                if (usuario == null)
                {
                    return BadRequest("ERRO -> Usuário não encontrado");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }//listar um

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _usuarioService.Excluir(id);

                if ((erro == null) || erro == "")
                    return Ok("Usuário excluído com sucesso");
                else
                    return BadRequest("ERRO -> " + erro);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//excluir


    }
}
