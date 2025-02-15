namespace GestionProjetAppBack.Dtos.TacheDto;

public class ModifierTacheDTO
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
    public bool EstTerminee { get; set; }

    public DateTime DateLimite { get; set; }
    public string Responsable { get; set; }
    public int ProjetId { get; set; }
}