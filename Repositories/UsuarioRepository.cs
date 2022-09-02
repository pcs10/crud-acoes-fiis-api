using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        //deixar o contexto fora para que nao precise toda horas ficar passando ele entre parametros
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Usuario> BuscarPorId(int id)
        {
            var usuario = await _context
                 .Usuarios
                 .FirstOrDefaultAsync(x => x.Id == id);

            return usuario;
        }// buscar por ID

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            var usuarios = await _context
                            .Usuarios
                            //.Include(fii => fii.FundosImobiliarios)
                            .AsNoTracking()
                            .ToListAsync();

            return usuarios;
        }// buscar todos

        public async Task<string> Inserir(Usuario usuario)
        {

            //verificar se o nome de usuário ja existe
            var usuarioComparacao = await _context
                .Usuarios
                .FirstOrDefaultAsync(uc => uc.NomeDeUsuario == usuario.NomeDeUsuario);

            if (usuarioComparacao != null)
            {
                return "Usuário existente";
            }
            else
            {
                try
                {
                    await _context.Usuarios.AddAsync(usuario);
                    await _context.SaveChangesAsync();
                    return "";
                }
                catch (Exception ex)
                {
                    return "Erro ao inserir -> " + ex;
                }
            }
        }// Inserir

        public async Task<string> Alterar(Usuario usuario, int id)
        {
            //verificar se existe usuario com o id informado
            var usuarioAlterar = await _context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(ua => ua.Id == id);

            if (usuarioAlterar == null)
            {
                return "Usuário não encontrado";
            }

            //verificar se existe algum outro usuario com o mesmo nome de usuário passado
            var usuarioAlterar2 = await _context
                 .Usuarios
                 .AsNoTracking()
                 .FirstOrDefaultAsync(ua2 => ua2.Id != id && ua2.NomeDeUsuario == usuario.NomeDeUsuario);


            if (usuarioAlterar2 != null)
                return "Nome de usuário já pertence a um usuário";

            if (usuario.NomeDeUsuario.Length < 3 || usuario.NomeDeUsuario.Length > 20)
                return "O nome de usuário deve conter entre 3 e 20 caracteres";


            usuario.Id = id; // add o id no modelo

            // se não for passada senha no json, usar a senha atual
            if (usuario.Senha == null) usuario.Senha = usuarioAlterar.Senha;

            try
            {
                // _context.Usuarios.Update(usuario);
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar -> " + ex;
            }


        }//alterar

        public async Task<string> Excluir(int id)
        {
            var usuario = await _context
                 .Usuarios
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null) return "Categoria não encontrado";

            try
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir -> " + ex;
            }
        } //excluir

    }
}
