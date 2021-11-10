using System;
using System.Collections;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Chance : ISquare
    {
        private int Id { get; }
        private string Name { get; }
        private ArrayList ChanceList { get; }

        public Chance(int id, ArrayList chanceList)
        {
            Id = id;
            Name = "Chance";
            ChanceList = chanceList;
        }
        
        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string list = "";
                
            foreach (var chance in ChanceList)
            {
                list += "    " + chance + "\n";
            }
            
            
            return "Id: " + Id + "\n" +
                   "Name: " + Name + "\n" +
                   "ChanceList: \n" + list;
        }
    }
}