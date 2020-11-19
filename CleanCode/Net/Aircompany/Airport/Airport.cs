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
            return Planes.OfType<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.PlaneTypeIs() == MilitaryType.TRANSPORT).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }

        public List<MilitaryPlane> GetTransportTypeMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.PlaneTypeIs() == MilitaryType.TRANSPORT).ToList();
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
