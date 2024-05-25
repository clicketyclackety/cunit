namespace cunit.tests;

public class Nullablity
{

    [Test]
    public void Nulls()
    {
        Meter? m = 200;
        Assert.True(m.HasValue);
        Assert.True(m.Value.Equals(200));

        m = null;
        Assert.False(m.HasValue);
        Assert.Null(m);
    }

}
