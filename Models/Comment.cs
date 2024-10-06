using System.ComponentModel.DataAnnotations;

class Comment {
    // models for table
    [Key]
    public int ID {get; set;}
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn {get; set;} = DateTime.Now;
    public int? StockId {get;set;}
    public Stock? Stock {get; set;} //navigation property
}