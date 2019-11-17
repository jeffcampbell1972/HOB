using Xunit;
using HOB.Services;

namespace HOB.UnitTests
{
    public class CleaningServiceUnitTests
    {
        private readonly CleaningService _cleaningService;

        public CleaningServiceUnitTests()
        {
            _cleaningService = new CleaningService();
        }

        [Theory]
        [InlineData("this is a test.", "this is a test")]
        [InlineData("this, is a test.", "this is a test")]
        [InlineData("...this, is a test...", "this is a test")]
        [InlineData("this; is; a; test;", "this is a test")]
        [InlineData("this ;  is  .,;       a; test;", "this is a test")]
        [InlineData(@"this ; !@#$%^&*()_\/?.,><~`+=-][ is  .,;       a;          test;", "this is a test")]
        public void CleanText_VerifyResult(string value, string expectedResult)
        {
            var result = _cleaningService.Clean(value);

            Assert.True(result == expectedResult, $"{value} should match {expectedResult}");
        }
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("               ")]
        public void InvalidText_VerifyException(string text)
        {
            bool errorFound = false;
            try
            {
                var cleanedText = _cleaningService.Clean(text);
            }
            catch (InvalidTextException)
            {
                errorFound = true;
            }

            Assert.True(errorFound);
        }
    }
}
