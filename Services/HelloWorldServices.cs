namespace webapi.Services
{
  public class HelloWorldServices : IHelloWorldServices
  {
    public string GetHelloWorld()
    {
      return "Hello World XD";
    }
  }
  public interface IHelloWorldServices
  {
    string GetHelloWorld();
  }
}
