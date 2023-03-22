using System.Reflection;

namespace Task1.Quest1.Test;

using Quest1;

public class RevolverTest
{
    private readonly Revolver _revolver;
    
    public RevolverTest()
    {
        _revolver = new Revolver();
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBullets))]
    public void AddBulletAcceptCorrectArrayInnerEqual(int[] bullets)
    {
        _revolver.AddBullet(bullets);
        
        var expectedInnerArray = new int[6];
        Array.Copy(bullets, expectedInnerArray, bullets.Length);

        var innerArray = ExtractInnerClip();

        Assert.Equal(expectedInnerArray, innerArray);
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBullets))]
    public void AddBulletAcceptCorrectArrayNotEmpty(int[] bullets)
    {
        var result = _revolver.AddBullet(bullets);

        Assert.True(result);
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBullets))]
    public void AddBulletAcceptCorrectArrayPointerTargetLastElement(int[] bullets)
    {
        _revolver.AddBullet(bullets);

        Assert.Equal(bullets.Length - 1, _revolver.pointer);
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBulletsWithToString))]
    public void AddBulletAcceptCorrectArrayToString(int[] bullets, string expected)
    {
        _revolver.AddBullet(bullets);
        Assert.Equal(expected, _revolver.ToString());
    }

    [Theory]
    [MemberData(nameof(GetExtraBullets))]
    public void AddBulletAcceptExtraArrayInnerEqual(int[] bullets)
    {
        _revolver.AddBullet(bullets);
        
        var expectedInnerArray = new int[6];
        Array.Copy(bullets, expectedInnerArray, 6);

        var innerArray = ExtractInnerClip();

        Assert.Equal(expectedInnerArray, innerArray);
    }
    
    [Theory]
    [MemberData(nameof(GetExtraBullets))]
    public void AddBulletAcceptExtraArrayNotEmpty(int[] bullets)
    {
        var result = _revolver.AddBullet(bullets);

        Assert.True(result);
    }
    
    [Theory]
    [MemberData(nameof(GetExtraBullets))]
    public void AddBulletAcceptExtraArrayPointerTargetLastElement(int[] bullets)
    {
        _revolver.AddBullet(bullets);

        Assert.Equal(5, _revolver.pointer);
    }
    
    [Theory]
    [MemberData(nameof(GetExtraBulletsWithToString))]
    public void AddBulletAcceptExtraArrayToString(int[] bullets, string expected)
    {
        _revolver.AddBullet(bullets);
        Assert.Equal(expected, _revolver.ToString());
    }
    
    [Fact]
    public void AddBulletEmptyCollection()
    {
        var result = _revolver.AddBullet(Array.Empty<int>());
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddBulletEmptyCollectionToString()
    {
        _revolver.AddBullet(Array.Empty<int>());
        
        Assert.Equal("0 0 0 0 0 0", _revolver.ToString());
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBulletsWithRemovedLatestWithPointer))]
    public void CorrectArrayShootRemovesBullet(int[] bullets, int pointer)
    {
        _revolver.AddBullet(bullets);
        
        _revolver.shoot();
        
        Assert.Equal(pointer, _revolver.pointer);
    }
    
    [Theory]
    [MemberData(nameof(GetCorrectBulletsWithRemovedLatestToString))]
    public void CorrectArrayShootRemovesBulletToString(int[] bullets, string expected)
    {
        _revolver.AddBullet(bullets);
        
        _revolver.shoot();
        
        Assert.Equal(expected, _revolver.ToString());
    }

    public static IEnumerable<object[]> GetCorrectBullets()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3 } };
        yield return new object[] { new[] { 10, 17 } };
    }
    
    public static IEnumerable<object[]> GetCorrectBulletsWithToString()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3 }, "3 54 7 2 56 4"  };
        yield return new object[] { new[] { 10, 17 }, "17 0 0 0 0 10" };
    }

    public static IEnumerable<object[]> GetExtraBullets()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3, 1 } };
    }
    
    public static IEnumerable<object[]> GetExtraBulletsWithToString()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3, 1 }, "3 54 7 2 56 4" };
    }
    
    public static IEnumerable<object[]> GetCorrectBulletsWithRemovedLatestToString()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3 }, new[] { 54, 7, 2, 56, 4, 0 } };
        yield return new object[] { new[] { 12, 3 }, new[] { 0, 0, 0, 0, 12, 0 } };
        yield return new object[] { new[] { 12, 3, 7 }, new[] { 0, 0, 0, 12, 3, 0 } };
    }
    
    public static IEnumerable<object[]> GetCorrectBulletsWithRemovedLatestWithPointer()
    {
        yield return new object[] { new[] { 54, 7, 2, 56, 4, 3 }, 0 };
        yield return new object[] { new[] { 12, 3 }, 2 };
        yield return new object[] { new[] { 12, 3, 7 }, 3 };
    }

    private int[] ExtractInnerClip()
    {
        var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        return (int[])typeof(Revolver).GetField("clip", bindFlags).GetValue(_revolver);
    }
}