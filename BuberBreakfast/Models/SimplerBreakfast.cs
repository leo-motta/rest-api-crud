using System.ComponentModel.DataAnnotations;

namespace BuberBreakfast.Models;

public class SimpleBreakfast
{
    public int Id { get; set;}
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    public SimpleBreakfast(){

    }

    public SimpleBreakfast(
        int id,
        string name,
        string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }


}