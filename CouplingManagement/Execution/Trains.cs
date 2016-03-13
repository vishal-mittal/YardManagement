using System;
using System.Collections.Generic;
using System.Linq;
using CouplingManagement.Model;

namespace CouplingManagement
{
  public class Trains : IBuildTrain
  {
    private const int maximumRailRoads = 6;
    public void Build()
    {
      var railRoads = GetRailRoads();
      var buildingTrainCar = GetCar();
      StartBuilding(railRoads, buildingTrainCar);
    }
    /// <summary>
    /// This Funciton Build Train of type car from list of railRoads
    /// </summary>
    /// <param name="railRoads"></param>
    /// <param name="car"></param>
    private void StartBuilding(List<RailRoad> railRoads,Car car)
    {
      for (int i = 0; i < railRoads.Count; i++)
      {
        var selectedRail = railRoads[i].Cars.FirstOrDefault(item => item.Name == car.Name && item.Position <= 3);
        if (selectedRail!=null)
        {
          //var removeAt = selectedRail.;
          //var removed = railRoads[i].Cars.GetRange(0, removeAt+1);
          //railRoads[i].Cars.RemoveRange(0,removeAt);
          //railRoads[i+1].Cars.AddRange(removed);
        }
      }
   }
    /// <summary>
    /// This function Get the Destination car
    /// </summary>
    /// <returns></returns>
    private Car GetCar()
    {
      YardManagement.WriteToConsole("Please Enter For Which Destination you  want to build train");
      var carName = YardManagement.ReadFromConsole();
      return new Car
      {
        Name = carName,
      };
    }
    /// <summary>
    /// This Funciton return List of Rail Roads 
    /// </summary>
    /// <returns></returns>
    private List<RailRoad> GetRailRoads()
    {
      YardManagement.WriteToConsole("Please Enter your Rail Road Sequence");
      var railRoads = new List<RailRoad>();
      for (int i = 0; i < maximumRailRoads; i++)
      {
        string str = Console.ReadLine();
        var railRoad = new RailRoad();
        var cars = new Stack<Car>();
        for (int j = 0; j < str.Length; j++)
        {
          if (str[j] != 0)
          {
            var car = new Car
            {
              Name = str[j].ToString(),
            };
            car.Position = j;
            cars.Push(car);
            railRoad.Cars = cars;
          }

        }
        railRoads.Add(railRoad);
      }
      return railRoads;
    }
  }
}
