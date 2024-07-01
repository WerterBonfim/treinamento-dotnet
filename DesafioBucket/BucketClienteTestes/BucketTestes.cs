using BucketCliente;

namespace BucketClienteTestes;

public class BucketTestes
{
    [Fact(DisplayName = "Deve notificar sucesso ao realizar um consulta, pois o numero existe")]
    [Trait("Bucket", "RealizarConsulta")]
    public void RealizarConsulta_Com100BuckentDeveConsultaComSucesso()
    {
        var bucket = new Bucket();

        var resultado = bucket.RealizarConsulta("123");

        Assert.NotNull(resultado);
        Assert.True(resultado.Sucesso, "Deveria ter consultado com sucesso");
        Assert.Equal(99, resultado.Saldo);
    }

    [Fact(DisplayName = "Deve notificar falha ao realizar um consulta, numero não existe")]
    [Trait("Bucket", "RealizarConsulta")]
    public void RealizarConsulta_Com100BucketsDeveNotificarFalha_NumeroNaoExiste()
    {
        var bucket = new Bucket();

        var resultado = bucket.RealizarConsulta("000");

        Assert.NotNull(resultado);
        Assert.False(resultado.Sucesso, "Deveria ter consultado com sucesso");
        Assert.Equal(90, resultado.Saldo);
    }
}