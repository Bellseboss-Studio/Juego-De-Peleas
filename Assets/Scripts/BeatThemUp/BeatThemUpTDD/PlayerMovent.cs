using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovent
    {
        public IPlayerView playerView { get; private set; }
        public LogicPlayerView logic { get; private set; }

        // A Test behaves as an ordinary method
        [TestCase(1, 1, 1, 1)]
        [TestCase(2, 2, 2, 2)]
        [TestCase(-1, -1, -1, -1)]
        [TestCase(-2, -2, -2, -2)]
        [TestCase(2, 2, 2, 2)]
        public void MovementPlayer_updateTheVelocityToMovement(float x, float y, float resultX, float resultY)
        {
            logic.MovePlayer(x, y);

            playerView.Received().Move(resultX, resultY);
        }

        [TestCase(1, 1, false)]
        [TestCase(2, 2, false)]
        [TestCase(-1, -1, true)]
        [TestCase(-2, -2, true)]
        [TestCase(2, 2, false)]
        public void MovementPlayer_CallFlipTheImage(float x, float y, bool fliped)
        {
            logic.MovePlayer(x, y);

            playerView.Received().FlipImage(fliped);
        }

        [SetUp]
        public void SetUp()
        {
            playerView = Substitute.For<IPlayerView>();
            playerView.GetDeltaTime().Returns(1);
            logic = new LogicPlayerView(playerView, 1);

        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 1)]
        [TestCase(-1, -1,1)]
        [TestCase(-2, -2,1)]
        [TestCase(0, 2, 0)]
        public void MovementPlayer_IfNotMoventDontCallFlipTheImage(float x, float y, int countCalls)
        {

            logic.MovePlayer(x, y);

            playerView.Received(countCalls).FlipImage(Arg.Any<bool>());
        }
    }
}
