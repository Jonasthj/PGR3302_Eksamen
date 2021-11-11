﻿using System;
using Monopoly.Factory.Interface;

namespace Monopoly.Factory.Classes
{
    public class Start : ISquare
    {
        #region Properties

        private int Id { get;}
        private string Name { get;}

        #endregion

        #region Constructors

        public Start(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Implemented

        public void PrintSquare()
        {
            Console.WriteLine(ToString());
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                   "Name: " + Name;
        }

        #endregion
       
    }
}