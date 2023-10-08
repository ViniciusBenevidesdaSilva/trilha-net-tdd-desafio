using trilha_net_tdd_desafio;

namespace trilha_net_tdd_desafio_teste
{
    public class CalculadoraUnitTest
    {
        public Calculadora ConstruirClasseCalculadora()
        {
            Calculadora calculadora = new Calculadora(DateTime.Today.ToShortDateString());
            return calculadora;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            int resultadoCalculadora = calculadora.Somar(val1, val2);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            int resultadoCalculadora = calculadora.Subtrair(val1, val2);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            int resultadoCalculadora = calculadora.Multiplicar(val1, val2);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int val1, int val2, int resultadoEsperado)
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            int resultadoCalculadora = calculadora.Dividir(val1, val2);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Fact]
        public void TesteDivisaoPorZero()
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            Assert.Throws<DivideByZeroException>(
                () => calculadora.Dividir(3, 0)
            );
        }

        [Fact]
        public void TestarHistoricoPreenchido()
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            List<string> resultadoEsperado = new List<string>()
            {
                $"Res: 4 - Data: {DateTime.Today.ToShortDateString()}",
                $"Res: 21 - Data: {DateTime.Today.ToShortDateString()}",
                $"Res: 10 - Data: {DateTime.Today.ToShortDateString()}"
            };

            calculadora.Somar(1, 2);
            calculadora.Somar(2, 8);
            calculadora.Multiplicar(3, 7);
            calculadora.Dividir(4, 1);

            var resultadoCalculadora = calculadora.Historico();

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }

        [Fact]
        public void TestarHistoricoIncompleto()
        {
            Calculadora calculadora = ConstruirClasseCalculadora();

            List<string> resultadoEsperado = new List<string>()
            {
                $"Res: 4 - Data: {DateTime.Today.ToShortDateString()}"
            };

            calculadora.Multiplicar(4, 1);

            var resultadoCalculadora = calculadora.Historico();

            Assert.Equal(resultadoEsperado, resultadoCalculadora);
        }
    }
}