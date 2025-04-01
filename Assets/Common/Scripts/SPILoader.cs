using Zenject;
using UnityEngine;

namespace Common.Scripts
{
    public static class SPILoader
    {
        public static void LoadAndBindAll<TSPI>(DiContainer container, string path)
        {
            var assets = Resources.LoadAll<SPILoaderBase>(path);

            foreach (var asset in assets)
            {
                var result = asset.CreateAndBind(container);

                if (result is TSPI spi)
                {
                    Debug.Log($"[SPILoader] Bound {typeof(TSPI).Name} -> {spi.GetType().Name}");
                }
                else
                {
                    Debug.LogWarning($"[SPILoader] Asset {asset.name} did not return {typeof(TSPI).Name}");
                }
            }
        }
    }
}