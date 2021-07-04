using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 10f;
    [SerializeField] private GameObject menu;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void Update() 
    {
        ToggleMenu();    
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);        
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    private void ToggleMenu()
    {
        if(Input.GetKeyDown(KeyCode.I))
            menu.SetActive(!menu.activeInHierarchy);

        else if(Input.GetKeyDown(KeyCode.Escape) && menu.activeInHierarchy)
            menu.SetActive(false);
    }
}
