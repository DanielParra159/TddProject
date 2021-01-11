using Battle.Entities;
using Battle.Tests.Factories;
using Battle.UseCases;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Battle.Tests
{
    public class MovementControllerTests
    {
        private MovementController _movementController;
        private IHeroMovement _heroMovement;
        private Hero _hero;
        private Map _map;
        private IMovementMotor _movementMotor;

        [SetUp]
        public void SetUp()
        {
            _movementMotor = Substitute.For<IMovementMotor>();
            _heroMovement = Substitute.For<IHeroMovement>();
            _hero = new Hero();
            _map = MapFactory.AMap.Build();

            _movementController = new MovementController(_movementMotor, _heroMovement);
        }

        [TestCase(1, 0, Directions.Right)]
        [TestCase(-1, 0, Directions.Left)]
        [TestCase(0, 1, Directions.Up)]
        [TestCase(0, -1, Directions.Down)]
        [TestCase(1, 1, Directions.Right)]
        [TestCase(-1, 1, Directions.Left)]
        public void WhenCallToMove_ThenCalculateTheCorrectDirection(
            float horizontal, float vertical,
            Directions expectedDirection)
        {
            _heroMovement
               .Move(Arg.Any<Directions>())
               .Returns(new HeroMovementOutputData(0,0));
            _movementController.Move(horizontal, vertical);

            _heroMovement
               .Received(1)
               .Move(expectedDirection);
        }

        [Test]
        public void WhenCallToMoveWithZeroHorizontalAndVertical_ThenDoNotCallToHeroMovement()
        {
            _movementController.Move(0, 0);

            _heroMovement
               .Received(0)
               .Move( Arg.Any<Directions>());
        }

        [Test]
        public void WhenCallToMove_ThenCallToMovementMotorWithTheFinalPosition()
        {
            _heroMovement
               .Move(Arg.Any<Directions>())
               .Returns(new HeroMovementOutputData(1,0));

            _movementController.Move(1, 0);

            var expectedPosition = new Vector3(1, 0, 0);
            _movementMotor.Received(1).UpdatePosition(expectedPosition);
        }
    }
}
