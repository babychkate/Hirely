using Hirely.UI.ViewModels;

public class ResumeViewModel : ViewModelBase
{
    private string _resumePath = "";
    public string ResumePath
    {
        get => _resumePath;
        set
        {
            _resumePath = value;
            OnPropertyChanged(nameof(ResumePath));
        }
    }
}
