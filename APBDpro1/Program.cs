using System;
using System.Runtime.Serialization;

namespace APBDpro1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Contener kon1 = new Contener(1000.0, 100.0, 200, 100, "KON",2000);
            kon1.load(20000);
        }
    }
    
    
    public class Contener
    {
        private double Mass;
        private double heigh;
        private double contenerMass;
        private double depth;
        private String serialNumber = "KON";
        private double maxLoad;

        public Contener(double Mass, double heigh, double contenerMass, double depth, string serialNumber, double maxLoad)
        {
            this.Mass = maxLoad;
            this.heigh = heigh;
            this.contenerMass = contenerMass;
            this.depth = depth;
            this.serialNumber = serialNumber;
            this.maxLoad = maxLoad;
        }
        

        public void emptyIt()
        {
            Mass = 0;
        }

        public void load(double mass)
        {
            if (maxLoad < mass)
            {
                throw new OverfillException();
            }
        }
        
    }

    public class OverfillException : Exception
    {
        public OverfillException()
        {
        }

        public OverfillException(string message) : base(message)
        {
        }

        public OverfillException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OverfillException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}