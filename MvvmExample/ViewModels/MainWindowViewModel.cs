using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using MvvmExample.Infrastructure.Commands;
using MvvmExample.Models;
using MvvmExample.ViewModels.Base;

namespace MvvmExample.ViewModels
{
	internal class MainWindowViewModel : ViewModel
	{

		#region номер выбранной вкладки

		/// <summary>номер выбранной вкладки</summary>
		private int _selectedPageIndex;

		/// <summary>номер выбранной вкладки</summary>
		public int SelectedPageIndex { get => _selectedPageIndex; set => Set(ref _selectedPageIndex, value); }

		#endregion



		#region TestDataPoint

		/// <summary>TestDataPoint</summary>
		private IEnumerable<DataPoint> _testDataPoints;

		/// <summary>TestDataPoint</summary>
		public IEnumerable<DataPoint> TestDataPoints { get => _testDataPoints; set => Set(ref _testDataPoints, value); }

		#endregion




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

		#region Статус программы
		/// <summary>Статус программы</summary>
		private string _status = "Готов!";

		/// <summary>Статус программы</summary>
		public string Status
		{
			get => _status;
			set => Set(ref _status, value);
			//set
			//{
			//	//if (Equals(_title, value)) return;
			//	//_title = value;
			//	//OnPropertyChanged();
			//}
		}

		#endregion

		#region Команды

		#region CloseAppCommand
		public ICommand CloseAppCommand { get; set; }

		private bool CanCloseAppCommandExecute(object p) => true;

		private void OnCloseAppCommandExecuted(object p)
		{
			Application.Current.Shutdown();
		} 
		#endregion

		public ICommand ChangeTabIndexCommand { get; }
		private bool CanChangeTabIndexCommandExecute(object p) => _selectedPageIndex >= 0;

		private void OnChangeTabIndexCommandExecuted(object p)
		{
			if (p is null) return;
			SelectedPageIndex += Convert.ToInt32(p);

		}
		#endregion

		public MainWindowViewModel()
		{
			#region Команды
			CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
			ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
			#endregion

			var dataPoints = new List<DataPoint>((int)(360/0.1));
			for (var i = 0.0; i < 360; i+=0.1)
			{
				double toRad = Math.PI / 180;
				var y = Math.Sin(i * toRad);
				dataPoints.Add(new DataPoint{ XValue = i, YValue = y});
			}

			TestDataPoints = dataPoints;
		}
	}
}
