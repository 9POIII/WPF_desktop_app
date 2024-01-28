using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinanceApp2._0.Utilits
{
    internal class CheckUserInput
    {
        private TextBox textBoxLogin;
        private TextBox textBoxEmail;
        private PasswordBox passwordBoxPassword;
        private PasswordBox passwordBoxRetryPassword;
        private PasswordBox passwordBoxAuthPassword;
        private ComboBox comboBoxTypeOfStatus;

        private bool isLoginCorrect() => textBoxLogin.Text.Length >= 4 && textBoxLogin.Text.Length <= 16 && textBoxLogin.Text != null;
        private bool isEmailCorrect() => textBoxEmail.Text.Length > 5 || textBoxEmail.Text.Contains("@") || textBoxEmail.Text.Contains(".") && textBoxEmail.Text != null;
        private bool isPasswordCorrect() => passwordBoxPassword.Password.Length >= 5 && passwordBoxPassword.Password.Length <= 16 && passwordBoxPassword.Password != null;
        private bool isPassword2Correct() => passwordBoxRetryPassword.Password.Length >= 5 && passwordBoxRetryPassword.Password.Length <= 16
                                             && passwordBoxRetryPassword.Password != null && passwordBoxRetryPassword.Password.Equals(passwordBoxPassword.Password);
        private bool isPasswordAuthCorrect() => passwordBoxAuthPassword.Password != null;
        private bool isTypeOfStatusCorrect() => comboBoxTypeOfStatus.SelectedIndex != -1;

        public CheckUserInput(TextBox textBoxLogin, TextBox textBoxEmail, PasswordBox passwordBoxPassword, PasswordBox passwordBoxRetryPassword, ComboBox comboBoxTypeOfStatus)
        {
            this.textBoxLogin = textBoxLogin;
            this.textBoxEmail = textBoxEmail;
            this.passwordBoxPassword = passwordBoxPassword;
            this.passwordBoxRetryPassword = passwordBoxRetryPassword;
            this.comboBoxTypeOfStatus = comboBoxTypeOfStatus;
        }

        public CheckUserInput(TextBox textBoxLogin, PasswordBox passwordAuthBox)
        {
            this.textBoxLogin = textBoxLogin;
            this.passwordBoxAuthPassword = passwordAuthBox;
        }

        public bool ValidateUserInput(bool isAuthWindow)
        {
            Dictionary<Control, Func<bool>> validationRules = new Dictionary<Control, Func<bool>>();

            if (isAuthWindow)
            {
                validationRules = new Dictionary<Control, Func<bool>>
                {
                    { textBoxLogin, () => isLoginCorrect() },
                    { passwordBoxAuthPassword, () => isPasswordAuthCorrect() },
                };
            }
            else {
                validationRules = new Dictionary<Control, Func<bool>>
                {
                    { textBoxLogin, () => isLoginCorrect() },
                    { textBoxEmail, () => isEmailCorrect() },
                    { passwordBoxPassword, () => isPasswordCorrect() },
                    { passwordBoxRetryPassword, () => isPassword2Correct() },
                    { comboBoxTypeOfStatus, () => isTypeOfStatusCorrect() },
                };
            }


            bool hasError = false;

            foreach (var validationRule in validationRules)
            {
                Control textBox = validationRule.Key;
                Func<bool> validationFunc = validationRule.Value;

                if (!validationFunc())
                {
                    textBox.ToolTip = "Field contains error!";
                    textBox.Background = Brushes.IndianRed;
                    hasError = true;
                }
                else
                {
                    textBox.ToolTip = null;
                    textBox.Background = Brushes.Transparent;
                }
            }

            return !hasError;
        }
    }
}
