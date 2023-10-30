using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.Where(plane => plane is PassengerPlane)
                         .Select(plane => plane as PassengerPlane).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.Where(plane => plane is MilitaryPlane)
                         .Select(plane => plane as MilitaryPlane).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return Planes.Where(plane => plane is PassengerPlane)
                          .Select(plane => plane as PassengerPlane)
                          .OrderBy(plane => plane.PassengersCapacity).First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return Planes.Where(plane => plane is MilitaryPlane)
                        .Select(plane => plane as MilitaryPlane)
                        .Where(plane => plane.Type == MilitaryType.Transport).ToList();
        }

        public void SortByMaxDistance()
        {
            Planes = Planes.OrderBy(i => i.MaxFlightDistance).ToList();
        }

        public void SortByMaxSpeed()
        {
            Planes = Planes.OrderBy(i => i.MaxSpeed).ToList();
        }

        public void SortByMaxLoadCapacity()
        {
            Planes = Planes.OrderBy(i => i.MaxLoadCapacity).ToList();
        }

        public override string ToString()
        {
            return "Airport{" +
                    $"planes=[{string.Join(", ", Planes.Select(plane => plane.Model))}]" +
                    '}';
        }
    }
}
