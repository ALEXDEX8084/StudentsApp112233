# Программа StudentsApp реализует функционал:
* __Описание программы__

Программа предназначена для добавления студента по группе с заполнением его данных.
* __Функционал программы__

1. Кнопка сохранить(Для сохранения студентов).
2. Кнопка удалить(Для удаления студентов).
3. Кнопка отмены(для отмены изменений)
4. Кнопка добавить(Для добавления новых студентов)
5. Поле со списком(для выбора групп)
* __библиотеки__

Using SQLite
* __классы__

1. Класс Student

```
namespace StudentsApp
{
    [Table("Students")]
    public class Student
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
         
        public string Group { get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Data { get; set; }
    }
}

```

2. Класс StudentsPage
```

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


3. Класс StudentsRepository
```

namespace StudentsApp
{
    public class StudentRepository
    {

        SQLiteConnection database;

        static object locker = new object();
        public StudentRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Student>();
        }
        public IEnumerable<Student> GetItems()
        {
            return database.Table<Student>().ToList();
        }
        public Student GetItem(int id)
        {
            return database.Get<Student>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Student>(id);
            }
        }
        public int SaveItem(Student item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
```

4. Класс MainPage
```
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
```
![add](https://github.com/ALEXDEX8084/StudentsApp112233/add.png?raw=true)
![MainWindow](https://github.com/ALEXDEX8084/StudentsApp112233/MainWindow.png?raw=true)
