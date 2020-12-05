namespace ServiceLocator
{
    public interface IObtenerData
    {
        string GetStringData(string key);
        int GetIntData(string key);
        float GetFloatData(string key);
        bool GetBoolData(string key);
    }

}