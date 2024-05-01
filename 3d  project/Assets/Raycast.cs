using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float rayLength = 5;
    private Camera cam;

    private NoteController noteController;

    [SerializeField] private KeyCode interactKey;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                noteController = readableItem;
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }

        if (noteController != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                noteController.ShowNote();
            }
        }
    }

    void ClearNote()
    {
        if (noteController != null)
        {
            noteController = null;
        }
    }
}
