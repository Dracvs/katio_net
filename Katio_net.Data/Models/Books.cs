namespace Katio.Data.Models;
public class Books
{
    public int Id;
    public string Name {get; set;} = "";
    public string ISBN10;
    public string ISBN13;
    public DateTime Published;
    public string Edition;
    public string DeweyIndex;
}