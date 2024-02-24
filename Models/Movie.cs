using System.ComponentModel.DataAnnotations;

namespace Movie4All.Models;

public class Movie {

//Movie details:
    public int Id {get; set;}                   //ID=Primary Key
    public string? Title {get;set;}
    [DataType(DataType.Date)]
    public DateTime ReleaseDate {get; set;}     
    public string? Genre {get;set;}
    public decimal Price {get;set;}
}