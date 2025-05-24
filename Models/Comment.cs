namespace pc3_progra.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PostId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }
}