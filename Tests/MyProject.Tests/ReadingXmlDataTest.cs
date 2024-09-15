using Xunit;
using FluentAssertions;
using AutoFixture;
using WeatherMonotring;
public class ReadingXmlDataTestShould{
    private readonly Fixture _fixture;
    public ReadingXmlDataTestShould(){
        _fixture = new Fixture();
    }
    [Fact]
    public void setXmlString(){
        //Arrange
        var xmlString = _fixture.Create<string>();
        //Act
        var readingXmlData = new ReadingXmlData(xmlString);
        //Assert
        readingXmlData.XmlString.Should().Be(xmlString);
    }
    [Fact]
    public void ThrowNotImplementedExceptionWhenReadingDataIsCalled(){
        //Arrange
        var readingXmlData = new ReadingXmlData(_fixture.Create<string>());
        //Act
        Action action= () => ((IReadingData)readingXmlData).ReadingData();
        //Assert
        action.Should().Throw<NotImplementedException>();
    }
}