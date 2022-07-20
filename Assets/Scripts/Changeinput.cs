using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Changeinput : MonoBehaviour
{
    EventSystem system;
    public Selectable firstInput;
    public Button submitButton;
    // Start is called before the first frame update
    void Start()
    {
        firstInput.Select();
        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next!= null)
            {
                next.Select();
            }
        }
        if (Input.GetKey(KeyCode.Tab)&&Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp()  ;
            if (previous!= null)
            {
                previous.Select();
            }
        }
       
    }
}
