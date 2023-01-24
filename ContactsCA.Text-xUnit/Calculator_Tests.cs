using ContactsCA.services;

namespace ContactsCA.Text_xUnit
{
    public class Calculator_Tests
    {
        private Calculator calculator;

        public Calculator_Tests()
        {
            //arrange
            calculator = new Calculator();
            calculator.Total = 0;
        }

        [Fact]
        public void Should_Add_GivenNumber_To_Total()
        {
            //act
            calculator.Add(100);

            //assert
            Assert.Equal(100, calculator.Total);
        }

        public void Should_Subtract_GivenNumber_From_Total()
        {
            //act
            calculator.Subtract(100);

            //assert
            Assert.Equal(-100, calculator.Total);
        }

        [Theory]
        [InlineData(0.1, 0.1, 0.1, 0.3)]
        [InlineData(1, 2, 3, 6)]
        [InlineData(10, 20, 0.5, 30.5)]
        public void Should_Add_Three_GivenNumbers_To_Total(decimal v1, decimal v2, decimal v3, decimal expected)
        {
            // act
            calculator.Add(v1);
            calculator.Add(v2);
            calculator.Add(v3);

            // assert
            Assert.Equal(expected, calculator.Total);
        }

        public static IEnumerable<object[]> testValues()
        {
            yield return new object[] { 0.3m, new decimal[] { 0.1m, 0.1m, 0.1m } };
            yield return new object[] { 6, new decimal[] { 1, 2, 3 } };
            yield return new object[] { 30.5, new decimal[] { 10, 20, 0.5m } };
            yield return new object[] { 10, new decimal[] { 5, 5 } };
            yield return new object[] { 0, new decimal[] { 10, -10 } };
        }

        [Theory]
        [MemberData(nameof(testValues))]
        public void Add_MultipleNumbers_To_Total(decimal expected, params decimal[] values)
        {
            foreach (decimal value in values)
                calculator.Add(value);

            Assert.Equal(expected, calculator.Total);
        }
    }
}