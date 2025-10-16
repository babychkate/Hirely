using System;

namespace Hirely.UI.ViewModels
{
    public class CandidateViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string _fullName = string.Empty;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private string _status = string.Empty;
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        // Нові поля
        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private string _photoPath = string.Empty;
        public string PhotoPath
        {
            get => _photoPath;
            set
            {
                if (_photoPath != value)
                {
                    _photoPath = value;
                    OnPropertyChanged(nameof(PhotoPath));
                }
            }
        }

        private string _level = "Junior";
        public string Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }

        private string _resumeLink = string.Empty;
        public string ResumeLink
        {
            get => _resumeLink;
            set
            {
                if (_resumeLink != value)
                {
                    _resumeLink = value;
                    OnPropertyChanged(nameof(ResumeLink));
                }
            }
        }

        // Конструктор за бажанням для швидкого створення
        public CandidateViewModel() { }

        public CandidateViewModel(Hirely.Model.Models.Candidate model)
        {
            Id = model.Id;
            FullName = model.FullName;
            Status = model.Status;
            PhoneNumber = model.PhoneNumber;
            PhotoPath = model.PhotoPath;
            Level = model.Level;
            ResumeLink = model.ResumeLink;
        }
    }
}
