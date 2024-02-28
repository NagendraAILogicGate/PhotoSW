using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotoSW.Common
{
	public class DecimalProductPrice
	{
		public static readonly DependencyProperty IsNumericOnlyProperty = DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(DecimalProductPrice), new UIPropertyMetadata(false, new PropertyChangedCallback(DecimalProductPrice.OnIsNumericOnlyChanged)));

		public static bool GetIsNumericOnly(DependencyObject d)
		{
			return (bool)d.GetValue(DecimalProductPrice.IsNumericOnlyProperty);
		}

		public static void SetIsNumericOnly(DependencyObject d, bool value)
		{
			d.SetValue(DecimalProductPrice.IsNumericOnlyProperty, value);
		}

		private static void OnIsNumericOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			bool flag = (bool)e.NewValue;
			TextBox textBox = (TextBox)d;
			if (flag)
			{
				textBox.PreviewTextInput += new TextCompositionEventHandler(DecimalProductPrice.BlockNonDigitCharacters);
				textBox.PreviewKeyDown += new KeyEventHandler(DecimalProductPrice.ReviewKeyDown);
			}
			else
			{
				textBox.PreviewTextInput -= new TextCompositionEventHandler(DecimalProductPrice.BlockNonDigitCharacters);
				textBox.PreviewKeyDown -= new KeyEventHandler(DecimalProductPrice.ReviewKeyDown);
			}
		}

		private static void BlockNonDigitCharacters(object sender, TextCompositionEventArgs e)
		{
			string text = e.Text;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				TextBox textBox = (TextBox)sender;
				string text2 = textBox.Text;
				try
				{
					string[] array = text2.Split(new char[]
					{
						'.'
					});
					if (array.Length > 1 && array[1].Length >= 2)
					{
						e.Handled = true;
					}
				}
				catch
				{
				}
				if (!char.IsDigit(c))
				{
					if (e.Text == ".")
					{
						int num = text2.Split(new char[]
						{
							'.'
						}).Length;
						if (num > 1)
						{
							e.Handled = true;
						}
						else
						{
							e.Handled = false;
						}
					}
					else
					{
						e.Handled = true;
					}
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
