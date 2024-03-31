using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Core;

public class Contact
{
    [Required]
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    public string? Phone { get; set; }
    public string? Address { get; set; }
} 