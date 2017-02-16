using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing
{
    class TestBackend : Backend
    {
        private static int DELAY_TIME = 15;

        public TestBackend() : base(null)
        {
            CurUser = null;
        }

        async public override Task RefreshMe()
        {
            // Don't do anything, this operation doesn't make sense since there is nothing to refresh, etc.
            await Task.Delay(DELAY_TIME);
        }

        async public override Task AuthenticateAsync(string email, string password)
        {
            // Always authenticate successfully, but make them wait
            await Task.Delay(DELAY_TIME);

            // Some very sketchy student who goes to two schools.
            Model.Org org1 = new Model.Org(1, "Locust Valley High School");
            Model.Org org2 = new Model.Org(2, "Oyster Bay High School");

            CurUser = new Model.User(1, "Fake", "Name", email, new List<Model.Org> { org1, org2 }, new List<Model.Org>());
        }
        async public override Task SignupAsync(string first_name, string last_name, string email, string password)
        {
            // Simulate network time
            await Task.Delay(DELAY_TIME);

            // Make a new fake user with no orgs
            CurUser = new Model.User(1, first_name, last_name, email, new List<Model.Org>(), new List<Model.Org>());
        }
        async public override Task<Model.User> GetCurUserOrRefreshAsync()
        {
            if (CurUser != null) return CurUser;

            await RefreshMe();
            return CurUser;
        }

        public override List<Model.PassShallow> GetPasses()
        {
            return new List<Model.PassShallow> {
                new Model.PassShallow(1, 1, 1, 1, 20),
                new Model.PassShallow(1, 1, 1, 2, 40),
            };
        }

        public override bool Authenticated()
        {
            return CurUser != null;
        }

        public override Model.DaystateShallow GetDaystate(int orgId, int stateId)
        {
            if (stateId == 1)
            {
                return new Model.DaystateShallow(orgId, "A", "Today is an A day");
            }
            else if (stateId == 2)
            {
                return new Model.DaystateShallow(orgId, "B", "Today is a B day");
            }
            throw new NotImplementedException();
        }
        public override Model.DaystateShallow GetCurrentDaystate(int orgId)
        {
            return new Model.DaystateShallow(orgId, "B", "Today is a B day");
        }
    }
}
