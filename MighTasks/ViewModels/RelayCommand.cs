using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MighTasks.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Constructor that takes an Action to execute and an optional Func<bool> for canExecute
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Event that is raised when the ability to execute the command changes
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Determines whether the command can be executed
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // Executes the command
        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        // Private field that holds the action to be executed. It's a delegate that takes a parameter of type T and returns nothing.
        private readonly Action<T> _execute;

        // Private field that holds the predicate to determine if the action can be executed.
        // It's a delegate that takes a parameter of type T and returns a boolean.
        private readonly Predicate<T> _canExecute;

        // Constructor for RelayCommand. It takes two parameters: a mandatory action and an optional predicate.
        // 'execute' is the action to be performed, and 'canExecute' determines if the action can be executed.
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            // Assigns the action to the _execute field. Throws an ArgumentNullException if 'execute' is null.
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            // Assigns the predicate to the _canExecute field. It's optional and can be null.
            _canExecute = canExecute;
        }

        // Method to check if the command can be executed. It takes a parameter and returns a boolean.
        public bool CanExecute(object parameter)
        {
            // Returns true if _canExecute is null (meaning no predicate was provided, so the command can always execute).
            // Otherwise, it invokes the _canExecute predicate with the casted parameter and returns its result.
            return _canExecute == null || _canExecute((T)parameter);
        }

        // Method to execute the command. It takes a parameter and returns nothing.
        public void Execute(object parameter)
        {
            // Invokes the _execute action with the casted parameter.
            _execute((T)parameter);
        }

        // Event handler for CanExecuteChanged event. This event is triggered when the execution status of the command changes.
        public event EventHandler CanExecuteChanged
        {
            // Adds a handler to the CommandManager's RequerySuggested event. 
            // This ensures that CanExecuteChanged is raised whenever the CommandManager suggests requerying the command status.
            add => CommandManager.RequerySuggested += value;
            // Removes a handler from the CommandManager's RequerySuggested event.
            remove => CommandManager.RequerySuggested -= value;
        }

    }
}
