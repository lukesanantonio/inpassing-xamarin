using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InPassing
{
    public partial class Home : MasterDetailPage
    {
        Dictionary<int, Page> orgMasterPageCache;
        public Home()
        {
            InitializeComponent();

            this.Detail = new NavigationPage(new ContentPage());

            orgMasterPageCache = new Dictionary<int, Page>();
            orgListView.ItemSelected += OnSelection;
        }
        protected override void OnAppearing()
        {
            Model.User user = ((App)Application.Current).AppBackend.CurUser;
            orgListView.ItemsSource = user?.Participates;
        }

        protected void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var org = (Model.Org)e.SelectedItem;
            if (!orgMasterPageCache.ContainsKey(org.Id))
            {
                orgMasterPageCache[org.Id] = new NavigationPage(new OrgHome(org));
            }

            this.Detail = orgMasterPageCache[org.Id];
            this.IsPresented = false;
        }
    }
}
