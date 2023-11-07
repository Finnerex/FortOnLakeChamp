
public interface IInteractable
{
    
    // defines what this thing does when the player interacts with it
    // returns if the interaction was successful (it was not cancelled) (may or may not use this information)
    bool OnInteract();
    
}
