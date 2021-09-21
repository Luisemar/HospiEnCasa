using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World EF!");
            AddPaciente();
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Luis",
                Apellidos = "Matulanda",
                NumeroTelefono = "3508197515",
                Genero = Genero.Masculino,
                Direccion = "Calle 25 # 57 a -25",
                Longitud = 5.1221F,
                Latitud = 75.525F,
                Ciudad = "Bello"
///                FechaNacimiento = New DateTime(1990, 04, 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void IndexPacientes()
        foreach (var paciente in _repoPaciente.GetAllPacientes())
        {
            Consola.WriteLine(paciente.Nombre)
        }
    }
}
