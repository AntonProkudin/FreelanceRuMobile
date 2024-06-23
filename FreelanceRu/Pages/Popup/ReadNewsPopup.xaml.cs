namespace FreelanceRu.Pages.Popup;
public partial class ReadNewsPopup : Material.Components.Maui.Popup
{
	public ReadNewsPopup(string text)
	{
        News.Text = text;
		InitializeComponent();
	}
    private void CancelClicked(object sender, TouchEventArgs e)
    {
        this.Close();
    }
}