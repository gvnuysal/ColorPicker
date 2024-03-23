using CommunityToolkit.Maui.Alerts;

namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red=sldRed.Value;
            var green=sldGreen.Value;
            var blue=sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text= hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            var random = new Random();
            var color = Color.FromRgb(random.Next(0,265),random.Next(0,265), random.Next(0,265));

            SetColor(color);
            sldBlue.Value = color.Blue;
            sldGreen.Value = color.Green;
            sldRed.Value = color.Red;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color Copied",
                                    CommunityToolkit.Maui.Core.ToastDuration.Short,
                                    12);
            await toast.Show();
        }
    }

}
