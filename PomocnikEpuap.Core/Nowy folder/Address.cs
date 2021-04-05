using System;
using System.Collections.Generic;
using System.Text;

namespace PomocnikEpuap.Core
{
    public class Address
    {
        public Address(string postalCode, string city, string street, string buildingNumber, string flatNumber)
        {
            PostalCode = postalCode;
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }

        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string BuildingNumber  { get; private set; }
        public string FlatNumber { get; private set; }
    }
}
