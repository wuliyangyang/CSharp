using DesignMode3.Builders.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders
{
   public class OfoBikeBuilder:IBuilder
    {
        private Bike _bike = new Bike();

        private  OfoBikeBuilder BuilderFrame()
        {
            _bike.Frame = new Parts.OfoBikeFrame();
            return this;
        }

        private OfoBikeBuilder BuilderSeat()
        {
            _bike.Seat = new Parts.OfoBikeSeat();
            return this;
        }

        private OfoBikeBuilder BuilderTire()
        {
            _bike.Tire = new Parts.OfoBikeTire();
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
