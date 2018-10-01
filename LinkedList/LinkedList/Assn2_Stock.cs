using System;
namespace Assignment_2
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Holdings { get; set; }
        public decimal CurrentPrice { get; set; }

        // default constructor
        public Stock()
        {
            Symbol = "NA";
            Name = "Invalid";
            Holdings = 0;
            CurrentPrice = -99;
        }

        // Constructor for initialization
        public Stock(string symbol, string name, decimal holdings, decimal currentPrice)
        {
            Symbol = symbol;
            Name = name;
            Holdings = holdings;
            CurrentPrice = currentPrice;
        }

        // overridden ToString method to customize the return value
        public override string ToString()
        {
            return Symbol + ", " + Name + ", " + Holdings + ", " + CurrentPrice;
        }

        /// <summary>
        /// Overriden Equals method to provide value equality.Default Equals method compares the references of object.
        /// This method compares the object instance as well as the value and returns true if so.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool;</returns>
        public override bool Equals(Object obj)
        {
            //Checking for null objects and compare run-time types of both the objects
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                //Type Casting passed object to the required object
                Stock stock = (Stock)obj;
                //Comparing values of each object in the class for value equality and returning true if all the values are equal.
                return (this.Symbol == stock.Symbol) && (this.Name == stock.Name) && (this.CurrentPrice == stock.CurrentPrice) && (this.Holdings == stock.Holdings);
            }
        }

        /// <summary>
        /// Ovveriding Equality method results in getting invalid hash code which is necessary for
        /// hashtables and dictionary pairs as they use hashcode to retrieve small set in dictionary 
        /// and then compare them with equals method.If it is not overriden, then the dictionaries will behave improperly while adding 
        /// new dictionary or retrieving saved ones.Hence,GetHashCode should be overriden while overriding Equality method.
        /// </summary>
        /// <returns>int;hashcode</returns>
        public override int GetHashCode()
        {
            //Allowing system to not check the overflow conditions as we are fine with having overflow but to wrap
            //reference:https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                int hash = 17;
                //Use XOR instead of addition for improved performance
                //checking for null object references
                hash = (hash * 23) ^ (!Object.ReferenceEquals(null, Symbol) ? Symbol.GetHashCode() : 0);
                hash = (hash * 23) ^ (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
                hash = (hash * 23) ^ (!Object.ReferenceEquals(null, Holdings) ? Holdings.GetHashCode() : 0);
                hash = (hash * 23) ^ (!Object.ReferenceEquals(null, CurrentPrice) ? CurrentPrice.GetHashCode() : 0);
                return hash;
            }
        }
    }
}