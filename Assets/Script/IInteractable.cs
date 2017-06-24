using UnityEngine.EventSystems;

public enum InteractableType
{
    UI,
    PHYSICAL,
    PARTY,
    PARTY2,
    SURPRISE,
    NONE
}

public interface IInteractable {

    InteractableType GetInteractableType();

    void OnLookAtStart(PointerEventData ped);
    void OnLookAtEnd(PointerEventData ped);
    void OnInteract();

    string DebugText();
}
