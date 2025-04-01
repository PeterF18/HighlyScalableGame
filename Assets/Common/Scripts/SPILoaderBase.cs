using UnityEngine;
using Zenject;

namespace Common.Scripts
{
    public abstract class SPILoaderBase : ScriptableObject
    {
        public abstract object CreateAndBind(DiContainer container);
    }
}