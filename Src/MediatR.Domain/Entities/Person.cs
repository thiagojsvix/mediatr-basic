using MediatR.Domain.Abstractions;
using MediatR.Domain.Validations;

namespace MediatR.Domain.Entities;

public sealed class Person : Entity
{
    public Person(long id, string firstName, string lastName, string gender, string email, bool isActive) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = isActive;

        ValidateDomain(id, firstName, lastName, gender, email, isActive);
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;


    private void ValidateDomain(long id, string firstName, string lastName, string gender, string email, bool? isActive)
    {
        DomainValidation.When(id < 0, "Invalid Id value.");
        ValidateDomain(firstName, lastName, gender, email, isActive);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? isActive)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(firstName), "FirstName is Required.");
        DomainValidation.When(firstName.Length < 3, "Invalid FirstName, too short minimum 3 characteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(lastName), "LastName is Required.");
        DomainValidation.When(lastName.Length < 3, "Invalid LastName, too short minimum 3 characteres.");

        DomainValidation.When(email?.Length < 6, "Invalid email, too short, minimum 6 characters.");
        DomainValidation.When(email?.Length > 250, "Invalid email, too long, maximum 250 characters.");

        DomainValidation.When(string.IsNullOrWhiteSpace(gender), "Gender is Required.");

        DomainValidation.When(isActive.HasValue == false, "Must define activity.");
    }
}
