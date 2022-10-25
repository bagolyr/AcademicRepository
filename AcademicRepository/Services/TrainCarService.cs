using _2022_09_23.Entities;
using _2022_09_23.Entities.DbContextNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2022_09_23.Services
{
    public interface ITrainCarService
    {
        List<TrainCar> List();
        List<TrainCar> GetBySiteName(string siteName);
        int Create(TrainCar trainCar);
    }
    public class TrainCarService:ITrainCarService
    {
        List<TrainCar> trainCarList = new List<TrainCar>
            {
                new TrainCar{
                    Owner = "MÁV",
                    SerialNumber = "Bhv",
                    Site = new Site {Name = "Celldömölk"},
                    TrackNumber = "50 55 20-05 555-7",
                    YearOfManufacture = 1965
                },
                new TrainCar{
                    Owner = "MÁV",
                    SerialNumber = "BdBhv",
                    Site = new Site {Name = "Celldömölk"},
                    TrackNumber = "50 55 20-05 555-4",
                    YearOfManufacture = 1965
                }
            };
        private readonly TrainCar2DbContext _dbContext;

        public TrainCarService(TrainCar2DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TrainCar> List()
        {
            //return trainCarList;
            return _dbContext.TrainCar.ToList();
        }
        public List<TrainCar> GetBySiteName(string siteName){

            //return trainCarList.Where(ThreadLocal => ThreadLocal.Site.Name == siteName).ToList();
            return _dbContext.TrainCar.Include(tc => tc.Site).Where(tc => tc.Site.Name == siteName).ToList();
        }
        public int Create(TrainCar trainCar)
        {
            _dbContext.TrainCar.Add(trainCar);
            return _dbContext.SaveChanges();            
        }
    }
}
