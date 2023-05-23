namespace FormulaAirlineAPI.Services
{
    public interface IMessageProducer
    {
        public void SendingMessage<T>(T message);
    }
}
//https://localhost:7233/swagger/index.html