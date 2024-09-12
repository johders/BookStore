using System.ComponentModel;

namespace BookStore.Mobile
{
	public class AppState : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private string _loaderMessage = "Processing";

		public string LoaderMessage
		{
			get { return _loaderMessage; }
			set 
			{ 
				_loaderMessage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoaderMessage)));
			}
		}

		private bool _isLoaderVisible;

		public bool IsLoaderVisible
		{
			get { return _isLoaderVisible; }
			set 
			{ 
				if(_isLoaderVisible != value)
				{
					_isLoaderVisible = value; 
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoaderVisible)));
				}
			}
		}

		public void ShowLoader(string? loaderMessage = "Processing...")
		{
			if(string.IsNullOrWhiteSpace(loaderMessage))
			{
				loaderMessage = "Processing...";
			}
			LoaderMessage = loaderMessage;
			IsLoaderVisible = true;
		}

		public void HideLoader()
		{
			LoaderMessage = "Processing...";
			IsLoaderVisible = false;
		}


	}
}
