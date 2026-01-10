namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Validates user data.
    /// Responsibility: User validation logic only.
    /// </summary>
    public class UserValidator
    {
        public ValidationResult Validate(User user)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
            {
                errors.Add("Invalid email address");
            }

            if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 8)
            {
                errors.Add("Password must be at least 8 characters");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                errors.Add("Name is required");
            }

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }
}
