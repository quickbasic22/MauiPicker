using MauiPicker.Model;

namespace MauiPicker;

public partial class MainPage : ContentPage
{
	//List<string> companyList = new List<string>();
	public MainPage()
	{
		InitializeComponent();
		//ceoPicker.Items.Add("Elon Musk");
		//ceoPicker.Items.Add("Bill Gates");
		//ceoPicker.Items.Add("Steve Jobs");
		//companyList.Add("Tesla");
		//companyList.Add("Microsoft");
		//companyList.Add("Apple");
		//companyPicker.ItemsSource = companyList;

	}

	private async void companyPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
        var obj = companyPicker.SelectedItem as CompanyModel;
        if (obj != null)
        {
            await TextToSpeech.SpeakAsync("you picked");
            await TextToSpeech.SpeakAsync(obj.Name);
            await TextToSpeech.SpeakAsync(obj.Logo);
            await TextToSpeech.SpeakAsync(obj.Description);

        }
    }
	private async void filePickerButton_Clicked(object sender, EventArgs e)
	{
		var filepickertype = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
		{
			{ DevicePlatform.iOS, new[] { "com.adobe.pdf" } },
			{ DevicePlatform.Android, new[] { "application/pdf" } },
			{ DevicePlatform.WinUI, new[] { "*.pdf" } },
			{ DevicePlatform.Tizen, new[] { "*/*"} },
			{ DevicePlatform.macOS, new[] { "pdf"} },
		});
		var typefile = filepickertype.Value;


		var result = await FilePicker.PickMultipleAsync(new PickOptions()
		{
			FileTypes = FilePickerFileType.Images,
			PickerTitle = "Pick a file"
		});
		if (result == null)
		{
			return;
		}
		Stream[] streams = new Stream[5];
		int cnt = 1;
		foreach (var file in result)
		{
		   streams[cnt] = await file.OpenReadAsync();
			cnt++;
		}


		myImage1.Source = ImageSource.FromStream(() => streams[1]);
        myImage2.Source = ImageSource.FromStream(() => streams[2]);
        myImage3.Source = ImageSource.FromStream(() => streams[3]);
        myImage4.Source = ImageSource.FromStream(() => streams[4]);

    }
}

