using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IAddressApiLookup
    {
	    AddressPoco Get(int personId);
    }
}
