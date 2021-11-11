using System;
using Monopoly.Flyweight;

namespace Monopoly.GameManager
{
    public class PrisonManager
    {
        //TODO Hente spiller-index fra boardmap for å sjekke om spiller er på fengsel-index
        private bool InPrison { get; }

        public PrisonManager(bool inPrison, Player player)
        {
            InPrison = inPrison;
            
        }
        
        public void Punishment()
        {
            if (Player.InPrison)
            {
                Console.WriteLine("You're in prison. You have to skip a round");
            }
        }
    }
}