using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InPassing
{
    public partial class OrgHome : ContentPage
    {
        public Model.Org Org { get; set; }
        public OrgHome(Model.Org org)
        {
            InitializeComponent();
            Org = org;

            this.BindingContext = new
            {
                Name = Org.Name
            };
        }
    }
}
