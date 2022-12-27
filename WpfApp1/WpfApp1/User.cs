using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{       
    //Для определения кто из клиентов авторизован в данный момент
    class User
    {
        public static Client Person {get;set;}
    }
}
