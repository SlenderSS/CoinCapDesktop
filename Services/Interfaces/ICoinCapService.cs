namespace CoinCapDesktop.Services.Interfaces
{
    interface ICoinCapService
    {
        string BaseUrl { get;}

        Task<T> GetData<T>(params string[] parameters);
    }
}
