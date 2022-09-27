using Task.Entities;
using Task.Models;

namespace Task.Mappers;

public static class CompanyMappers
{
    public static Company ToEntity(this CompanyViewModel model)
        => new Company()
        {
            Name = model.Name,
            OrganizationalForm = model.OrganizationalForm
        };

    public static CompanyViewModel ToModel(this Company company)
        => new CompanyViewModel()
    {
        Name = company.Name,
        OrganizationalForm = company.OrganizationalForm
    };
}