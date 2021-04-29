﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmExample.ViewModels.Base
{
	internal abstract class ViewModel : INotifyPropertyChanged , IDisposable
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void Dispose()
		{
			Dispose(true);
		}

		private bool _disposed;
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed || disposing) return;
			_disposed = true;
			//Освобождение управляемых ресурсов
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

	}
}
