using MvvmExample.ViewModels.Base;

namespace MvvmExample.ViewModels
{
	internal class MainWindowViewModel : ViewModel
	{
		#region Заголовок окна 

		private string _title="Анализ данных";

		/// <summary>Заголовок окна</summary>
		public string Title
		{
			get => _title;
			set => Set(ref _title, value);
			//set
			//{
			//	//if (Equals(_title, value)) return;
			//	//_title = value;
			//	//OnPropertyChanged();
			//}
		}

		#endregion
	}
}
