namespace DigiPhoto.Common
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class DecimalProductPrice
    {
        public static readonly DependencyProperty IsNumericOnlyProperty = DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(DecimalProductPrice), new UIPropertyMetadata(false, new PropertyChangedCallback(DecimalProductPrice.OnIsNumericOnlyChanged)));

        private static void BlockNonDigitCharacters(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {
                TextBox box = (TextBox) sender;
                string text = box.Text;
                try
                {
                    string[] strArray = text.Split(new char[] { '.' });
                    if ((strArray.Length > 1) && (strArray[1].Length >= 2))
                    {
                        e.Handled = true;
                    }
                }
                catch
                {
                }
                if (!char.IsDigit(ch))
                {
                    if (e.Text == ".")
                    {
                        if (text.Split(new char[] { '.' }).Length > 1)
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

        public static bool GetIsNumericOnly(DependencyObject d)
        {
            return (bool) d.GetValue(IsNumericOnlyProperty);
        }

        private static void OnIsNumericOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool newValue = (bool) e.NewValue;
            TextBox box = (TextBox) d;
            if (newValue)
            {
                box.PreviewTextInput += new TextCompositionEventHandler(DecimalProductPrice.BlockNonDigitCharacters);
                box.PreviewKeyDown += new KeyEventHandler(DecimalProductPrice.ReviewKeyDown);
            }
            else
            {
                box.PreviewTextInput -= new TextCompositionEventHandler(DecimalProductPrice.BlockNonDigitCharacters);
                box.PreviewKeyDown -= new KeyEventHandler(DecimalProductPrice.ReviewKeyDown);
            }
        }

        private static void ReviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        public static void SetIsNumericOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsNumericOnlyProperty, value);
        }
    }
}

