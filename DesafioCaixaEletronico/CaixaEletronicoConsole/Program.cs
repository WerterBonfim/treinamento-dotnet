using CaixaEletronicoConsole;
using System.Globalization;



var caixa = new CaixaEletronico();
caixa.IniciarSessao();


public class CaixaEletronico
{
    private readonly ContaBancaria _conta = new();

    public void IniciarSessao()
    {
        Console.WriteLine("Bem-vindo ao Caixa Eletrônico!");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Ver Saldo");
            Console.WriteLine("2. Depositar Dinheiro");
            Console.WriteLine("3. Sacar Dinheiro");
            Console.WriteLine("4. Sair");
            Console.Write("Digite a opção: ");
           
            var opcao = ObterOpcaoDoUsuario(Console.ReadLine());
            Console.Clear();
      

            switch (opcao)
            {
                case Opcao.OpcaoInvalida:
                    NotificarOpcaoInvalida();
                    break;

                case Opcao.VerSaldo:
                    VerSaldo();
                    break;

                case Opcao.Depositar:
                    Depositar();
                    break;

                case Opcao.Sacar:
                    Sacar();
                    break;

                case Opcao.Sair:
                    Sair();
                    break;

                default:
                    break;
            }
        }

    }


    private void VerSaldo() =>
        Console.WriteLine($"Seu saldo atual é: {_conta.VerificarSaldo():C}");

    private void Depositar()
    {
        Console.Write("Digite o valor para depósito: ");
        if (TentaObterValorValido(out decimal valor))
        {
            _conta.Depositar(valor);
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso.");
        }
    }

    private void Sacar()
    {
        Console.Write("Digite o valor para saque: ");
        if (TentaObterValorValido(out decimal valor))
        {
            if (_conta.Sacar(valor))
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso.");
            else
                Console.WriteLine("Saldo insuficiente para realizar o saque.");
        }
    }

    private void NotificarOpcaoInvalida() => Console.WriteLine("Opção informada é inválida");

    private void Sair()
    {
        Console.WriteLine("Fim");
        Thread.Sleep(TimeSpan.FromSeconds(3));
        Environment.Exit(0);
    }

    private static bool TentaObterValorValido(out decimal valor)
    {
        var conseguiuConverter = decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.CurrentCulture, out valor);
        if (conseguiuConverter && valor > 0)
            return true;

        Console.WriteLine("Valor inválido. Por favor, digite um número positivo.");
        return false;
    }

    public Opcao ObterOpcaoDoUsuario(string? valorDigitado)
    {
        var opcao = Opcao.OpcaoInvalida;
        Enum.TryParse(valorDigitado, true, out opcao);
        return opcao;
    }
}