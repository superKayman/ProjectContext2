using UnityEngine;
using UnityEngine.UI;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    private bool strawsCollected = false;
    public static bool inStrawRange = false;

    public GameObject paperStraws;
    public GameObject plasticStraws;
    public Text strawCheckbox;

    public GameObject paperStrawFish;
    public GameObject plasticStrawFish;

    public static int checkoutNumber = 0;

    Vector2 velocity;
    Vector2 frameVelocity;

    Ray ray;
    RaycastHit hit;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        checkoutNumber = 0;

        paperStraws.SetActive(false);
        plasticStraws.SetActive(false);
        strawCheckbox.enabled = false;
        paperStrawFish.SetActive(false);
        plasticStrawFish.SetActive(false);
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        //Raycast
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                print(hit.collider.name);

                if (inStrawRange == true)
                {

                    if (hit.collider.tag == "Paper Straws" && strawsCollected == false)
                    {
                        strawsCollected = true;
                        paperStraws.SetActive(true);
                        strawCheckbox.enabled = true;
                        paperStrawFish.SetActive(true);
                        checkoutNumber++;
                    }

                    if (hit.collider.tag == "Plastic Straws" && strawsCollected == false)
                    {
                        strawsCollected = true;
                        plasticStraws.SetActive(true);
                        strawCheckbox.enabled = true;
                        plasticStrawFish.SetActive(true);
                        checkoutNumber++;
                    }
                }
            }

        }
    }
}
