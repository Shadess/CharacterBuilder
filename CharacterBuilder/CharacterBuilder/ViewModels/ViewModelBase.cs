using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

using CharacterBuilder;

namespace CharacterBuilder.ViewModels
{
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged, IDisposable
    {
        protected ViewModelBase() { }

        public virtual string DisplayName { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #region IDisposable Members

        // Track whether Dispose has been called.
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DisplayName = null;
                _disposed = true;
            }
        }

        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            Dispose(false);
            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }

        #endregion

        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (GetType().GetProperty(propertyName) == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.WriteLine(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides
    }
}
