using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InPassing
{
  public partial class MainPage : ContentPage
  {
    string translatedNumber;

    public MainPage()
    {
      InitializeComponent();
      dayText.Text = "Today is an A day";
      actionButton.Text = "Lend your pass";
    }

    void OnAction(object sender, EventArgs e)
    {
    }
  }
}
