namespace ServiceLocator
{
    public interface IGuardarData
    {
        void SetStringData(string key, string value);
        void SetIntData(string key, int value);
        void SetFloatData(string key, float value);
        void SetBoolData(string key, bool value);
    }
}
