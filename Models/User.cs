using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class User{
    public int userID {get; set;}
    public string userName {get; set;} = string.Empty;
    public string userType {get; set;} = string.Empty;

}