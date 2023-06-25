#region JOGO ACERTE O NUMERO
/*
Random aleatorio = new Random();
int numeroSecreto = aleatorio.Next(1, 101);

do
{
    Console.Write("Digite um número entre 1 e 100: ");
    int chute = int.Parse(Console.ReadLine()!);

    if (chute == numeroSecreto)
    {
        Console.WriteLine("Parabéns! Você acertou o número.");
        break;
    }
    else if (chute < numeroSecreto)
    {
        Console.WriteLine("O número é maior.");
    }
    else
    {
        Console.WriteLine("O número é menor.");
    }

} while (true);
*/
#endregion



Dictionary<string, List<int>> listaBandas = new Dictionary<string, List<int>> {
    { "The Beatles", new List<int>() },
    { "AC/DC", new List<int>{ 8, 9, 7 } },
    { "Terno Rei", new List<int>{ 10, 8 } },
    { "Bentivi", new List<int>{ 10 } },
    { "Guns 'n Roses", new List<int>{ 10, 9, 7, 10 } },
};

//MÉTODOS
void ExibirMenu()
{
    Console.WriteLine(@"
        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine("Seja bem vindo\n");

    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    try
    {
        Console.Write("Digite uma opação: ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);

        Console.WriteLine();

        switch (opcaoEscolhida)
        {
            case 1:  RegistrarBanda();
                break;
            case 2: ExibirBandas();
                break;
            case 3: AvaliarBanda();
                break;
            case 4: MediaNotasbanda();
                break;
            case 0:
                Console.WriteLine("Sessão Encerrada");
                Console.Clear();
                break;
        }
    }
    catch(FormatException)
    {
        Console.WriteLine("Opção Inválida");
    }

    Console.WriteLine();
}

void CabecalhoOpcoes(string str)
{
    Console.Clear();
    Console.WriteLine(str);
    Console.WriteLine("Caso deseje voltar, didite 0.\n");
}

void Voltar(int time)
{
    Thread.Sleep(time);
    Console.Clear();
    ExibirMenu();
}

void RegistrarBanda()
{
    CabecalhoOpcoes(@"
        ░█▀▀█ █▀▀ █▀▀▀ ─▀─ █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█▄▄▀ █▀▀ █─▀█ ▀█▀ ▀▀█ ──█── █▄▄▀ █──█ 　 █──█ █▀▀ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█─░█ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀ ──▀── ▀─▀▀ ▀▀▀▀ 　 ▀▀▀─ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine();

    if(String.IsNullOrEmpty(nomeBanda))
    {
        Console.WriteLine("Opção inválida");
    }
    else if(nomeBanda == "0")
    {
        Voltar(200);
    }
    else
    {
        listaBandas.Add(nomeBanda, new List<int>());
        Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
        Console.WriteLine("\nClique qualquer tecla para voltar.");
        Console.ReadLine();
    }
    
    Voltar(200);
}

void ExibirBandas()
{
    Console.Clear();
    Console.WriteLine(@"
        ░█─── ─▀─ █▀▀ ▀▀█▀▀ █▀▀█ 　 █▀▀▄ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█─── ▀█▀ ▀▀█ ──█── █▄▄█ 　 █──█ █▀▀ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█▄▄█ ▀▀▀ ▀▀▀ ──▀── ▀──▀ 　 ▀▀▀─ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    
    ");

    int i = 1;
    foreach(string x in listaBandas.Keys){
        Console.WriteLine($"Banda {i}: {x}");
        i++;
    }
    
    Console.WriteLine("\nClique qualquer tecla para voltar!");
    Console.ReadLine();
    Voltar(200);
}

void AvaliarBanda()
{
    CabecalhoOpcoes(@"
        ─█▀▀█ ▀█─█▀ █▀▀█ █── ─▀─ █▀▀█ █▀▀█ 　 ░█▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█▄▄█ ─█▄█─ █▄▄█ █── ▀█▀ █▄▄█ █▄▄▀ 　 ░█▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█─░█ ──▀── ▀──▀ ▀▀▀ ▀▀▀ ▀──▀ ▀─▀▀ 　 ░█▄▄█ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    if (String.IsNullOrEmpty(nomeBanda))
    {
        Console.WriteLine("Opção inválida");
        Voltar(1500);
    }
    else if (nomeBanda == "0")
    {
        Voltar(200);
    }
    else
    {
        if (listaBandas.ContainsKey(nomeBanda))
        {
            Console.Write("Digite a nota: ");
            int nota = int.Parse(Console.ReadLine()!);

            listaBandas[nomeBanda].Add(nota);
            Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeBanda} com sucesso!");
            Console.WriteLine("\nClique qualquer tecla para voltar.");
            Console.ReadLine();
        }
    }

    Voltar(200);
}

void MediaNotasbanda()
{
    CabecalhoOpcoes(@"     
        ░█▀▄▀█ █▀▀ █▀▀▄ ─▀─ █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
        ░█░█░█ █▀▀ █──█ ▀█▀ █▄▄█ 　 █──█ █▄▄█ ▀▀█ 　 █▀▀▄ █▄▄█ █──█ █──█ █▄▄█ ▀▀█ 
        ░█──░█ ▀▀▀ ▀▀▀─ ▀▀▀ ▀──▀ 　 ▀▀▀─ ▀──▀ ▀▀▀ 　 ▀▀▀─ ▀──▀ ▀──▀ ▀▀▀─ ▀──▀ ▀▀▀
    ");

    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (String.IsNullOrEmpty(nomeBanda))
    {
        Console.WriteLine("Opção inválida");
        Voltar(1500);
    }
    else if (nomeBanda == "0")
    {
        Voltar(200);
    }
    else
    {
        double media = listaBandas[nomeBanda].Average();
        Console.WriteLine($"A média da banda {nomeBanda} é: {media}");
        Console.WriteLine("\nClique qualquer tecla para voltar.");
        Console.ReadLine();
    }

    Voltar(200);
}

//PROGRAMA
ExibirMenu();

Console.ReadLine();

