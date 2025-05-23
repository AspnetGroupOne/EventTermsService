using Application.Entity;
using Application.Models;

namespace Application.Factory;

public class TermFactory
{
    //Factory made by chatgpt.
    public static TermsEntity Create(AddTermsForm form)
    {
        if (form == null) return null!;
        return new TermsEntity
        {
            EventId = form.EventId,
            Section = form.Section.Select(s => new TermsSection
            {
                Header = s.Header,
                Order = s.Order,
                Lines = s.Lines
            }).ToList()
        };
    }
    public static TermsEntity Create(UpdateTermsForm form)
    {
        if (form == null) return null!;
        return new TermsEntity
        {
            EventId = form.EventId,
            Section = form.Section.Select(s => new TermsSection
            {
                Header = s.Header,
                Order = s.Order,
                Lines = s.Lines
            }).ToList()
        };
    }
    public static EventTerms Create(TermsEntity entity)
    {
        if (entity == null) return null!;
        return new EventTerms
        {
            EventId = entity.EventId,
            Section = entity.Section
                .OrderBy(s => s.Order)
                .Select(s => new TermsSection
                {
                    Header = s.Header,
                    Order = s.Order,
                    Lines = s.Lines.ToList()
                }).ToList()
        };
    }
}
