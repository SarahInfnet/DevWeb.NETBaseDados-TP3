namespace DesenvolvimentoWebDotNETBasesDados_TP3.Models
{
    public class Especialidade
    {
        public int EspecialidadeID { get; set; }
        public string Descricao { get; set; }
        public string AreaConhecimento { get; set; }

        public ICollection<Investidura> Investiduras { get; set; }
    }
}
