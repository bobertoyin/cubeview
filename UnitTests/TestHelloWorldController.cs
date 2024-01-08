namespace UnitTests;

public class TestHelloWorldController
{
    [Fact]
    public void TestGet()
    {
        HelloWorldController controller = new HelloWorldController(Mock.Of<ILogger<HelloWorldController>>());
        HelloWorld expected = new HelloWorld {
            Greeting = "Hello!",
            Name = "Foobar",
        };
        Assert.Equivalent(controller.Get("Foobar"), expected);
    }
}