public class CustomerDto {
    public int Id {get; set;}
    public string CustomerFirstName {get; set;} = string.Empty;
    public string CustomerLastName {get; set;} = string.Empty;
    public DateTime birthDate {get; set;}

    public string password {get; set;} = string.Empty;
}