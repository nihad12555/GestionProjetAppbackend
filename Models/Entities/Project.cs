namespace GestionProjetAppBack.Models.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Priority { get; set; }
    public List<Tache> Taches { get; set; } = new List<Tache>();

}