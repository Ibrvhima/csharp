using StudentCRUD.Models;

namespace StudentCRUD;

public partial class MainPage : ContentPage
{
    private List<Student> _students = new List<Student>();
    private Student? _editingStudent;

    public MainPage()
    {
        InitializeComponent();
        RefreshStudentsList();
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        if (!await ValidateInputs())
            return;

        var student = new Student
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Email = EmailEntry.Text,
            Phone = PhoneEntry.Text,
            Course = CourseEntry.Text,
            EnrollmentDate = EnrollmentDatePicker.Date ?? DateTime.Today
        };

        _students.Add(student);
        RefreshStudentsList();
        ClearForm();
        
        await DisplayAlert("Success", "Student added successfully!", "OK");
    }

    private async void OnUpdateClicked(object? sender, EventArgs e)
    {
        if (_editingStudent == null || !await ValidateInputs())
            return;

        _editingStudent.FirstName = FirstNameEntry.Text;
        _editingStudent.LastName = LastNameEntry.Text;
        _editingStudent.Email = EmailEntry.Text;
        _editingStudent.Phone = PhoneEntry.Text;
        _editingStudent.Course = CourseEntry.Text;
        _editingStudent.EnrollmentDate = EnrollmentDatePicker.Date ?? DateTime.Today;

        RefreshStudentsList();
        ClearForm();
        
        await DisplayAlert("Success", "Student updated successfully!", "OK");
    }

    private void OnClearClicked(object? sender, EventArgs e)
    {
        ClearForm();
    }

    private void OnToggleListClicked(object? sender, EventArgs e)
    {
        StudentListFrame.IsVisible = !StudentListFrame.IsVisible;
        ToggleListBtn.Text = StudentListFrame.IsVisible ? "👁️ Hide Students" : "👁️ Show Students";
    }

    private void OnEditClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Student student)
        {
            _editingStudent = student;
            FirstNameEntry.Text = student.FirstName;
            LastNameEntry.Text = student.LastName;
            EmailEntry.Text = student.Email;
            PhoneEntry.Text = student.Phone;
            CourseEntry.Text = student.Course;
            EnrollmentDatePicker.Date = student.EnrollmentDate;
            
            AddBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = true;
        }
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Student student)
        {
            bool result = await DisplayAlert("Confirm", $"Delete {student.FullName}?", "Yes", "No");
            if (result)
            {
                _students.Remove(student);
                RefreshStudentsList();
                await DisplayAlert("Success", "Student deleted successfully!", "OK");
            }
        }
    }

    private void ClearForm()
    {
        FirstNameEntry.Text = string.Empty;
        LastNameEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        PhoneEntry.Text = string.Empty;
        CourseEntry.Text = string.Empty;
        EnrollmentDatePicker.Date = DateTime.Today;
        
        AddBtn.IsEnabled = true;
        UpdateBtn.IsEnabled = false;
        _editingStudent = null;
    }

    private void RefreshStudentsList()
    {
        StudentsCollection.ItemsSource = null;
        StudentsCollection.ItemsSource = _students;
        CountLabel.Text = $"{_students.Count} student(s)";
    }

    private async Task<bool> ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Error", "Please fill in all required fields", "OK");
            return false;
        }

        if (!EmailEntry.Text.Contains("@"))
        {
            await DisplayAlert("Error", "Please enter a valid email address", "OK");
            return false;
        }

        return true;
    }
}
