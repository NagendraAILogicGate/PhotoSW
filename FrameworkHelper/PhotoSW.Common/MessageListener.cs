using System;
using System.Diagnostics;
using System.Windows;

namespace PhotoSW.Common
{
	public class MessageListener : DependencyObject
	{
		private static MessageListener mInstance;

		public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageListener), new UIPropertyMetadata(null));

		public static MessageListener Instance
		{
			get
			{
				if (MessageListener.mInstance == null)
				{
					MessageListener.mInstance = new MessageListener();
				}
				return MessageListener.mInstance;
			}
		}

		public string Message
		{
			get
			{
				return (string)base.GetValue(MessageListener.MessageProperty);
			}
			set
			{
				base.SetValue(MessageListener.MessageProperty, value);
			}
		}

		private MessageListener()
		{
		}

		public void ReceiveMessage(string message)
		{
			this.Message = message;
			Debug.WriteLine(this.Message);
			DispatcherHelper.DoEvents();
		}
	}
}
