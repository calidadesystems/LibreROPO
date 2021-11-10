using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Net.Http;



namespace LibreROPO
{
    public sealed class LibreROPOdb
    {
        private String path;
        private static LibreROPOdb instance = null;
        private static readonly object padlock = new object();


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

 
        public static LibreROPOdb GetInstance(String path)
        {
            if (instance == null)
            {
                instance = new LibreROPOdb(path);
            }
            return instance;
        }


        public bool fileExists()
        {
            return File.Exists(this.path);
        }

        public bool isValidDb()
        {
            return existsConfigClave("AppName");
        }

        private SQLiteConnection GetConn()
        {
            SQLiteConnection toret = new SQLiteConnection("Data Source=" + this.path + ";Version=3;");
            toret.Open();
            return toret;
        }

        private void deploydb(String dbversion)
        {
            switch (dbversion)
            {
                case "":
                    SQLiteConnection.CreateFile(this.path);
                    SQLiteConnection sqli = new SQLiteConnection("Data Source=" + this.path + ";Version=3;");
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
                    this.deploydbdata(dbversion);
                    insertConfig("AppName", "LibreROPO");
                    break;

            }
        }

        public void insertConfig(string clave, string valor)
        {
            if (existsConfigClave(clave))
            {
                UpdateConfig(clave, valor);
            }
            else
            {
                insertNewConfig(clave, valor);
            }
        }
        public void insertNewConfig(string clave, string valor)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into CONFIGURACION(clave,valor) values(@clave,@valor) ";
            command.Parameters.AddWithValue("clave", clave);
            command.Parameters.AddWithValue("valor", valor);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateConfig(string clave, string valor)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "update CONFIGURACION set valor=@valor where clave=@clave; ";
            command.Parameters.AddWithValue("clave", clave);
            command.Parameters.AddWithValue("valor", valor);
            command.ExecuteNonQuery();
            con.Close();
        }

        public bool existsConfigClave(string clave)
        {
            bool toret =false;
            int veces = 0;
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "Select count(*) from configuracion where clave=@CLAVE ";
            command.Parameters.AddWithValue("@CLAVE", clave);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                veces = rdr.GetInt32(0);
            }
            if (veces > 0)
            {
                toret = true;
            }
            con.Close();
            return toret;
        }


        private void deploydbdata(String dbversion)
        {
            string baseurl;
            switch (dbversion)
            {
                case "":
                    baseurl = "https://raw.githubusercontent.com/calidadesystems/LibreROPO/master/DOC/data/0.9/";
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl+"index.txt").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var file in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                Console.WriteLine("******************");
                                Console.WriteLine(file);
                                this.InsertData(baseurl,file);
                            }
                        }
                    }
                    break;
            }
        }
  

        private void InsertData(string baseurl,string table) 
        {
            Console.WriteLine("*InsertData*");
            Console.WriteLine(table);
            int times = 0;
            switch (table) 
            {
                case "UNIDAD.csv":
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl + table).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var values in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (times > 0)
                                {
                                    InsertUnidad(values);
                                }
                                times++;
                            }
                        }
                    }
                    break;
                case "CODIGOOPERACION.csv":
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl + table).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var values in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (times > 0)
                                {
                                    InsertCodOperacion(values);
                                }
                                times++;
                            }
                        }
                    }
                    break;
                case "PAIS.csv":
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl + table).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var values in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (times > 0)
                                {
                                    InsertPais(values);
                                }
                                times++;
                            }
                        }
                    }
                    break;
                case "PROVINCIA.csv":
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl + table).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var values in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (times > 0)
                                {
                                    InsertProvincia(values);
                                }
                                times++;
                            }
                        }
                    }
                    break;
                case "MUNICIPIO.csv":
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(baseurl + table).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            string responseString = responseContent.ReadAsStringAsync().Result;
                            foreach (var values in responseString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (times > 0)
                                {
                                    InsertMunicipio(values);
                                }
                                times++;
                            }
                        }
                    }
                    break;
            }
        }

        private void InsertUnidad(string values) 
        {
            
            string[] separatedvalues = values.Split(',');
            Unidad unid = new Unidad(Int32.Parse(separatedvalues[0]), separatedvalues[1]);
            InsertUnidad(unid);
        }

        private void InsertUnidad(Unidad unid)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into UNIDAD(codigo,descripcion) values(@codigo,@descripcion) ";
            command.Parameters.AddWithValue("codigo", unid.Codigo);
            command.Parameters.AddWithValue("descripcion", unid.Descripcion);
            command.ExecuteNonQuery();
            con.Close();

        }

        private void InsertCodOperacion(string values)
        {
            string[] separatedvalues = values.Split(',');
            Operacion oper = new Operacion(Int32.Parse(separatedvalues[0]), separatedvalues[1]);
            InsertCodOperacion(oper);
        }

        private void InsertCodOperacion(Operacion oper)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into CODIGOOPERACION(codigo,descripcion) values(@codigo,@descripcion) ";
            command.Parameters.AddWithValue("codigo", oper.Codigo);
            command.Parameters.AddWithValue("descripcion", oper.Descripcion);
            command.ExecuteNonQuery();
            con.Close();
        }

        private void InsertPais(string values)
        {
            string[] separatedvalues = values.Split(',');
            Pais pai = new Pais(separatedvalues[0], separatedvalues[1]);
            InsertPais(pai);
        }

        private void InsertPais(Pais pai)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into PAIS(identificador,pais) values(@identificador,@pais) ";
            command.Parameters.AddWithValue("identificador",pai.Identificador);
            command.Parameters.AddWithValue("pais", pai.Nombre);
            command.ExecuteNonQuery();
            con.Close();
        }

        private void InsertProvincia(string values)
        {
            string[] separatedvalues = values.Split(',');
            Provincia prov = new Provincia(Int32.Parse(separatedvalues[0]), separatedvalues[1]);
            InsertProvincia(prov);
        }

        private void InsertProvincia(Provincia prov)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into PROVINCIA(INE,PROVINCIA) values(@INE,@PROVINCIA) ";
            command.Parameters.AddWithValue("INE", prov.Ine);
            command.Parameters.AddWithValue("PROVINCIA", prov.Nombre);
            Console.WriteLine(command.ToString());
            command.ExecuteNonQuery();
            con.Close();
        }

        private void InsertMunicipio(string values)
        {
            string[] separatedvalues = values.Split(',');
            Municipio muni = new Municipio(Int32.Parse(separatedvalues[0]), Int32.Parse(separatedvalues[1]), Int32.Parse(separatedvalues[2]), separatedvalues[3]);
            InsertMunicipio(muni);
        }

        private void InsertMunicipio(Municipio muni)
        {
            SQLiteConnection con = this.GetConn();
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = "insert into MUNICIPIO (INEPROVINCIA,CODMUNICIPIO,DC,NOMBRE) values(@INEPROVINCIA,@CODMUNICIPIO,@DC,@NOMBRE) ";
            command.Parameters.AddWithValue("INEPROVINCIA", muni.Ineprovincia);
            command.Parameters.AddWithValue("CODMUNICIPIO", muni.Codmunicipio);
            command.Parameters.AddWithValue("DC", muni.Dc);
            command.Parameters.AddWithValue("NOMBRE", muni.Nombre);
            command.ExecuteNonQuery();
            con.Close();
        }

        public DataSet GetListarClientes() 
        {
            DataSet toret = new DataSet();
            SQLiteConnection con = this.GetConn();
            SQLiteDataAdapter sqda;
            sqda = new SQLiteDataAdapter("Select * from Cliente", con);
            sqda.Fill(toret);
            con.Close();
            return toret;
        }


    }
}