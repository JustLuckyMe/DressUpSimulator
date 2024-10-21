using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ShowCharacter : MonoBehaviour
{
    Camera cam;
    [SerializeField] GameObject CanvasUI;
    [SerializeField] GameObject EndingUI;
    [SerializeField] Transform character;
    [SerializeField] public MMF_Player mMFeedback;
    public float orbitSpeed = 1f;
    private bool canSpin = false;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (character == null)
        {
            Debug.LogWarning("Character object is not assigned.");
            return;
        }

        if (canSpin)
        {
            // Rotate the camera around the character in an orbit
            cam.transform.RotateAround(character.position, Vector3.up, orbitSpeed * Time.deltaTime);        
        }
    }

    public void Done()
    {
        mMFeedback.PlayFeedbacks();
        canSpin = true;
        CloseUI();
        EndingUI.SetActive(true);
        SetPlayerPosition();
    }

    public void CloseUI()
    {
        CanvasUI.SetActive(false);
    }

    private void SetPlayerPosition()
    {
        character.rotation = Quaternion.Euler(0, 180, 0);
    }
}
