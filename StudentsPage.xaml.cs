namespace StudentsApp;

public partial class StudentsPage : ContentPage
{
	public StudentsPage()
	{
		InitializeComponent();
	}

    private void SaveFriend(object sender, EventArgs e)
    {
        var student = (Student)BindingContext;
        if (!String.IsNullOrEmpty(student.Name))
        {
            App.Database.SaveItem(student);
        }
        this.Navigation.PopAsync();
    }
    private void DeleteFriend(object sender, EventArgs e)
    {
        var student = (Student)BindingContext;
        App.Database.DeleteItem(student.Id);
        this.Navigation.PopAsync();
    }
    private void Cancel(object sender, EventArgs e)
    {
        this.Navigation.PopAsync();
    }

    private void GroupPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

