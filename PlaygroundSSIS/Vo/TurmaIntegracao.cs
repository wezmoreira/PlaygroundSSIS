namespace PlaygroundSSIS.Vo
{
    public class TurmaIntegracao
    {
        public int TurmaId { get; set; }
        public string TipoOperacao { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }
        public string Email { get; set; }
        public int NumeroAlunos { get; set; }
        public string Curso { get; set; }
        public string Docente { get; set; }
        public string Predio { get; set; }
        public string Sala { get; set; }
        public int Periodo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}