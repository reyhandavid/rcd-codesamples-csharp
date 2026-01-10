namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Orchestrates user creation by coordinating other services.
    /// Responsibility: User workflow coordination only.
    /// </summary>
    public class UserService
    {
        private readonly UserValidator _validator;
        private readonly UserRepository _repository;
        private readonly EmailService _emailService;
        private readonly Logger _logger;

        public UserService(
            UserValidator validator,
            UserRepository repository,
            EmailService emailService,
            Logger logger)
        {
            _validator = validator;
            _repository = repository;
            _emailService = emailService;
            _logger = logger;
        }

        public bool CreateUser(string email, string password, string name)
        {
            try
            {
                var user = new User(email, password, name);

                // Validate
                var validationResult = _validator.Validate(user);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        _logger.LogError($"Validation failed: {error}");
                    }
                    return false;
                }

                // Save to database
                _repository.Save(user);
                _logger.LogInfo($"User {email} created successfully");

                // Send welcome email
                _emailService.SendWelcomeEmail(email, name);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create user {email}", ex);
                return false;
            }
        }
    }
}
