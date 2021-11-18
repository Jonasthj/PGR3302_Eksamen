namespace Monopoly.Logics.CardFactory.Interface
{
    public interface IProperty
    {
        void SetAvailability(bool status);

        void SetOwner(int id);

        void SetBuyPrice(int value);

        void SetRentPrice(int value);
    }
}