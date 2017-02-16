using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing.Model
{
    public class PassShallow
    {
        public int Id { get; private set; }
        public int OrgId { get; private set; }
        public int OwnerId { get; private set; }
        public int StateId { get; private set; }
        public int SpotNum { get; private set; }
        public PassShallow(int id, int org, int owner, int state, int spotNum)
        {
            Id = id;
            OrgId = org;
            OwnerId = owner;
            StateId = state;
            SpotNum = spotNum;
        }
        public static PassShallow FromDynamic(dynamic obj)
        {
            return new PassShallow(Convert.ToInt32(obj.id), Convert.ToInt32(obj.org_id), Convert.ToInt32(obj.owner_id),
                Convert.ToInt32(obj.state_id), Convert.ToInt32(obj.spot_num));
        }
    }
}
