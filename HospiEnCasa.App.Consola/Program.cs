using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente();
        //private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());                
        private static IRepositorioMedico _repoMedico = new RepositorioMedico();        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World EF!");
            //AddPaciente();
            //IndexPacientes();
            //GetAllPacientes(); es la anterior
            //GetPaciente();            
            //DeletePaciente();
            UpdatePaciente();
            //AddMedico();
            //AsignarMedico();            
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Juan",
                Apellidos = "Pelaez",
                NumeroTelefono = "3018197515",
                Genero = Genero.Masculino,
                Direccion = "Calle 25 # 57 a -27",
                Longitud = 5.07062F,
                Latitud = -75.52290F,
                Ciudad = "Bello",
                FechaNacimiento = new DateTime(1995, 04, 12)                
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void IndexPacientes()
        {
            foreach (var paciente in _repoPaciente.GetAllPacientes())
         {
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);            
         }
        }
         private static void DeletePaciente()
        {
            _repoPaciente.DeletePaciente(4);
        }

         private static void GetPaciente()
        {
            var paciente = _repoPaciente.GetPaciente(3);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        } 

         private  static void UpdatePaciente()
         {
            var paciente = _repoPaciente.GetPaciente(3);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
             paciente.Apellidos = "Pelaez";
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);             
             _repoPaciente.UpdatePaciente(paciente);
         }


        private static void AddMedico()
        {
            var medico = new Medico
            {
                Nombre = "Juanita",
                Apellidos = "Gomez",
                NumeroTelefono = "3001645",
                Genero = Genero.Femenino,
                Especialidad = "Internista",
                Codigo = "123456",
                RegistroRethus = "ABC123",
            };
            _repoMedico.AddMedico(medico);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1, 3);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos);
        }

    }
}       