using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program 
{
    // Tamanho limite
    const int largura = 20;
    const int altura = 20;

    // Direções que a cobrinha pode ir
    enum Direcao { Cima, Baixo, Esquerda, Direita }
    static Direcao direcaoAtual = Direcao.Direita;

    // Corpo da cobrinha
    static List<(int x, int y)> cobra = new List<(int x, int y)> { (10, 10) };

    // Posição da comidinha (0 o)
    static (int x, int y) comida = (15, 10);

    // Var pra verifica se o jogo ta rodando, acho que o nome deixa claro né
    static bool jogoRodando = true;

    static void Desenhar()
    {
        Console.Clear();

        // Desenha o tabuleiro
        for(int y = 0; y < altura; y++)
        {
            for(int x = 0; x < largura; x++)
            {
                if(cobra.Contains((x, y)))
                    Console.Write("O"); // Desenha o cobrinha
                else if(comida == (x, y))
                    Console.Write("*"); // Desenha a comidinha (0 o)
                else
                    Console.Write(" "); // Se ta vazio é pq faz nada ne? 
            }
            Console.WriteLine();
        }
    }

    static void ControleDeEntrada()
    {
        // Lê a entrada do usuário e altera a direção da cobra
        if (Console.KeyAvailable)
        {
            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.UpArrow:
                    if (direcaoAtual != Direcao.Baixo)
                        direcaoAtual = Direcao.Cima;
                    break;
                case ConsoleKey.DownArrow:
                    if (direcaoAtual != Direcao.Cima)
                        direcaoAtual = Direcao.Baixo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direcaoAtual != Direcao.Direita)
                        direcaoAtual = Direcao.Esquerda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direcaoAtual != Direcao.Esquerda)
                        direcaoAtual = Direcao.Direita;
                    break;
            }
        }
    }

    static void Atualizar()
    {
        // Calcula a nova posição da cabeça da cobra
        var cabecaAtual = cobra.First();
        (int x, int y) novaCabeca = cabecaAtual;

        switch (direcaoAtual)
        {
            case Direcao.Cima: novaCabeca.y--; break;
            case Direcao.Baixo: novaCabeca.y++; break;
            case Direcao.Esquerda: novaCabeca.x--; break;
            case Direcao.Direita: novaCabeca.x++; break;
        }

        // Verifica colisões
        if (novaCabeca.x < 0 || novaCabeca.x >= largura || novaCabeca.y < 0 || novaCabeca.y >= altura || cobra.Contains(novaCabeca))
        {
            jogoRodando = false;
            return;
        }

        // Adiciona a nova cabeça
        cobra.Insert(0, novaCabeca);

        // Verifica se a cobra comeu a comida
        if (novaCabeca == comida)
        {
            // Coloca comida em nova posição
            Random random = new Random();
            comida = (random.Next(0, largura), random.Next(0, altura));
        }
        else
        {
            // Remove a última parte da cobra
            cobra.RemoveAt(cobra.Count - 1);
        }
    }

    static void Main(string[] args)
    {
        // Configs iniciais
        Console.CursorVisible = false;

        // Loop que faz o fica rodando

        while(jogoRodando)
        {
            Desenhar();
            ControleDeEntrada();
            Atualizar();
            Thread.Sleep(300); // Controle da velocidade do jogo
        }

        Console.SetCursorPosition(0, altura + 1);
        Console.WriteLine("Fim de jogo! Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}
