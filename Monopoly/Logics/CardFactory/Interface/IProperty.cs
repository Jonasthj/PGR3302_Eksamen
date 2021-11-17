namespace Monopoly.Logics.CardFactory.Interface
{
    public interface IProperty
    {
        bool SetAvailability(bool status);

        int SetOwner(int id);
    }
}