using UnityEngine;
// fall fyrir öll interactions sem player eða enemy hafa
public class Interactable : MonoBehaviour
{
    // hversu stór radíus er til að geta interactað
    public float radius = 3f;
    // transform fyrir interaction object
    public Transform interactionTransform;
    // og svo bara playerinn
    public Transform Player;
    // hvort að object eða item hafa interactað
    bool hasInteracted = false;
    // virtual void til að geta breytt þessu fyrir allt sem hefur interactable
    public virtual void Interact()
    {
        // bara smá fyrir mig í unity
        Debug.Log("Interacting with" + transform.name);
    }

    void Update()
    {   // skoðar hvort að item hefur interactað
        if(!hasInteracted)
        {   // skoðar distance frá player og objecti sem hann ætlar að interacta við
            float distance = Vector3.Distance(Player.position, interactionTransform.position);
            // ef það er minna en radíus
            if (distance <= radius) 
            {   // þá kalla ég á interact fallið
                Interact();
                // og segi að object hefur interactað
                hasInteracted = true;
            }
        }    
    }
    // svo bara drawGizmos fyrir mig í unity til að geta séð þarf ekkert að útskýra þetta
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}