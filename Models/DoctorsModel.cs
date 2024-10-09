using System.ComponentModel.DataAnnotations;

public class DoctorModel {
    [Key]
    public int DoctorID {get; set;}
    public string DoctorFirstName {get; set;} = string.Empty;
    public string DoctorLastName {get; set;} = string.Empty;
    public string degreeCertificate {get; set;} = string.Empty;
    public List<CustomerModel> CustomerModels{get; set;} = new List<CustomerModel>();
}