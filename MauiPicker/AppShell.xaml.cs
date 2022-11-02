namespace MauiPicker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(PictureCarousel), typeof(PictureCarousel));
	}
}
