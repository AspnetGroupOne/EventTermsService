using Application.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Documentation_Swagger;

public class UpdateTermsForm_Example : IExamplesProvider<UpdateTermsForm>
{
    public UpdateTermsForm GetExamples() => new()
    {
        EventId = "56f58514-7581-4b18-97f5-b6eb5ba7b9c9",
        Section = new List<TermsSection>
            {
                new TermsSection
                {
                    Id = 1,
                    TermsId = 100,
                    Header = "Legal section.",
                    Order = 1,
                    Lines = new List<string>
                    {
                        "Line one.",
                        "Line three."
                    }
                }
            }
    };
}
