using PequiTec._Infra;
using PequiTec._Repositorio.Core;
using PequiTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace PequiTec._Repositorio
{
    public class NoticiaRepositorio : IRepositorio<Noticia>
    {
        IDB _db = DI.Sql();
        public void Adicionar(Noticia Titen)
        {
            var sql = " INSERT INTO [dbo].[Noticia]	" +
                        "            ([Titulo]			" +
                        "            ,[Descricao]		" +
                        "            ,[Data_Noticia]	" +
                        "            ,[Anexo])			" +
                        "      VALUES					" +
                        "            (@Titulo			" +
                        "            ,@Descricao		" +
                        "            ,@Data_Noticia 	" +
                        "            ,@Anexo)			";
            using (var db = _db.Getconnection())
            {
                db.Execute(sql, Titen);
            }
        }

        public void Deletar(Noticia Titen)
        {
            string sql = " DELETE FROM [Noticia]    " +
                         "  WHERE ID_Noticia = @ID_Noticia";
            using (var db = _db.Getconnection())
            {
                db.Execute(sql, Titen);
            }
        }

        public Noticia GetById(int ID)
        {
            using (var db = _db.Getconnection())
            {
                return db.QueryFirstOrDefault<Noticia>("SELECT * FROM NOTICIA WHERE ID_Noticia = @ID_Noticia", new { ID_Noticia = ID });
            }
        }

        public IEnumerable<Noticia> Listar()
        {
            using (var db = _db.Getconnection())
            {
                return db.Query<Noticia>("SELECT * FROM NOTICIA").ToList();
            }
        }

        public void Update(Noticia Titen)
        {
            string sql = " UPDATE [dbo].[Noticia]    " +
                        "    SET [Titulo] = @Titulo	" +
                        "       ,[Descricao] = @Descricao		" +
                        "       ,[Data_Noticia] = @Data_Noticia	" +
                        "       ,[Anexo] = @Anexo	" +
                        "  WHERE ID_Noticia = @ID_Noticia";
            using (var db = _db.Getconnection())
            {
                db.Execute(sql, Titen);
            }
        }
    }
}