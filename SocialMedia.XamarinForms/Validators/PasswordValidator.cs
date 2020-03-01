using System.Text.RegularExpressions;

namespace SocialMedia.XamarinForms.Validators
{
	public static class PasswordValidator
	{
		public const string RegExpConst = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?!.*(.)\1\1)(?=.*[^\da-zA-Z]).{8,}$";
		private static readonly Regex regex = new Regex(RegExpConst);

		public static bool Validate(string password)
		{
			return regex.IsMatch(password);
		}
	}
}
