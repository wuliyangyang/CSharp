using DesignMode3.Builders.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders
{
    public class BikeBuilder : IBuilder
    {
        private Bike _bike = new Bike();

        private BikeBuilder BuilderFrame()
        {
            _bike.Frame = new Parts.BikeFrame();
            return this;
        }

        private BikeBuilder BuilderSeat()
        {
            _bike.Seat = new Parts.BikeSeat();
            return this;
        }

        private BikeBuilder BuilderTire()
        {
            _bike.Tire = new Parts.BikeTire();
            return this;
        }

        public Bike BuildBike()
        {
            return _bike;
        }

        public void Assembly()
        {
            this.BuilderFrame();
            this.BuilderSeat();
            this.BuilderTire();

        }
    }
}
