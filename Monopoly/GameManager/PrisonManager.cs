using System;

namespace Monopoly.GameManager
{
    public class PrisonManager
    {
        private bool InPrison { get; set; }

        public void Punishment()
        {
            if (InPrison)
            {
                Console.WriteLine("You're in prison. You have to skip a round");
            }
        }
    }
}