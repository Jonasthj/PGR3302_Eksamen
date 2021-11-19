using System;
using Monopoly.Logics.CardFactory.Classes;
using Monopoly.Logics.CardFactory.Interface;
using Monopoly.Logics.SquareLogics.Abstract;
using Monopoly.UI.ConsoleIO;

namespace Monopoly.UI
{
    public class PropertyUI : AbstractLogics
    {
        private Property _property;
        
        #region Methods
        
        public override void Handle(ISquare square, int playerId)
        {
            _property = (Property) square;
            BankUI bankUI = new BankUI(_property);
            
            ConsoleOutput.Print(square.ToString());

            if (_property.IsAvailable)
            {
                ConsoleOutput.Print("This property is available for purchase!", ConsoleColor.Cyan);
                ConsoleOutput.Print("Would you like to buy it? (y/n)", ConsoleColor.Cyan);

                GetPlayerAnswer(playerId, bankUI);
            }
            else
            {
                // Make sure the owner doesn't have to pay himself.
                CheckPropertyOwner(playerId, bankUI);
            }
        }

        private void CheckPropertyOwner(int playerId, BankUI bankUI)
        {
            if (playerId != _property.OwnerId)
            {
                ConsoleOutput.Print("Someone owns this property!", ConsoleColor.Cyan);
                ConsoleOutput.Print("Pay up!", ConsoleColor.Cyan);

                bankUI.RentProperty(playerId, _property.OwnerId);
            }
            else
            {
                ConsoleOutput.Print("You own this property!", ConsoleColor.Cyan);
                ConsoleOutput.Print("You can just take a chill pill :)", ConsoleColor.Cyan);
            }
        }

        private static void GetPlayerAnswer(int playerId, BankUI bankUI)
        {
            bool checkKey = true;
            while (checkKey)
            {
                ConsoleKey answer = ConsoleInput.ReadKey();
                if (answer == ConsoleKey.Y)
                {
                    bankUI.BuyProperty(playerId);
                    checkKey = false;
                }
                else if (answer == ConsoleKey.N)
                    checkKey = false;
                else
                    ConsoleOutput.Print("\nPress (Y) for yes or (N) for no!", ConsoleColor.Red);
            }
        }
        
        #endregion

    }
}