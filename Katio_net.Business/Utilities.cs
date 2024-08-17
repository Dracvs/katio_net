using Katio.Data.Models;

namespace Katio.Business.Utilities;
public static class Utilities
{
    public static List<Books> CreateABooksList()
    {
        List<Books> bookList = new List<Books>()
        {
            
            new Books()
            {
                Title = "Cien años de soledad",
                ISBN10 = "842047183",
                ISBN13 = "978-842047183",
                Edition = "RAE Obra Académica",
                DeweyIndex = "800",
                //Published = new DateTime().AddDays(05).AddMonths(06).AddYears(1967),
                Published = new DateTime(1967, 06, 05),
                Id = 1
            },
            new Books()
            {
                Title = "Huellas",
                ISBN10 = "958427275",
                ISBN13 = "978-958427275",
                Edition = "Planeta",
                DeweyIndex = "800",
                //Published = new DateTime().AddDays(05).AddMonths(06).AddYears(1967),
                Published = new DateTime(2019, 01, 01),
                Id = 2
            },
            new Books()
            {
                Title = "María",
                ISBN10 = "148027292",
                ISBN13 = "978-148027292",
                Edition = "1ra Edición",
                DeweyIndex = "800",
                //Published = new DateTime().AddDays(05).AddMonths(06).AddYears(1967),
                Published = new DateTime(1867, 01, 01),
                Id = 3
            },
            
            new Books()
            {
                Title = "Sin Remedio",
                ISBN10 = "3161484100",
                ISBN13 = "978-3161484100",
                Edition = "Alfaguara",
                DeweyIndex = "800",
                //Published = new DateTime().AddDays(05).AddMonths(06).AddYears(1967),
                Published = new DateTime(1984, 01, 01),
                Id = 4
            },
        };
        return bookList;
    }
}


/*
Title = "",
                ISBN10 = "",
                ISBN13 = "",
                Edition = "",
                DeweyIndex = "",
                //Published = new DateTime().AddDays(05).AddMonths(06).AddYears(1967),
                Published = new DateTime(2019, 06, 05),
                Id = 2
                */