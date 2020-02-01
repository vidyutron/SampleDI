namespace DomainLayer.Fork
{
    public interface IDataAccess
    {
        void Connect();
        void QueryData();
        void UpdateData();
    }
}
