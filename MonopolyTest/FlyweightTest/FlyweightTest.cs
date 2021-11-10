using System;
using Monopoly.Flyweight;
using NUnit.Framework;

namespace MonopolyTest.FlyweightTest
{
    public class FlyweightTest
    {

        [Test]
        public void ShouldDoSomething()
        {
            PlayerGenerator playerGenerator = new();
            Player1 player1 = playerGenerator.Get(1);

            player1.SetExctrinsicPart("Goat");
            Console.WriteLine(player1.Name);
        }
    }
}