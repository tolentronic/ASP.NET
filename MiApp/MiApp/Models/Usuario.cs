using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreUsuario { get; set; }

    [Required]
    public string Contraseña { get; set; }
}