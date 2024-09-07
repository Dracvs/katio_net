using Katio_net.Data.Models;

namespace Katio.Data.Models;
public class Author : BaseEntity<int>
{
    public String Name{ get; set; }
    public String LastName{ get; set; }
    public String Country {get; set; }
    public DateOnly BirthDate{get;set;}
}