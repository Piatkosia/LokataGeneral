using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Lokata.DesktopUI.ViewModels
{
    internal class BaseViewModel : Observable, INotifyPropertyChanged
    {
        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
    }
}
