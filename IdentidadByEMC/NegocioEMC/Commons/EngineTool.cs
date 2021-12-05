using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using ImageEMC;
using System.Text.RegularExpressions;

namespace NegocioEMC.Commons
{
    public class EngineTool
    {
        public static string EnCodeBase64(string cadena)
        {
            var bytes = Encoding.UTF8.GetBytes(cadena);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64(string cadena)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(cadena);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static Guid CreateUniqueidentifier()
        {
            Guid g = CreateGuid();
            if (g == Guid.Empty)
                g = CreateUniqueidentifier();

            return g;
        }

        private static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        public static bool CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return false;
            }

            return true;
        }

        public static bool EmailEsValido(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool resultado = false;
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                    resultado = true;
            }
            return resultado;
        }



        public static ICollection<PersonaDTO> ReadFileXls(string fileSrc, string folderSrc, int idEmpresa, string nombreEmpresa)
        {
            PersonaDTO p = new PersonaDTO();
            ICollection<PersonaDTO> lst = new List<PersonaDTO>();

            using (var stream = File.Open(fileSrc, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                   reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream); ;

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                var dataSet = reader.AsDataSet(conf);
                var dt = dataSet.Tables[0];

                var sourceQR = string.Empty;
                var qrBase64 = string.Empty;

                foreach (DataRow r in dt.Rows)
                {
                    try 
                    {
                       // if(dt.Columns.Contains("DNI"))
                        p.Dni = !string.IsNullOrEmpty(r["DNI"].ToString()) ? r["DNI"].ToString() : string.Empty;
                        p.Foto = fileSrc + @"imagenes/" + p.Dni + "jpg";
                        p.Foto =!string.IsNullOrEmpty(r["FOTO"].ToString()) ? r["FOTO"].ToString() : string.Empty;
                        p.Nombre = !string.IsNullOrEmpty(r["NOMBRE"].ToString()) ? r["NOMBRE"].ToString() : string.Empty;
                        p.Apellido = !string.IsNullOrEmpty(r["APELLIDO"].ToString()) ? r["APELLIDO"].ToString() : string.Empty;
                        //p.Dni = !string.IsNullOrEmpty(r["DNI"].ToString()) ? r["DNI"].ToString() : string.Empty;
                        p.Matricula = !string.IsNullOrEmpty(r["MATRICULA"].ToString()) ? r["MATRICULA"].ToString() : string.Empty;
                        p.Rh = !string.IsNullOrEmpty(r["RH"].ToString()) ? r["RH"].ToString() : string.Empty;
                        p.Grado = !string.IsNullOrEmpty(r["GRADO"].ToString()) ? r["GRADO"].ToString() : string.Empty;
                        p.Grupo = !string.IsNullOrEmpty(r["GRUPO"].ToString()) ? r["GRUPO"].ToString() : string.Empty;
                        p.Email = !string.IsNullOrEmpty(r["EMAIL"].ToString()) ? r["EMAIL"].ToString() : string.Empty;
                        p.Email = EmailEsValido(p.Email) ? p.Email : "creativarionegro@gmail.com";
                        p.Empresa = !string.IsNullOrEmpty(r["EMPRESA"].ToString()) ? r["EMPRESA"].ToString() : string.Empty;
                        p.Turno = !string.IsNullOrEmpty(r["TURNO"].ToString()) ? r["TURNO"].ToString() :string.Empty;
                        p.IdTurno = IdTurno(p.Turno);
                        p.Identificador = CreateGuid().ToString();
                        p.IdEmpresa = idEmpresa;
                        p.Empresa = nombreEmpresa;
                        p.Fecha = DateTime.Now;
                        p.Activo = true;
                        sourceQR = p.Nombre + "#" + p.Apellido + "#" + p.Dni;
                        sourceQR = EnCodeBase64(sourceQR);
                        p.PathQr = ImagenCode.CreadorCodigoQR(sourceQR, folderSrc + @"imagenesQR/" + p.Dni + ".png");
                        p.Qr = ImagenCode.ConvertImgTo64Base(folderSrc + @"imagenesQR/" + p.Dni + ".png");
                        lst.Add(p);
                        p = new PersonaDTO();
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return lst;
        }


        private static int IdTurno(string turno)
        {
            if (turno.ToUpper() == "MAÑANA" || string.IsNullOrEmpty(turno))
                turno = "1";
            else if (turno.ToUpper() == "TARDE")
                turno = "2";
            else if (turno.ToUpper() == "NOCHE")
                turno = "3";
            else
                turno = "1";

            return Convert.ToInt32(turno);
        }


    }
}
