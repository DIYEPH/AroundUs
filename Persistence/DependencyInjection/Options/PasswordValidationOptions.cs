namespace Persistence.DependencyInjection.Options
{
    public record PasswordValidationOptions
    {
        public int RequiredMinLength { get; set; }
        public int RequiredMaxLength { get; set; } = int.MaxValue;
        public int RequiredNonLetterOrDigitLength { get; set; }
        public int RequiredLowercaseLength { get; set; }
        public int RequiredUppercaseLength { get; set; }
        public int RequiredDigitLength { get; set; }
    }
}
