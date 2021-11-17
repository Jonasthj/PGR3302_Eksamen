﻿using System;
using Monopoly.Factory.Classes;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.UI;

namespace Monopoly.Logics.SquareLogics
{
    public class PropertyLogics : AbstractLogics
    {
        private Property _property;

        public override void Handle(ISquare square, int playerId)
        {
            _property = (Property) square;
            Bank bank = new Bank(_property);
            
            ConsoleOutput.Print(square.ToString());

            if (_property.IsAvailable)
            {
                ConsoleOutput.Print("This property is available for purchase!", ConsoleColor.Cyan);
                ConsoleOutput.Print("Would you like to buy it? (y/n)", ConsoleColor.Cyan);

                bool checkKey = true;
                while (checkKey)
                {
                    ConsoleKey answer = ConsoleInput.ReadKey();
                    if (answer == ConsoleKey.Y)
                    {
                        bank.BuyProperty(playerId);
                        checkKey = false;
                    }
                    else if (answer == ConsoleKey.N)
                    {
                        checkKey = false;
                    }
                    else
                    {
                        ConsoleOutput.Print("\nPress (Y) for yes or (N) for no!", ConsoleColor.Red);
                    }
                }
                

            }
            else
            {
                // Make sure the owner doesn't have to pay himself.
                if (playerId != _property.OwnerId)
                {
                    ConsoleOutput.Print("Someone owns this property!", ConsoleColor.Cyan);
                    ConsoleOutput.Print("Pay up!", ConsoleColor.Cyan);
                    
                    bank.RentProperty(playerId, _property.OwnerId);
                }
                else
                {
                    ConsoleOutput.Print("You own this property!", ConsoleColor.Cyan);
                    ConsoleOutput.Print("You can just take a chill pill :)", ConsoleColor.Cyan);
                }
            }
        }
        
    }

}