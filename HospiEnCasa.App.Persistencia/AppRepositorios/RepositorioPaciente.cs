using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext = new AppContext();
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)        
        {
            var PacienteAdicionado= _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return PacienteAdicionado.Entity;

        }
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }
        public void DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado= _appContext.Pacientes.FirstOrDefault(p => p.Id==idPaciente);
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();    
        }

        public Paciente GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.Find(idPaciente);
        }
        public Paciente UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado= _appContext.Pacientes.FirstOrDefault(p => p.Id==paciente.Id);
            if (pacienteEncontrado !=null)
            {
                pacienteEncontrado.Nombre=paciente.Nombre;
                pacienteEncontrado.Apellidos=paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono=paciente.NumeroTelefono;
                pacienteEncontrado.Genero=paciente.Genero;
                pacienteEncontrado.Direccion=paciente.Direccion;
                pacienteEncontrado.Latitud=paciente.Latitud;
                pacienteEncontrado.Longitud=paciente.Longitud;
                pacienteEncontrado.Ciudad=paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento=paciente.FechaNacimiento;
                //pacienteEncontrado.Familiar=paciente.Familiar;
                //pacienteEncontrado.Enfermera=paciente.Enfermera;
                //pacienteEncontrado.Medico=paciente.Medico;
                //pacienteEncontrado.Historia=paciente.Historia;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.Find(idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.Find(idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }        
    }
}