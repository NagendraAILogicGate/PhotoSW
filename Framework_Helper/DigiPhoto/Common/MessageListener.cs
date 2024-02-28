namespace DigiPhoto.Common
{
    using System;
    using System.Diagnostics;
    using System.Windows;

    public class MessageListener : DependencyObject
    {
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageListener), new UIPropertyMetadata(null));
        private static MessageListener mInstance;

        private MessageListener()
        {
        }

        public void ReceiveMessage(string message)
        {
            this.Message = message;
            Debug.WriteLine(this.Message);
            DispatcherHelper.DoEvents();
        }

        public static MessageListener Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new MessageListener();
                }
                return mInstance;
            }
        }

        public string Message
        {
            get
            {
                return (string) base.GetValue(MessageProperty);
            }
            set
            {
                base.SetValue(MessageProperty, value);
            }
        }
    }
}

