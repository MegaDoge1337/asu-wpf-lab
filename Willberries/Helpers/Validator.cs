using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Willberries.Helpers
{
    class Validator
    {
        public static bool CheckByRequired(TextBox textBox) 
        {
            var checkResult = true;
            var text = textBox.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                textBox.Foreground = Brushes.DarkRed;
                textBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else if (string.IsNullOrEmpty(text))
            {
                textBox.Foreground = Brushes.DarkRed;
                textBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else 
            {
                textBox.Foreground = Brushes.Purple;
                textBox.BorderBrush = Brushes.Purple;
            }

            return checkResult;
        }

        public static bool CheckByRequired(PasswordBox passwordBox)
        {
            var checkResult = true;
            var text = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(text))
            {
                passwordBox.Foreground = Brushes.DarkRed;
                passwordBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else if (string.IsNullOrEmpty(text))
            {
                passwordBox.Foreground = Brushes.DarkRed;
                passwordBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else 
            {
                passwordBox.Foreground = Brushes.Purple;
                passwordBox.BorderBrush = Brushes.Purple;
            }

            return checkResult;
        }

        public static bool CheckByRequired(ComboBox comboBox)
        {
            var checkResult = true;
            var text = comboBox.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                comboBox.Foreground = Brushes.DarkRed;
                comboBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else if (string.IsNullOrEmpty(text))
            {
                comboBox.Foreground = Brushes.DarkRed;
                comboBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else
            {
                comboBox.Foreground = Brushes.Purple;
                comboBox.BorderBrush = Brushes.Purple;
            }

            return checkResult;
        }

        public static bool CheckByRequired(CheckBox checkBox)
        {
            var checkResult = true;
            var value = checkBox.IsChecked;

            if (value == null)
            {
                checkBox.Foreground = Brushes.DarkRed;
                checkBox.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else
            {
                checkBox.Foreground = Brushes.Purple;
                checkBox.BorderBrush = Brushes.Purple;
            }

            return checkResult;
        }

        public static bool CheckByRequired(DatePicker datePicker)
        {
            var checkResult = true;
            var text = datePicker.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                datePicker.Foreground = Brushes.DarkRed;
                datePicker.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else if (string.IsNullOrEmpty(text))
            {
                datePicker.Foreground = Brushes.DarkRed;
                datePicker.BorderBrush = Brushes.DarkRed;
                checkResult = false;
            }
            else
            {
                datePicker.Foreground = Brushes.Purple;
                datePicker.BorderBrush = Brushes.Purple;
            }

            return checkResult;
        }

        public static bool CheckByNumeric(TextBox textBox)
        {
            var checkResult = true;
            var text = textBox.Text;

            foreach (var symbol in text) 
            {
                if (!char.IsDigit(symbol)) 
                {
                    textBox.Foreground = Brushes.DarkRed;
                    textBox.BorderBrush = Brushes.DarkRed;
                    checkResult = false;
                    return checkResult;
                }
            }

            textBox.Foreground = Brushes.Purple;
            textBox.BorderBrush = Brushes.Purple;
            return checkResult;
        }

        public static bool CheckByNumeric(ComboBox comboBox)
        {
            var checkResult = true;
            var text = comboBox.Text;

            foreach (var symbol in text)
            {
                if (!char.IsDigit(symbol))
                {
                    comboBox.Foreground = Brushes.DarkRed;
                    comboBox.BorderBrush = Brushes.DarkRed;
                    checkResult = false;
                    return checkResult;
                }
            }

            comboBox.Foreground = Brushes.Purple;
            comboBox.BorderBrush = Brushes.Purple;
            return checkResult;
        }
    }
}
