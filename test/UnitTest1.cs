using Xunit;

namespace test;

public class UnitTest1
{
    // Tests probably do not cover all edge cases
    // Test voor je verbeterd

    [Theory]
    [InlineData(17)] // Case level 0
    [InlineData(9)] // Case level 1
    [InlineData(27)] // Case level 2
    [InlineData(35)] // Case level 3
    public void TestFindIntFound(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Find(value);
    
        // Then
        Assert.Equal("Found", result.Message);
    }

    [Theory]
    [InlineData(16)] 
    [InlineData(32)]
    [InlineData(32)]
    [InlineData(5000)] // Case big number
    public void TestFindIntNotFound(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Find(value);
    
        // Then
        Assert.Equal("Not found", result.Message);
    }

    [Theory]
    [InlineData(32)] // Case When it has to be added to right
    [InlineData(47)] // Case When it has to be added to left
    [InlineData(-8)] // Case negative number 
    [InlineData(29)] // Case when parent already has one child 
    public void TestAddSucces(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Add(value);
        var result2 = sut.Find(value);
    
        // Then
        Assert.Equal("Added", result.Message);
        Assert.Equal("Found", result2.Message);
    }

    [Theory]
    [InlineData(17)] // Case root
    [InlineData(9)] // Case child is left
    [InlineData(27)] 
    [InlineData(50)] // Case child is right
    public void TestAddAlreadyInTree(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Add(value);
        var result2 = sut.Find(value);
    
        // Then
        Assert.Equal("Value already in tree", result.Message);
        Assert.Equal("Found", result2.Message);
    }

    [Theory]
    [InlineData(1)] // Case child is left
    [InlineData(5)] // Case child is right
    [InlineData(21)] // Case child is only child left
    [InlineData(50)] // Case child is only child right
    public void TestRemoveNoChildrenSucces(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Remove(value);
        var result2 = sut.Find(value);
    
        // Then
        Assert.Equal("Removed", result.Message);
        Assert.Equal("Not found", result2.Message);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(15)]
    [InlineData(500)]
    [InlineData(16)]
    public void TestRemoveNotFound(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Remove(value);
        var result2 = sut.Find(value);
    
        // Then
        Assert.Equal("Not found", result.Message);
        Assert.Equal("Not found", result2.Message);
    }

    [Theory]
    [InlineData(27)] // Case child is left
    [InlineData(13)] // Case child is right 
    public void TestRemoveOneChild(int value)
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Remove(value);
        var result2 = sut.Find(value);
        
    
        // Then
        Assert.Equal("Removed", result.Message);
        Assert.Equal("Not found", result2.Message);
        Assert.Equal("Found", sut.Find(14).Message);
        Assert.Equal("Found", sut.Find(21).Message);
    }

    [Theory]
    [InlineData(4)] // Case node is on the second to last level
    [InlineData(42)] 
    [InlineData(9)]
    [InlineData(30)]
    public void TestRemoveTwoChildren(int value)
    {
        // Given
        var sut = Data.GenerateTree();;
    
        // When
        var result = sut.Remove(value);
        var result2 = sut.Find(value);
        
    
        // Then
        Assert.Equal("Removed", result.Message);
        Assert.Equal("Not found", result2.Message);
        Assert.Equal("Found", sut.Find(14).Message);
        Assert.Equal("Found", sut.Find(21).Message);
        Assert.Equal("Found", sut.Find(35).Message);
        Assert.Equal("Found", sut.Find(50).Message);
    }

    [Fact]
    public void RemoveRoot()
    {
        // Given
        var sut = Data.GenerateTree();

        // When
        var result = sut.Remove(17);
        var result2 = sut.Find(17);
    
        // Then
        Assert.Equal("Removed", result.Message);
        Assert.Equal("Not found", result2.Message);
        Assert.Equal("Found", sut.Find(13).Message);
        Assert.Equal("Found", sut.Find(21).Message);
        Assert.Equal("Found", sut.Find(35).Message);
        Assert.Equal("Found", sut.Find(50).Message);
    }


    [Fact]
    public void TestGetNotFound()
    {
        // Given
        var sut = Data.GenerateTree();

        // When
        var result = sut.Get(3, 5);

        // Then
        Assert.Equal("Not found", result.Message);
    }

    [Fact]
    public void TestGetNode()
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Get(3, 1);
    
        // Then
        Assert.Equal(5, result.Result.Value);
    }


    [Fact]
    public void TestGetRoot()
    {
        // Given
        var sut = Data.GenerateTree();
    
        // When
        var result = sut.Get(0, 0);
    
        // Then
        Assert.Equal(17, result.Result.Value);
    }
}