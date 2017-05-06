namespace GambitApi.Domains.Validators
{
    public interface IValidator<in T>
    {
        bool Validate(T model);
    }
}