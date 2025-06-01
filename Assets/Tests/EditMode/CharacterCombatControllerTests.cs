using NUnit.Framework;
using UnityEngine;
using Characters.Scripts;
using System.Reflection;
using CommonCollision.Data;
using CommonCollision.Scripts;

namespace Tests.EditMode
{
    public class CharacterCombatControllerTests
    {
        private class FakeHitboxFactory : IHitboxFactory
        {
            public IHitbox CreateHitbox(HitboxInfo info, Vector2 spawnPosition, Transform parent)
            {
                return null;
            }
        }

        [Test]
        public void CharacterCombatController_HoldsReferenceToInterface_Only()
        {
            var fake = new FakeHitboxFactory();
            var go = new GameObject("CharacterCombatController");
            go.AddComponent<Animator>();
            var controller = go.AddComponent<CharacterCombatController>();


            typeof(CharacterCombatController)
                .GetField("_hitboxFactory", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(controller, fake);

            
            var fieldValue = typeof(CharacterCombatController)
                .GetField("_hitboxFactory", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(controller);

            
            Assert.IsNotNull(fieldValue);
            Assert.IsInstanceOf<IHitboxFactory>(fieldValue);
        }
    }
}