namespace ServiceLocator
{
    public interface IFacadeJsonUtility<T>
    {
        T FromJson(string jsonString);
    }
}