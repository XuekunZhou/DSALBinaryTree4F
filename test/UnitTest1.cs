using Xunit;

namespace test;

public class UnitTest1
{
    [Fact]
    public void TestFind()
    {
        // Given
        var sut = Program.GenerateTree();
    
        // When
        var result17 = sut.Find(17);
        var result16 = sut.Find(16);
        var result9 = sut.Find(9);
        var result32 = sut.Find(32);
        var result27 = sut.Find(27);
        var result35= sut.Find(35);
        var result14= sut.Find(14);
    
        // Then
        Assert.Equal("Found", result17.Message);
        Assert.Equal("Not found", result16.Message);
        Assert.Equal("Found", result9.Message);
        Assert.Equal("Not found", result32.Message);
        Assert.Equal("Found", result27.Message);
        Assert.Equal("Found", result35.Message);
        Assert.Equal("Not found", result14.Message);
    }

    [Fact]
    public void TestAdd()
    {
        // Given
        var sut = Program.GenerateTree();

        // When
        var result14 = sut.Add(14);
        var result27 = sut.Add(27);
        var result47 = sut.Add(47);
        var result9 = sut.Add(9);
        var find14 = sut.Find(14);
        var find27 = sut.Find(27);
        var find47 = sut.Find(47);
        var find9 = sut.Find(9);
        var find33 = sut.Find(33);
        
        // Then
        Assert.Equal("Added", result14.Message);
        Assert.Equal("Value already in tree", result27.Message);
        Assert.Equal("Added", result47.Message);
        Assert.Equal("Value already in tree", result9.Message);
        Assert.Equal("Found", find14.Message);
        Assert.Equal("Found", find27.Message);
        Assert.Equal("Found", find47.Message);
        Assert.Equal("Found", find9.Message);
        Assert.Equal("Not found", find33.Message);
    }

    [Fact]
    public void RemoveNoChildren()
    {
        // Given
        var sut = Program.GenerateTree();
    
        // When
        var result1 = sut.Remove(1);
        var result21 = sut.Remove(21);
        var result14 = sut.Remove(14);
        var find1 = sut.Find(1);
        var find21 = sut.Find(21);
    
        // Then
        Assert.Equal("Removed", result1.Message);
        Assert.Equal("Removed", result21.Message);
        Assert.Equal("Not found", result14.Message);
        Assert.Equal("Not found", find1.Message);
        Assert.Equal("Not found", find21.Message);
    }

    [Fact]
    public void RemoveOneChild()
    {
        // Given
        var sut = Program.GenerateTree();
    
        // When
        var result27 = sut.Remove(27);
        var find27 = sut.Find(27);
        var find21 = sut.Find(21);
    
        // Then
        Assert.Equal("Removed", result27.Message);
        Assert.Equal("Not found", find27.Message);
        Assert.Equal("Found", find21.Message);
    }

    [Fact]
    public void RemoveTwoChildren()
    {
        // Given
        var sut = Program.GenerateTree();
    
        // When
        var result30 = sut.Remove(30);
        var find30 = sut.Find(3);
        var find27 = sut.Find(27);
        var find21 = sut.Find(21);
        var find42 = sut.Find(42);
        var find35 = sut.Find(35);
        var find50 = sut.Find(50);
    
    
    
        // Then
        Assert.Equal("Removed", result30.Message);
        Assert.Equal("Not found", find30.Message);
        Assert.Equal("Found", find27.Message);
        Assert.Equal("Found", find21.Message);
        Assert.Equal("Found", find42.Message);
        Assert.Equal("Found", find35.Message);
        Assert.Equal("Found", find50.Message);
    }

    [Fact]
    public void RemoveRoot()
    {
        // Given
        var sut = Program.GenerateTree();

        // When
        var result = sut.Remove(17);
        var find11 = sut.Find(11);
        var find50 = sut.Find(50);
        var find61 = sut.Find(61);
        var find22 = sut.Find(22);
    
        // Then
        Assert.Equal("Removed", result.Message);
        Assert.Equal(21, result.Result.Value);
        Assert.Equal("Found", find11.Message);
        Assert.Equal("Found", find50.Message);
        Assert.Equal("Not found", find61.Message);
        Assert.Equal("Not found", find22.Message);

    }
}