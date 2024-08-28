namespace Ultima_questão_da_lista.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Peso { get; set; }
        public double Altura { get; set; }
    public double IMC()
    {
        return (Peso / (Altura * Altura));
    }
    }
}
