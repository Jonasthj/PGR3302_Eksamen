using Monopoly.Logics.CardFactory.Interface;

namespace Monopoly.Logics.CardFactory.Abstract
{
    public abstract class CreateSquare
    {
        /// <summary>
        /// The abstract creator template that all other square-creators inherit from,
        /// BuildSquare should return the desired square when overridden. 
        /// </summary>
        
        public abstract ISquare BuildSquare();
    }
}