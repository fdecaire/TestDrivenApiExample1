using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CheckAddress
    {
	    private IAddressApiLookup _addressApiLookup;

	    public CheckAddress(IAddressApiLookup addressApiLookup)
	    {
		    _addressApiLookup = addressApiLookup;
	    }

	    public bool IsEqual(int personId, AddressPoco currentAddress)
	    {
	      return currentAddress.CompareTo(_addressApiLookup.Get(personId)) == 0;
	    }
    }
}
