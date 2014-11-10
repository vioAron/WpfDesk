using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace WpfDesk.MVVM.Infrastructure
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(Expression<Func<T>> propertySelector, T value)
        {
            var propertyName = GetPropertyName(propertySelector);
            SetValue(propertyName, value);
        }

        protected void SetValue<T>(string propertyName, T value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException(@"Invalid property name", propertyName);
            }

            _values[propertyName] = value;
            NotifyPropertyChanged(propertyName);
        }

        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);
            return GetValue<T>(propertyName);
        }

        protected T GetValue<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException(@"Invalid property name", propertyName);
            }
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                value = default(T); _values.Add(propertyName, value);
            } return (T)value;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            //todo add
            //VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName); handler(this, e);
            }
        }

/*
        private void VerifyPropertyName(string propertyName)
        {
            if (!_values.ContainsKey(propertyName))
                throw new ArgumentException(propertyName + "not found!");
        }
*/

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = GetPropertyName(propertySelector);
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region "Private members"

        private static string GetPropertyName(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }
            return memberExpression.Member.Name;
        }

        private object GetValue(string propertyName)
        {
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                {
                    throw new ArgumentException(@"Invalid property name", propertyName);
                }
                value = propertyDescriptor.GetValue(this);
                _values.Add(propertyName, value);
            } return value;
        }

        #endregion

        #region Data Validation

        string IDataErrorInfo.Error
        {
            get { throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead."); }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return OnValidate(propertyName); }
        }

        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException(@"Invalid property name", propertyName);
            } 
            var error = string.Empty; 
            var value = GetValue(propertyName); 
            var results = new List<ValidationResult>(1); 
            
            var result = Validator.TryValidateProperty(value, new ValidationContext(this, null, null)
                { MemberName = propertyName }, results); 
            
            if (!result)
            {
                var validationResult = results.First(); 
                error = validationResult.ErrorMessage;
            } 

            return error;
        }

        #endregion
    }
}
