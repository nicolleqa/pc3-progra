namespace pc3_progra.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PostId { get; set; }
    public string? Sentimiento { get; set; } // "like" o "dislike"
    public DateTime Fecha { get; set; }
}