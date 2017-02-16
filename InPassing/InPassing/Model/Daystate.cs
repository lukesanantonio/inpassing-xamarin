using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing.Model
{
    public class DaystateShallow
    {
        public int OrgId { get; private set; }
        public string Identifier { get; private set; }
        public string Greeting { get; private set; }
        public DaystateShallow(int org, string ident, string greet)
        {
            OrgId = org;
            Identifier = ident;
            Greeting = greet;
        }
        public static DaystateShallow FromDynamic(dynamic obj)
        {
            return new DaystateShallow(Convert.ToInt32(obj.org_id), obj.identifier, obj.greeting);
        }
    }
}
