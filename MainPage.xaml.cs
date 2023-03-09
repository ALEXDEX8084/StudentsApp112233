using System;
namespace StudentsApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        studentsList.ItemsSource = App.Database.GetItems();
        base.OnAppearing();
    }
    // обработка нажатия элемента в списке
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Student selectedFriend = (Student)e.SelectedItem;
        StudentsPage friendPage = new StudentsPage();
        friendPage.BindingContext = selectedFriend;
        await Navigation.PushAsync(friendPage);
    }
    // обработка нажатия кнопки добавления
    private async void CreateFriend(object sender, EventArgs e)
    {
        Student friend = new Student();
        StudentsPage friendPage = new StudentsPage();
        friendPage.BindingContext = friend;
        await Navigation.PushAsync(friendPage);
    }
}

