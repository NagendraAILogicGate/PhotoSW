using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotoSW.Common
{
	public static class TextBoxService
	{
		public static readonly DependencyProperty IsNumericOnlyProperty = DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(TextBoxService), new UIPropertyMetadata(false, new PropertyChangedCallback(TextBoxService.OnIsNumericOnlyChanged)));

		public static bool GetIsNumericOnly(DependencyObject d)
		{
			return (bool)d.GetValue(TextBoxService.IsNumericOnlyProperty);
		}

		public static void SetIsNumericOnly(DependencyObject d, bool value)
		{
			d.SetValue(TextBoxService.IsNumericOnlyProperty, value);
		}

		private static void OnIsNumericOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			bool flag = (bool)e.NewValue;
			TextBox textBox = (TextBox)d;
			if (flag)
			{
				textBox.PreviewTextInput += new TextCompositionEventHandler(TextBoxService.BlockNonDigitCharacters);
				textBox.PreviewKeyDown += new KeyEventHandler(TextBoxService.ReviewKeyDown);
			}
			else
			{
				textBox.PreviewTextInput -= new TextCompositionEventHandler(TextBoxService.BlockNonDigitCharacters);
				textBox.PreviewKeyDown -= new KeyEventHandler(TextBoxService.ReviewKeyDown);
			}
		}

		private static void BlockNonDigitCharacters(object sender, TextCompositionEventArgs e)
		{
			string text = e.Text;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (!char.IsDigit(c))
				{
					e.Handled = true;
				}
			}
		}

		private static void ReviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				e.Handled = true;
			}
		}
	}
}
