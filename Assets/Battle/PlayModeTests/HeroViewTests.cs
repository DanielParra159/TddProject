#if UNITY_EDITOR
using System.Collections;
using Battle.InterfaceAdapters;
using Battle.Tests.Factories;
using Battle.UseCases;
using Battle.Views;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using Input = Battle.Utilities.Input;

namespace Battle.PlayModeTests
{
    public class HeroViewTests
    {
        private HeroView heroView;
        private Input input;

        [SetUp]
        public void SetUp()
        {
            input = Substitute.For<Input>();

            var heroPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Hero.prefab");
            var heroInstance = Object.Instantiate(heroPrefab);
            heroView = heroInstance.GetComponent<HeroView>();

            var map = MapFactory.AMap.Build();
            var hero = new HeroSpawner().CreateHero(map, 0, 0);
            var heroMovement = new HeroMovement(hero, map);
            var movementController = new MovementController(heroView, heroMovement);
            heroView.Configure(input, movementController);
        }

        [UnityTest]
        public IEnumerator WhenUpdatePosition_ThenUpdateTheTransformPosition()
        {
            yield return null;
            var expectedPosition = new Vector3(1, 0, 0);
            var initialPosition = heroView.transform.position;
            Assert.AreNotEqual(expectedPosition, initialPosition);

            heroView.UpdatePosition(expectedPosition);

            var currentPosition = heroView.transform.position;
            Assert.AreEqual(expectedPosition, currentPosition);
        }

        [UnityTest]
        public IEnumerator WhenReadTheInput_ThenUpdateTheFinalPosition()
        {
            var expectedPosition = new Vector3(1, 1, 0);
            var initialPosition = heroView.transform.position;

            Assert.AreNotEqual(new Vector3(1, 0, 0), initialPosition);
            input.GetAxis("Horizontal").Returns(1.0f);
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(new Vector3(1, 0, 0), heroView.transform.position);
            input.GetAxis("Horizontal").Returns(0.0f);
            yield return new WaitForFixedUpdate();
            Assert.AreNotEqual(expectedPosition, heroView.transform.position);
            input.GetAxis("Vertical").Returns(1.0f);
            yield return new WaitForFixedUpdate();
            input.GetAxis("Vertical").Returns(0.0f);
            yield return new WaitForFixedUpdate();
            
            var currentPosition = heroView.transform.position;
            Assert.AreEqual(expectedPosition, currentPosition);
        }
    }
}
#endif
