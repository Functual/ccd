using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cc.ccQuickMint
{
    class ccQuickMintConsole
    {
        static ccQuickMint libInstance = null;
        static void Main(string[] args)
        {
            libInstance = new ccQuickMint();
        }
    }
}
