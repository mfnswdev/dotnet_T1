using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;

public class AtendimentosDB : IAtendimentoCollection
{

   private readonly List<Atendimento> _atendimentos = new List<Atendimento>();
   private int _id = 0;   
   public void Create(Atendimento atendimento)
   {
      if(_atendimentos.Count > 0)
         _id = _atendimentos.Max(m => m.PacienteId);
      atendimento.AtendimentoId = ++_id;
      _atendimentos.Add(atendimento);
   }
   public void Delete(int id)
   {
      _atendimentos.RemoveAll(m => m.AtendimentoId == id);
   }
   public ICollection<Atendimento> GetAll()
   {
      return _atendimentos.ToArray();
   }
   public Atendimento? GetById(int id)
   {
      return _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
   }
   public void Update(int id, Atendimento atendimento)
   {
      var atendimentoDB = _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
      if(atendimentoDB is not null)
      {
         atendimentoDB.Paciente.Nome = atendimento.Paciente.Nome;
         atendimentoDB.Medico.Nome = atendimento.Medico.Nome;
      }
   }
}

