using System;
using BusinessLogic;
using Moq;
using Xunit;

namespace BusinessLogicTests
{
  public class AddressTests
  {
    [Fact]
    public void EqualAddresses()
    {
      // arrange
      var addressFromApi = new AddressPoco
      {
        Address = "123 main st",
        City = "Baltimore",
        State = "MD",
        Zip = "12345"
      };
      var address = new AddressPoco
      {
        Address = "123 main st",
        City = "Baltimore",
        State = "MD",
        Zip = "12345"
      };

      var addressApiLookup = new Mock<IAddressApiLookup>();
      addressApiLookup.Setup(x => x.Get(1)).Returns(addressFromApi);

      // act
      var checkAddress = new CheckAddress(addressApiLookup.Object);
      var result = checkAddress.IsEqual(1, address);

      //assert
      Assert.True(result);
    }

    [Fact]
    public void DifferentAddresses()
    {
      // arrange
      var addressFromApi = new AddressPoco
      {
        Address = "555 Bridge St",
        City = "Washington",
        State = "DC",
        Zip = "22334"
      };

      var address = new AddressPoco
      {
        Address = "123 main st",
        City = "Baltimore",
        State = "MD",
        Zip = "12345"
      };

      var addressApiLookup = new Mock<IAddressApiLookup>();
      addressApiLookup.Setup(x => x.Get(1)).Returns(addressFromApi);

      // act
      var checkAddress = new CheckAddress(addressApiLookup.Object);
      var result = checkAddress.IsEqual(1, address);

      //assert
      Assert.False(result);
    }

    [Fact]
    public void NoAddressFound()
    {
      // arrange
      var addressFromApi = new AddressPoco
      {
      };

      var address = new AddressPoco
      {
        Address = "123 main st",
        City = "Baltimore",
        State = "MD",
        Zip = "12345"
      };

      var addressApiLookup = new Mock<IAddressApiLookup>();
      addressApiLookup.Setup(x => x.Get(1)).Returns(addressFromApi);

      // act
      var checkAddress = new CheckAddress(addressApiLookup.Object);
      var result = checkAddress.IsEqual(1, address);

      //assert
      Assert.False(result);
    }
  }
}
