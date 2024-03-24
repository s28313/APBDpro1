using System;
using System.Runtime.Serialization;

namespace APBDpro1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Contener kon1 = new Contener(1000.0, 100.0, 200, 100, "KON-C-1200",2000);
            kon1.load(20000);
        }
    }


    public class Contener : IHazardNotifier
    {
        private double mass;
        private double heigh;
        private double contenerMass;
        private double depth;
        private string serialNumber = "KON";
        private double maxLoad;
        private bool danger = false;
        private double pressure;
        private string productType;
        private double tempereture;

        public Contener(double mass, double heigh, double contenerMass, double depth, string serialNumber,
            double maxLoad) // normal 
        {
            this.mass = maxLoad;
            this.heigh = heigh;
            this.contenerMass = contenerMass;
            this.depth = depth;
            this.serialNumber = serialNumber;
            this.maxLoad = maxLoad;

            string[] serialNumberParts = serialNumber.Split('-');

            while (!serialNumberParts[0].Equals("KON"))
            {
                Console.WriteLine("================================================================");
                if (!serialNumberParts[0].Equals("KON"))
                {
                    Console.WriteLine("Wrong serial number, enter another one:");
                    this.serialNumber = Console.ReadLine();
                }
            }
        }
        public Contener(double mass, double heigh, double contenerMass, double depth, string serialNumber,
            double maxLoad, bool danger) // liquid 
        {
            this.mass = maxLoad;
            this.heigh = heigh;
            this.contenerMass = contenerMass;
            this.depth = depth;
            this.serialNumber = serialNumber;
            this.maxLoad = maxLoad;
            this.danger = danger;

            string[] serialNumberParts = serialNumber.Split('-');

            while (!serialNumberParts[0].Equals("KON"))
            {
                Console.WriteLine("================================================================");
                if (!serialNumberParts[0].Equals("KON"))
                {
                    Console.WriteLine("Wrong serial number, enter another one:");
                    this.serialNumber = Console.ReadLine();
                }
            }
        }
        public Contener(double mass, double heigh, double contenerMass, double depth, string serialNumber,
            double maxLoad, double pressure) // gass
        {
            this.mass = maxLoad;
            this.heigh = heigh;
            this.contenerMass = contenerMass;
            this.depth = depth;
            this.serialNumber = serialNumber;
            this.maxLoad = maxLoad;
            this.pressure = pressure;

            string[] serialNumberParts = serialNumber.Split('-');

            while (!serialNumberParts[0].Equals("KON"))
            {
                Console.WriteLine("================================================================");
                if (!serialNumberParts[0].Equals("KON"))
                {
                    Console.WriteLine("Wrong serial number, enter another one:");
                    this.serialNumber = Console.ReadLine();
                }
            }
        }
        public Contener(double mass, double heigh, double contenerMass, double depth, string serialNumber,
            double maxLoad, string productType, double tempereture) // cooolong
        {
            this.mass = maxLoad;
            this.heigh = heigh;
            this.contenerMass = contenerMass;
            this.depth = depth;
            this.serialNumber = serialNumber;
            this.maxLoad = maxLoad;
            this.productType = productType;
            this.tempereture = tempereture;
            

            string[] serialNumberParts = serialNumber.Split('-');

            while (!serialNumberParts[0].Equals("KON"))
            {
                Console.WriteLine("================================================================");
                if (!serialNumberParts[0].Equals("KON"))
                {
                    Console.WriteLine("Wrong serial number, enter another one:");
                    this.serialNumber = Console.ReadLine();
                }
            }
        }
        



        public void emptyIt()
        {
            Console.WriteLine("Emptying contener: "+ serialNumber+"================================================================");
            string inputType = (string)serialNumber.Split('-')[1];
            switch (inputType)
            {
                case "L":
                {
                    this.mass = 0;
                    break;
                }
                case "G":
                {
                    this.mass = this.mass * 0.95;
                    break;
                }
                case "C":
                {
                    this.mass = 0;
                    break;
                }
                default:
                {
                    Console.WriteLine("Wrong serial number");
                    break;
                }
            }
        }

        public void load(double mass)
        {
            Console.WriteLine("Loading contener: " + serialNumber+ " ================================================================");
            if (maxLoad < mass)
            {
                throw new OverfillException(serialNumber);
            }

            string inputType = (string)serialNumber.Split('-')[1];
            switch (inputType)
            {
                case "L":
                {
                    if (danger)
                    {
                        if (this.mass > maxLoad * 0.5)
                        {
                            notify();
                            mass = 0;
                        }
                        else this.mass = mass;
                    }
                    
                    break;
                }
                case "G":
                {
                    if (this.mass + mass > maxLoad)
                    {
                        notify();
                        mass = 0;
                    }
                    break;
                }
                case "C":
                {
                    if (this.mass > maxLoad * 0.5)
                    {
                        notify();
                        mass = 0;
                    }
                    else this.mass = mass;
                    break;
                }
                default:
                {
                    Console.WriteLine("Wrong serial number");
                    break;
                }
            }
        }

        public void notify()
        {
            Console.WriteLine("You are doing something prohibited in contener: " + serialNumber);
        }


    }

    interface IHazardNotifier
    {
        void notify();
    }
    
    public class OverfillException : Exception
    {
        public OverfillException()
        {
        }

        public OverfillException(string message) : base(message)
        {
            Console.WriteLine("You overfilled it: " + message);
        }

        public OverfillException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OverfillException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}