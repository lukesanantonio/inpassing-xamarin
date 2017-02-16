using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InPassing
{
    class PassView
    {
        public string Day { get; set; }
        public int Spot { get; set; }

        public PassView(String day, int spot)
        {
            Day = day;
            Spot = spot;
        }

    }
    public partial class OrgHome : ContentPage
    {
        public Model.Org Org { get; set; }
        public List<Model.PassShallow> Passes { get; set; }

        public Backend Backend;
        public OrgHome(Model.Org org)
        {
            InitializeComponent();
            Org = org;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Backend = ((App)Application.Current).AppBackend;
            this.BindingContext = new
            {
                OrgName = Org.Name,
                OrgGreeting = Backend.GetCurrentDaystate(Org.Id).Greeting
            };

            Passes = Backend.GetPasses();

            // TODO: Filter out passes not from this org
            var views = Passes.Select(p =>
            {
                return new PassView(
                    Backend.GetDaystate(p.OrgId, p.StateId).Identifier,
                    p.SpotNum
                );
            }).ToList<PassView>();

            passesView.ItemsSource = views;
        }
    }
}
