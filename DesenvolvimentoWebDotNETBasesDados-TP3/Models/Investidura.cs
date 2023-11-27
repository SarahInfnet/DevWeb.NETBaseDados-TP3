namespace DesenvolvimentoWebDotNETBasesDados_TP3.Models
{
    public class Investidura
    {
        public int InvestiduraID { get; set; }
        public int AventureiroID { get; set; }
        public int EspecialidadeID { get; set; }
        public Aventureiro Aventureiro { get; set; }
        public DateTime DataInvestidura { get; set; }
        public Especialidade Especialidade { get; set; }

    }
}
