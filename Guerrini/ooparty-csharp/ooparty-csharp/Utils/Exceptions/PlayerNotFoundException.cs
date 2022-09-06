using System;
using System.Collections.Generic;
using System.Text;

namespace ooparty_csharp.Utils.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
            : base()
        {
        }

        public PlayerNotFoundException(String s)
            : base(s)
        {
        }
    }
}
