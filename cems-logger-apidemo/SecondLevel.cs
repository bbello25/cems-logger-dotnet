using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cems_logger_apidemo
{
    public class SecondLevel
    {

        public void ThrowE1()
        {
            ThrowECommon("Throw1");
        }

        public void ThrowE2()
        {
            ThrowECommon("ThrowE2");
        }

        public void ThrowE3()
        {
            ThrowE1();
        }

        public void ThrowECommon(string msg)
        {
            throw new Exception(msg);
        }

        public void ThrowStElse()
        {
            ThrowStElseLvl2();
        }

        private void ThrowStElseLvl2()
        {
            throw new Exception("ThrowStElseLvl2");
        }

    }
}
