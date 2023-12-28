using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokata.Domain.Exceptions
{
    public class ItemNotFoundExcepion : Exception
    {
        public ItemNotFoundExcepion(int itemId) : base($"Item with id {itemId} not found")
        {
            
        }
    }
}
