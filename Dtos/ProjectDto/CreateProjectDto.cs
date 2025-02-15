using System.ComponentModel.DataAnnotations;

namespace GestionProjetAppBack.Dtos.ProjectDto;

public class CreateProjectDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public string Priority { get; set; }
}