namespace Katio.Data.Models;
public class Books
{
    public int Id {get;set;}
    public string Title {get; set;} = "";
    public string ISBN10{get; set;} = "";
    public string ISBN13{get; set;} = "";
    public DateTime Published{get;set;}
    public string Edition{get; set;} = "";
    public string DeweyIndex{get; set;} = "";


}