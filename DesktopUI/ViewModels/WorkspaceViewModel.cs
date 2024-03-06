﻿using System;
using System.Windows.Input;

using Lokata.DataAccess;
using Lokata.DesktopUI.Helpers;

namespace Lokata.DesktopUI.ViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        public string DisplayName
        {
            get
            {
                if (IsChanged)
                    return $"* " + _displayName;
                else return _displayName;

            }
            set
            {
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public virtual bool IsChanged { get; set; }

        private BaseCommand _closeCommand;
        public event EventHandler RequestClose;

        public DatabaseContext Context = new DatabaseContext();
        private string _displayName;

        public ICommand CloseCommand
        {
            get
            {
                _closeCommand ??= new BaseCommand(OnRequestClose);
                return _closeCommand;
            }
        }
        public void OnRequestClose()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
