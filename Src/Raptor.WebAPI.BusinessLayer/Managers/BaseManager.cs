namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class BaseManager {
        protected string DatabaseConnection;

        public BaseManager(string databaseConnection) {
            DatabaseConnection = databaseConnection;
        }
    }
}