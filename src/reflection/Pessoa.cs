namespace reflection
{
    internal class Pessoa
    {
        public string Nome { get; private set; }
    
        public Pessoa(int id)
        {
            
        }

        public Pessoa(string nome, string nome1)
        {
            string testeLocal = "";
            int testeLocal1 = 0;

            Nome = nome;
        }

        public void Ola()
        {
            System.Console.WriteLine($"Olá para você {Nome}");
        }

        public void Hello()
        {
            System.Console.WriteLine($"Hello para você {Nome}");
        }
    }
}