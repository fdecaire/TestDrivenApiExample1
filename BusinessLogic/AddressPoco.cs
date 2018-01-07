using System;

namespace BusinessLogic
{
    public class AddressPoco : IComparable<AddressPoco>
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public int CompareTo(AddressPoco other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var addressComparison = string.Compare(Address, other.Address, StringComparison.Ordinal);
            if (addressComparison != 0) return addressComparison;
            var cityComparison = string.Compare(City, other.City, StringComparison.Ordinal);
            if (cityComparison != 0) return cityComparison;
            var stateComparison = string.Compare(State, other.State, StringComparison.Ordinal);
            if (stateComparison != 0) return stateComparison;
            return string.Compare(Zip, other.Zip, StringComparison.Ordinal);
        }
    }
}
