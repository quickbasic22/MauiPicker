using MauiPicker.Model;
using System.Collections.ObjectModel;

namespace MauiPicker;

public partial class PictureCarousel : ContentPage
{
	public ObservableCollection<PictureModel> Items { get; set; }
	public PictureCarousel()
	{
		InitializeComponent();
		
        Items = new ObservableCollection<PictureModel>
		{
			new PictureModel() { PictureObject = PictureObject.Person, Date = DateTime.Now.AddDays(-1250), Description = "First Picture", PictureUrl = ImageSource.FromFile("tshirt197350years.png") },
			new PictureModel() { PictureObject = PictureObject.Object, Date = DateTime.Now.AddDays(-126), Description = "Second Picture", PictureUrl = ImageSource.FromFile("ssdpci.jpg") },
			new PictureModel() { PictureObject = PictureObject.Location, Date = DateTime.Now.AddDays(1250), Description = "Third Picture", PictureUrl = ImageSource.FromFile("ohiotunnel.jpg") },
		};
		BindingContext = this;
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		MyCarousel.ClearValue(CarouselView.ItemTemplateProperty);
		MyCarousel.ItemTemplate = new DataTemplate(() =>
		{
			var myFrame = new Frame();
			var img = new Image();
			img.Aspect = Aspect.AspectFill;
			img.Source = ImageSource.FromFile("ohiotunnel.jpg");
			myFrame.Content = img;
			return myFrame;
		});

    }
}