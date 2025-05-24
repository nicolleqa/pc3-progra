namespace pc3_progra.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public int UserId { get; set; }
    
    [NotMapped]
    public User? Author { get; set; }
    
    [NotMapped]
    public List<Comment>? Comments { get; set; }
}