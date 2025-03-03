namespace PlaygroundSSIS.Entities
{
    public class TurmaLyceum
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Disciplina { get; set; }
        public int NumeroAlunos { get; set; }
        public string Curso { get; set; }
        public string Docente { get; set; }
        public string Sala { get; set; }
        public string Predio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Periodo { get; set; }
    }
}
