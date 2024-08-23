using System;

class Program
{
    static void Escreva(string text) 
    {
        Console.WriteLine(text);
    }
    static void HelloWorld(string mensagem)
    {
        Escreva(mensagem);
    }

    static void Apresentacao(string nome, int idade, double altura, char inicial, bool ehProgramador) 
    {
        Escreva("Meu nome é " + nome);
        Escreva("Tenho " + idade + " anos");
        Escreva("Tenho " + altura + " de altura");
        Escreva("Meu nome começa com: " + inicial);
        Escreva("E se você tem dúvidas se sou programador, minha resposta é " + ehProgramador);
    }

    static void PulaLinha()
    {
        Console.WriteLine();
    }

    static void OlaUser() 
    {
        Console.WriteLine("Bem vindo! Qual é o seu nome?");
        Console.Write(": ");
        while (true) 
        {
            string? nomeUser = Console.ReadLine();
            if(nomeUser == null || nomeUser == "")
            {
                Escreva("Valor inválido!!");
                Escreva("Tente novamente outro valor!!");
                PulaLinha();
            }
            else 
            {
                Escreva("Olá " + nomeUser + "!! Aproveite o sistema!!");
                break;
            }
        }
    }

    static void Main(string[] args)
    {
        string nome = "Davyd";
        int idade = 19;
        double altura = 1.82;
        char inicial = 'D';
        bool ehProgramador = true;

        HelloWorld("Hello, World!!");
        PulaLinha();
        Apresentacao(nome, idade, altura, inicial, ehProgramador);
        PulaLinha();
        OlaUser();
    }
}