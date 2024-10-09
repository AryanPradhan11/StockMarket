using System.ComponentModel.DataAnnotations;

public class CustomerModel {
    [Key]
    public int CustomerID {get; set;}
    public string CustomerFirstName {get; set;} = string.Empty;
    public string CustomerLastName {get; set;} = string.Empty;
    public DateTime birthDate {get; set;}

    public int? DoctorID {get; set;}
    public DoctorModel? doctorModel {get; set;}
}