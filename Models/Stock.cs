using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

class Stock {
    public int Id {get; set;}
    public string Symbol {get; set;} = string.Empty;
    public string CompanyName {get;set;} = string.Empty;
    [Column(TypeName ="decimal(18,2)")]
    public decimal Purchase {get; set;}
    public decimal Divident {get; set;}

    public string Industry {get; set;} = string.Empty;
    public long MarketCap {get; set;}

    public List<Comment> Comments {get; set;} = new List<Comment>();
}