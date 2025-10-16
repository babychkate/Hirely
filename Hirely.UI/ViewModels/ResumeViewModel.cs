using System.ComponentModel;

public class ResumeViewModel : INotifyPropertyChanged
{
    private string _resumePath;
    public string ResumePath
    {
        get => _resumePath;
        set
        {
            _resumePath = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResumePath)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
