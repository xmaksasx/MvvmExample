using System.Windows;
using MvvmExample.Infrastructure.Commands.Base;

namespace MvvmExample.Infrastructure.Commands
{
	class CloseAppCommand : Command
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter) => Application.Current.Shutdown();
	}
}
