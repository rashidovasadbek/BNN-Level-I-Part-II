using FeulCar.Model;

namespace FeulCar.Service;
public class FuelStationService
{
    private readonly FuelFillerService _fuelFillerService;
   
   
    public FuelStationService(FuelFillerService fuelFillerService)
    {
        _fuelFillerService = fuelFillerService;
    }

    public async ValueTask<int> Start(List<Car> cars)
    {
        var semaphore = new SemaphoreSlim(0, 10);
        var fillTasks = cars.Select(car =>
        {
            semaphore.Wait();
            return Task.Run(() =>
            {
                var a = _fuelFillerService.Fill(car);
                semaphore.Release();
                return a;
            });
        });
        semaphore.Release(10);
        var balance = await Task.WhenAll(fillTasks);
        return balance.Sum();
    }
}
