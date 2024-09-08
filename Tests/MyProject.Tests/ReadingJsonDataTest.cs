using Xunit;
using FluentAssertions;
using AutoFixture;
using WeatherMonotring;
public class ReadingJsonDataTestsShould{
    private readonly Fixture _fixture;
    public ReadingJsonDataTestsShould()
    {
        _fixture = new Fixture();
    }
    [Fact]
    public void SetJsonString(){
        //Arrange
        var jsonString = _fixture.Create<string>();
        //Act
        var readingJsonData = new ReadingJsonData(jsonString);
        //Assert
        readingJsonData.JsonString.Should().Be(jsonString);
    }
    [Fact]
    public void ThrowNotImplementedExceptionWhenReadingDataIsCalled(){
        //Arrange
        var readingJsonData = new ReadingJsonData(_fixture.Create<string>());
        //Act
        Action action= () => ((IReadingData)readingJsonData).ReadingData();
        //Assert
        action.Should().Throw<NotImplementedException>();
    }
}