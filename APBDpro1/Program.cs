using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class ContenerShip
    {
        private string name;
        private double maxSpeedInKnots;
        private int maxContenerCount;
        private double maxContenerLoad;
        private List<Contener> contenerList = new List<Contener>();
        private double contenerLoad;

        public ContenerShip(string name, double maxSpeedInKnots, int maxContenerCount, double maxContenerLoad)
        {
            this.name = name;
            this.maxSpeedInKnots = maxSpeedInKnots;
            this.maxContenerCount = maxContenerCount;
            this.maxContenerLoad = maxContenerLoad;
            
        }

        public void loadContener(Contener contener)
        {
            if (maxContenerCount >= contenerList.Count + 1 && maxContenerLoad >= contenerLoad + contener.getMass())
            {
                contenerList.Add(contener);
                contenerLoad = countContenerMass();
            }
            else Console.WriteLine("Ships cargo full");
        }

        public double countContenerMass()
        {
            double mass = 0;
            for (int i = 0; i < contenerList.Count; i++)
            {
                mass += contenerList[i].getMass();
            }
            return mass;
        }

        public void getContenrnerList()
        {
            foreach (Contener c in contenerList) Console.WriteLine(c.getSerialNumber());
        }

        public void removeContener(string serialNumber)
        {
            for (int i = 0; i < contenerList.Count; i++)
            {
                if (contenerList[i].getSerialNumber().Equals(serialNumber))
                {
                    contenerList.RemoveAt(i);
                    contenerLoad = countContenerMass();
                }
            }
        }
        public void removeContener(Contener contenerToRemove)
        {
            removeContener(contenerToRemove.getSerialNumber());
        }

        public void switchContener(Contener toPut, Contener toOut)
        {
            for (int i = 0; i < contenerList.Count; i++)
            {
                if (contenerList[i].getSerialNumber().Equals(toOut.getSerialNumber()))
                {
                    contenerList[i] = toPut;
                    contenerLoad = countContenerMass();
                }
            }
        }

        public List<Contener> getContenerList()
        {
            return contenerList;
        }
        public static void changeContenersShip(ContenerShip oldOwner, ContenerShip newOwner, Contener toSwitch)
        {
            List<Contener> tmpList = oldOwner.getContenerList();
            
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].getSerialNumber().Equals(toSwitch.getSerialNumber()))
                {
                    newOwner.loadContener(tmpList[i]);
                    oldOwner.removeContener(tmpList[i]);
                }
            }
        }
        
        

        public void showInfoContener(Contener contener)
        {
            showInfoContener(contener.getSerialNumber());
        }
        public void showInfoContener(string serialNumber)
        {
            for (int i = 0; i < contenerList.Count; i++)
            {
                if (contenerList[i].getSerialNumber().Equals(serialNumber))
                {
                    Console.WriteLine(contenerList[i]);
                }
            }
        }

        public string showShipInfo()
        {
            return "Name: " + name + "\n" +
                   "Max speed(in knots): " + maxSpeedInKnots + "\n" +
                   "Max contener count: " + maxContenerCount + "\n" +
                   "Contener count: " + contenerList.Count + "\n" +
                   "Max contener load: " + maxContenerLoad + "\n" +
                   "Contener load: " + contenerLoad;
        }
        
    }
    

    public class Contener : IHazardNotifier
    {
        private string inputType;
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
            inputType = (string)serialNumber.Split('-')[1];

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
            inputType = (string)serialNumber.Split('-')[1];


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
            inputType = (string)serialNumber.Split('-')[1];


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
            inputType = (string)serialNumber.Split('-')[1];

            

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

        public double getMass()
        {
            return mass + contenerMass;
        }

        public string getSerialNumber()
        {
            return serialNumber;
        }
        public void emptyIt()
        {
            Console.WriteLine("Emptying contener: "+ serialNumber+"================================================================");
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

        public override string ToString()
        {
            string typeDiff = "";
            switch (inputType)
            {
                case "L":
                {
                    typeDiff = "Is dangerous: " + danger;
                    break;
                }
                case "G":
                {
                    typeDiff = "Pressure: " + pressure;
                    break;
                }
                case "C":
                {
                    typeDiff = "Product Type: " + productType + "\n" +
                               "Temperture: " + tempereture;
                    break;
                }
                default:
                {
                    break;
                }
            }

            return "Serial Number: " + serialNumber + "\n" +
                   "Contener Type: " + inputType + "\n" +
                   "Mass: " + mass + "\n" +
                   "Heigh: " + heigh + "\n" +
                   "Contener Mass: " + contenerMass + "\n" +
                   "Depth: " + depth + "\n" +
                   typeDiff;
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