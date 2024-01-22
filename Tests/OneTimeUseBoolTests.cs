using NUnit.Framework;

namespace PolyhydraGames.Core.Models.Test;

public class OneTimeUseBoolTests
{
    [Test]
    public void OneTimeUseBool()
    {
        var oneTimeUseBool = new OneTimeUseBool();
        Assert.That(oneTimeUseBool.Value);
        Assert.That(!oneTimeUseBool.Value);
    }

}