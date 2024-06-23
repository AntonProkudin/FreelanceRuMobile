namespace FreelanceRu.Pages.Popup;

public partial class NotifyPopup : Material.Components.Maui.Popup
{
	public NotifyPopup()
	{
		InitializeComponent();
	}
    private void CancelClicked(object sender, TouchEventArgs e)
    {
        this.Close();
    }
}