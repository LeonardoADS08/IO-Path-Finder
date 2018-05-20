using System.Collections;
using System.IO;
using System.Collections.Generic;
using LiteDB;
using System;

namespace Utils
{
    public static class uDB
    {
        public const string NOMBRE_BD = "IOPathFindingDB";
        /// <summary>
        /// Esta clase abstracta permite la implementación de un CRUD rápido para cualquier clase sin código, eso sí, se debe definir el método abstracto 'protected void DefinirID(LiteCollection<T>)'
        /// </summary>
        /// <typeparam name="T">Clase para implementar CRUD a la base de datos.</typeparam>
        public class CRUD<T>
        {

            //protected abstract void DefinirID(LiteCollection<T> Coleccion);

            /// <summary>
            /// Guarda un nuevo registro en la base de datos.
            /// </summary>
            public static void Insertar(T Dato)
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        col.Insert(Dato);
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Insertar({0})", typeof(T).Name));
                }
            }

            /// <summary>
            /// Inserta una lista a la colección.
            /// </summary>
            public static void Insertar(List<T> Dato)
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        foreach (var val in Dato)
                            col.Insert(val);
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Insertar({0})", typeof(T).Name));
                }
            }

            /// <summary>
            /// Edita un registro existente en la base de datos a partir de su identificador.
            /// </summary>
            public static void Editar(int id, T Dato)
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        col.Update(id, Dato);
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Editar(int, {0})", typeof(T).Name));
                }
            }

            /// <summary>
            /// Elimina una colección.
            /// </summary>
            public static void Eliminar()
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        db.DropCollection(col.Name);
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Eliminar()", typeof(T).Name));
                }
            }


            /// <summary>
            /// Elimina un registro a partir de su identificador.
            /// </summary>
            public static void Eliminar(int id)
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        col.Delete(new BsonValue(id));
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Eliminar(int)", typeof(T).Name));
                }
            }

            /// <summary>
            /// Consulta especifica, busca el registro que coincida con el identificador pasado.
            /// </summary>
            public static T Consulta(int id)
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        var busqueda = col.FindById(new BsonValue(id));
                        return busqueda;
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Consulta(int)", typeof(T).Name));
                    return default(T);
                }
            }

            /// <summary>
            /// Consulta general, devuelve todos los elementos de la tabla en una lista.
            /// </summary>
            public static List<T> Consulta()
            {
                try
                {
                    using (var db = new LiteDatabase(NOMBRE_BD))
                    {
                        var col = db.GetCollection<T>();
                        List<T> resList = new List<T>();
                        resList.AddRange(col.Find(Query.All()));
                        return resList;
                    }
                }
                catch (Exception ex)
                {
                    Logs.GuardarLog(ex.Message, string.Format("uDB.CRUD<{0}>.Consulta()", typeof(T).Name));
                    return null;
                }
            }
        }

    }
}