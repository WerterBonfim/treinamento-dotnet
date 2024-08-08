namespace CaixaEletronicoConsole;

public class ContaBancaria
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor) => Saldo += valor;

    public bool Sacar(decimal valor)
    {
        if (valor > Saldo) return false;
        Saldo -= valor;
        return true;
    }

    public decimal VerificarSaldo() => Saldo;
}
