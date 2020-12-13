using UnityEngine;

namespace ServiceLocator
{
    public class FactoryStats : IFactoryStats
    {
        public StatsBase Create(string name)
        {
            return ReadFileFromStats(name);
        }

        private StatsBase ReadFileFromStats(string name)
        {
            string stringDeEstadisticasGenrales = ServiceLocatorImplement.Instancie.GetService<ISearchFile>().ReadFile(@"debug_" + name + ".txt");
            Debug.Log(stringDeEstadisticasGenrales);
            EstadisticasBasePersonajeDebug estadisticasBase = JsonUtility.FromJson<EstadisticasBasePersonajeDebug>(stringDeEstadisticasGenrales);
            return new StatsBase(estadisticasBase.vida, name);
        }
    }
}