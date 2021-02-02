#if UNITY_EDITOR
using System.Collections;
using Battle.Views;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Battle.PlayModeTests
{
    public class HeroViewTests
    {
        [UnityTest]
        public IEnumerator WhenUpdatePosition_ThenUpdateTheTransformPosition()
        {
            var heroPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Hero.prefab");
            var heroInstance = Object.Instantiate(heroPrefab);
            var heroView = heroInstance.GetComponent<HeroView>();

            yield return null;
            var expectedPosition = new Vector3(1, 0, 0);
            var initialPosition = heroView.transform.position;
            Assert.AreNotEqual(expectedPosition, initialPosition);

            heroView.UpdatePosition(expectedPosition);

            var currentPosition = heroView.transform.position;
            Assert.AreEqual(expectedPosition, currentPosition);
        }
    }
}
#endif
