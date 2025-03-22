using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

public class PhoneNumber : ValueObject
{
    public string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return Result.Failure<PhoneNumber>("Phone number should not be empty");

        if (!Regex.IsMatch(number, @"^\+?[0-9]\d{1,14}$"))
            return Result.Failure<PhoneNumber>("Phone number is not valid");

        return Result.Success(new PhoneNumber(number));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}