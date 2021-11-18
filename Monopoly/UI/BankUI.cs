using System;
using Monopoly.Logics;
using Monopoly.Logics.CardFactory.Classes;

namespace Monopoly.UI
{
    public class BankUI
    {
        private readonly BankLogic _logic = new ();
        private readonly Property _property;
        private readonly GameManager _manager = GameManager.GetInstance();

        public BankUI(Property property)
        {
            _property = property;
        }

        public BankUI()
        {
        }

        public void BuyProperty(int playerId)
        {
            if(CreditCheck(playerId, _property.BuyPrice))
            {
                _logic.Purchase(playerId, _property);
                
                ConsoleOutput.PrintNewLine();
                ConsoleOutput.Print("Congratulations on your new property!", ConsoleColor.Cyan);
            }
            else
            {
                ConsoleOutput.PrintNewLine();
                ConsoleOutput.Print("You don't have enough money to purchase this property!", ConsoleColor.Red);
            }
        }
        
        public void RentProperty(int playerId, int ownerId)
        {
            if (CreditCheck(playerId, _property.RentPrice))
            {
                _logic.RentTransaction(playerId, ownerId, _property);
            }
            else
            {
                Bankrupt(playerId);
                _logic.BankPayout(ownerId, _property);
            }
        }
        
        public void ChanceHandler(int playerId, int value)
        {
            if(!_logic.Validate(playerId, value))
                Bankrupt(playerId);
        }
        
        private bool CreditCheck(int playerId, int price)
        {
            if (!_manager.TaxRaise && _logic.CheckPlayersWealth())
                TaxReform();

            return _logic.PlayerHasCredit(playerId, price);
        }

        private void TaxReform()
        {
            int raiseValue = 200;
            
            _logic.IncreaseTax(raiseValue);
            
            ConsoleOutput.Print("There har been a tax reform!\n" +
                                $"Therefore taxes have been raised with {raiseValue}M", ConsoleColor.DarkRed);
        }
        
        private void Bankrupt(int playerId)
        {
            ConsoleOutput.Print("You don't have enough money to cover your rent!", ConsoleColor.Red);
            ConsoleOutput.Print("You are officially bankrupt!", ConsoleColor.Red);

            ConsoleInput.ReadKey();

            _logic.BlacklistPlayer(playerId);
        }
    }
}