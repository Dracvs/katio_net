using System.ComponentModel.DataAnnotations.Schema;
using Katio_net.Data.Models;

namespace Katio.Data.Models;
public class Book : BaseEntity<int>
{
    public string Title {get; set;} = "";
    public string ISBN10{get; set;} = "";
    public string ISBN13{get; set;} = "";
    public DateTime Published{get;set;}
    public string Edition{get; set;} = "";
    public string DeweyIndex{get; set;} = "";
    public string Cover {get;set;} ="";

    [ForeignKey("Author")]
    public int AuthorId {get; set;}

    public virtual Author? Author{ get; set;}

    public bool Any()
    {
        return Id > 0;
    }
}
