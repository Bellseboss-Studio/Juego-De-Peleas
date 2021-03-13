using UnityEngine;

namespace ServiceLocator
{
    public class FacadeJsonUtility : IFacadeJsonUtility
    {
        public T FromJson<T>(string jsonString)
        {
            return JsonUtility.FromJson<T>(jsonString);
        }

        public string ToJson(object objects)
        {
            return JsonUtility.ToJson(objects);
        }
    }
}