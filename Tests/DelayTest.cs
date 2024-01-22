using System.Diagnostics;
using NUnit.Framework;
using PolyhydraGames.Core.Models.DelayTimer;

namespace PolyhydraGames.Core.Models.Test;

[TestFixture]
public class DelayTest
{

    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public async Task TestNestedExceptions()
    {
        try
        {
            var timer = new DelayedTimer("Test", 5, 5, 15);
            for (var x = 0; x < 5; x++)
            {
                Trace.WriteLine(x);
                await timer.Delay();
            }
        }
        catch (MaximumDurationException ex)
        {
            Assert.Pass(ex.Message);
        }
        Assert.Fail("The error never threw");
    }
}