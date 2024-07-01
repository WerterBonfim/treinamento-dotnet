namespace BucketCliente;

public class Bucket
{
    private int _quantidade = 100;
    private readonly List<string> _numerosValidos =
    [
        "123",
        "456",
        "789"
    ];


    public ResultadoDaConsuta RealizarConsulta(string numero)
    {
        if (string.IsNullOrEmpty(numero))
            return new ResultadoDaConsuta(false, _quantidade, "Numero informado é inválido");

        //  Sem saldo
        if (_quantidade == 0)
            return new ResultadoDaConsuta(false, _quantidade, "Você não tem mais saldo para realizar consultas");


        // Numero informado é inválido
        var numeroInvalido = !_numerosValidos.Contains(numero);
        if (numeroInvalido)
        {
            _quantidade -= 10;
            return new(false, _quantidade, "Numero informado não existe");
        }

        // Significa que tem saldo, removo somente uma ficha
        _quantidade -= 1;

        // Simula uma consulta        
        return new(true, _quantidade, "Consulta realizada com sucesso");

    }


    // No futuro iremos implementar uma simulação do incremento de quantidade.
    

}

public sealed record ResultadoDaConsuta(bool Sucesso, int Saldo, string Mensagem)
{
    public override string ToString() 
        => $"Mensagem: {Mensagem} Seu saldo: {Saldo}.";
}