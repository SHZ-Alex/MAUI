using System.Runtime.CompilerServices;

namespace ContactBook.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
	public bool IsForAdd { get; set; }
	
	public ContactControl()
	{
		InitializeComponent();
	}

	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged();

		if (IsForAdd)
			btnSave.SetBinding(Button.CommandProperty, "AddContactCommand");
		else
			btnSave.SetBinding(Button.CommandProperty,"EditContactCommand");
		
	}
}