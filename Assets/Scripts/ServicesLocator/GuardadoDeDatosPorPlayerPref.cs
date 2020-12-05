using ServiceLocator;
using UnityEngine;

public class GuardadoDeDatosPorPlayerPref : IObtenerData, IGuardarData
{
    public bool GetBoolData(string key)
    {
        return GetIntData(key) == 1;
    }

    public float GetFloatData(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public int GetIntData(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public string GetStringData(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public void SetBoolData(string key, bool value)
    {
        SetIntData(key, value ? 1 : 0);
    }

    public void SetFloatData(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SetIntData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SetStringData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
}