using MvvmExample.ViewModels.Base;

namespace MvvmExample.ViewModels
{
	internal class MainWindowViewModel : ViewModel
	{
		#region Заголовок окна 
		/// <summary>Заголовок окна</summary>
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

		#region Заголовок окна 
		/// <summary>Статус программы</summary>
		private string _status = "Готов!";

		/// <summary>Статус программы</summary>
		public string Status
		{
			get => _title;
			set => Set(ref _status, value);
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
