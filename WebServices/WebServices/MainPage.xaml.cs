using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.Model;
using Xamarin.Forms;

namespace WebServices
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            RestClient client = new RestClient();
            Authorization auth = await client.Post<Authorization>();
            LabelChange.Text ="Key: " + auth.id_token;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            RestClient client = new RestClient();
            var mainpage = await client.Get<GetResult>("http://192.168.0.73/api/account");//await client.Get<WinGetResult>("http://192.168.0.73/api/account");
            if (mainpage != null)
            {
                LabelChange.Text ="Company Name: " + mainpage.firstName;

            }
            else
            {
                LabelChange.Text = "Sorry Get function failed";
            }
        }
    }
}
