namespace DigiPhoto.Common
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class ProductPrice
    {
        public static readonly DependencyProperty IsNumericOnlyProperty = DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(ProductPrice), new UIPropertyMetadata(false, new PropertyChangedCallback(ProductPrice.OnIsNumericOnlyChanged)));

        private static void BlockNonDigitCharacters(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {
                if (!char.IsDigit(ch))
                {
                    if (e.Text == ".")
                    {
                        e.Handled = false;
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
                box.PreviewTextInput += new TextCompositionEventHandler(ProductPrice.BlockNonDigitCharacters);
                box.PreviewKeyDown += new KeyEventHandler(ProductPrice.ReviewKeyDown);
            }
            else
            {
                box.PreviewTextInput -= new TextCompositionEventHandler(ProductPrice.BlockNonDigitCharacters);
                box.PreviewKeyDown -= new KeyEventHandler(ProductPrice.ReviewKeyDown);
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

