namespace ServiceLocator
{
    public interface IFacadeJsonUtility
    {
        T FromJson<T>(string jsonString);
        string ToJson(object objects);
    }
}