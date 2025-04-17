using NUnit.Framework;
using UnityEngine;
using CommonScene;
using GameCore;
using System.Reflection;

namespace Tests.EditMode
{
    public class GameCoreTests
    {
        private class FakeSceneServiceProvider : ISceneSPI
        {
            public string GetSceneName() => "FakeScene";
        }

        [Test]
        public void GameCore_HoldsReferenceToInterface_Only()
        {
            var fake = new FakeSceneServiceProvider();

            var go = new GameObject("GameCore");
            var core = go.AddComponent<GameCore.GameCore>();


            typeof(GameCore.GameCore)
                .GetField("_sceneMainMenu", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(core, fake);

 
            var fieldValue = typeof(GameCore.GameCore)
                .GetField("_sceneMainMenu", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(core);


            Assert.IsNotNull(fieldValue);
            Assert.IsInstanceOf<ISceneSPI>(fieldValue);
        }
    }
}