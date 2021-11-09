using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace LibreROPO
{
    class LibreROPOdb
    {
        private String path;
        public LibreROPOdb(String path) 
        {
            this.path = path;
            if (this.fileExists()) 
                {
            
                } 
            else
                {
                this.deploydb("");
                }

        }

        public bool fileExists()
        {
            return File.Exists(this.path);
        }

        public bool isValidDb() 
        {
            bool toret = false;
            return toret;
        }

        private void deploydb( String dbversion)
        {
            switch (dbversion) 
            {
                case "":
                    SQLiteConnection.CreateFile(this.path);
                    SQLiteConnection sqli = new SQLiteConnection("Data Source="+this.path+";Version=3;");
                    SQLiteCommand cmd;
                    string sql;
                    sqli.Open();
                    sql = "CREATE TABLE CODIGOOPERACION ( codigo INTEGER PRIMARY KEY, descripcion TEXT(200) );";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "CREATE TABLE UNIDAD(codigo INTEGER PRIMARY KEY, descripcion TEXT(3));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "CREATE TABLE PAIS(identificador TEXT(2) PRIMARY KEY,pais TEXT(200));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "CREATE TABLE PROVINCIA(INE INTEGER PRIMARY KEY,PROVINCIA TEXT(200));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "CREATE TABLE MUNICIPIO(INEPROVINCIA INTEGER,CODMUNICIPIO INTEGER,DC INTEGER,NOMBRE TEXT(200),FOREIGN KEY(INEPROVINCIA) REFERENCES PROVINCIA(INE),PRIMARY KEY (INEPROVINCIA,CODMUNICIPIO));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table RESPONSABLE(NIFResponsable TEXT(9)  PRIMARY KEY,ROPOResponsable TEXT(20));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table PRODUCTO(NumeroRegistro TEXT(255),NombreComercial TEXT(255),ImportacionParalela TEXT(1),DenominacionComun TEXT(1),CultivoTratamiento TEXT(255),PRIMARY KEY(NumeroRegistro)); ";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table PRODUCTO(NumeroRegistro TEXT(255),NombreComercial TEXT(255),ImportacionParalela TEXT(1),DenominacionComun TEXT(1),CultivoTratamiento TEXT(255),PRIMARY KEY(NumeroRegistro)); ";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table CONFIGURACION(clave text(20),valor text(255));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table CLIENTE(NIFDestino TEXT(20)  PRIMARY KEY,ROPODestino TEXT(20),EntidadDestino TEXT(200),CorreoElectronicoDestino TEXT(255),TelefonoDestino	TEXT(10),FaxDestino		TEXT(20),DireccionDestino TEXT(255),CodPostalDestino TEXT(5),PaisDestino	TEXT(2),ProvinciaDestino	TEXT(2),LocalidadDestino	INTEGER,FOREIGN KEY(PaisDestino) REFERENCES PAIS(identificador),FOREIGN KEY(ProvinciaDestino) REFERENCES PROVINCIA(INE),FOREIGN KEY(LocalidadDestino) REFERENCES MUNICIPIO(CODMUNICIPIO));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table AUTORIZADOCLIENTE(NIFDestino TEXT(20) ,NIFPersonaAutorizada TEXT(20),NombrePersonaAutorizada TEXT(255),PrimerApellidoPersonaAutorizada TEXT(255),SegundoApellidoPersonaAutorizada TEXT(255),EmpresaExplotacionUsuarioProfesional  TEXT(255)	,FOREIGN KEY(NIFDestino) REFERENCES CLIENTE(NIFDestino),PRIMARY KEY (NIFDestino, NIFPersonaAutorizada));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table REGISTRO(id_registro INTEGER PRIMARY KEY AUTOINCREMENT,fecha TEXT,CODIGOOPERACION INTEGER,NIFDestino TEXT(20) ,NIFPersonaAutorizada TEXT(20),FOREIGN KEY(NIFDestino) REFERENCES CLIENTE(NIFDestino),FOREIGN KEY(NIFPersonaAutorizada) REFERENCES AUTORIZADOCLIENTE(NIFDestino),FOREIGN KEY(CODIGOOPERACION) REFERENCES CODIGOOPERACION(codigo));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sql = "create table REGISTRO_PRODUCTO(id_registro INTEGER,NumeroRegistro TEXT(255),NumeroEnvases	INTEGER,Lote	TEXT(255),Capacidad       INTEGER,Unidad          INTEGER,FOREIGN KEY(Unidad) REFERENCES UNIDAD(codigo),FOREIGN KEY(id_registro) REFERENCES REGISTRO(id_registro),FOREIGN KEY(NumeroRegistro) REFERENCES PRODUCTO(NumeroRegistro),PRIMARY KEY (id_registro,NumeroRegistro));";
                    cmd = new SQLiteCommand(sql, sqli);
                    cmd.ExecuteNonQuery();
                    sqli.Close();
                    break;
            
            }
        }
    }
}
