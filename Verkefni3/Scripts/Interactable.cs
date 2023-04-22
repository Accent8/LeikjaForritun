using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    public Transform Player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }

    void Update()
    {
        if(!hasInteracted)
        {
            float distance = Vector3.Distance(Player.position, interactionTransform.position);
            if (distance <= radius) 
            {
                Interact();
                hasInteracted = true;
            }
        }    
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
 