using CaixaEletronicoConsole;

namespace DesafioCaixaEletronicoTestes
{
    public class CaixaEletronicoTestes
    {
        [Fact(DisplayName = "Usuario informou a op��o 1 - Ver Saldo")]
        [Trait("CaixaEletronico", "Menu")]
        public void DeveNotificarSucesso_UsuarioDigitouAOpcao1()
        {
            var caixa = new CaixaEletronico();

            var resultadoMenu = caixa.ObterOpcaoDoUsuario("1");

            Assert.Equal(Opcao.VerSaldo, resultadoMenu);
        }

        [Fact(DisplayName ="Usuario informou um menu inv�lido")]
        [Trait("CaixaEletronico", "Menu")]
        public void DeveriaNotificarErroMenuInformadoEInvalido()
        {
            var caixa = new CaixaEletronico();

            var resultadoMenu = caixa.ObterOpcaoDoUsuario("aa");

            Assert.Equal(Opcao.OpcaoInvalida, resultadoMenu);
        }
    }
}