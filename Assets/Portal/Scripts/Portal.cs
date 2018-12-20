using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Portal : MonoBehaviour
{

    public GameObject GO_outputPortal;
    Portal outputPortal;
    GameObject GO_player;
    Transform camTransform, outCamTransform, playerCamTransform;
    Camera cam, outCam;
    MeshRenderer meshRenderer;
    FirstPersonController playerController;

    public float _PortalDelay = 1;
    public int _DebugPortalNumber = 0;

    bool overlapping = false, teleported = false;
    bool coroutineInProcess = false;

    void Start()
    {
        outputPortal = GO_outputPortal.GetComponent<Portal>();
        GO_player = GameObject.FindGameObjectWithTag("Player");
        camTransform = GetComponentsInChildren<Transform>()[1];
        playerCamTransform = GO_player.GetComponentsInChildren<Transform>()[1];
        outCamTransform = GO_outputPortal.GetComponentsInChildren<Transform>()[1];
        playerController = GO_player.GetComponent<FirstPersonController>();

        SetTexture();
    }

    void Update()
    {
        //Teleport();
        print(_DebugPortalNumber + "- " + teleported);
        if (teleported && !coroutineInProcess)
        {
            StartCoroutine("Delay");
            print("Coroutine executed");
        }
    }

    void LateUpdate()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {
        float angularDifferenceBetweenPortals = Quaternion.Angle(transform.rotation, GO_outputPortal.transform.rotation);
        //print("angular " + angularDifferenceBetweenPortals);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortals, Vector3.up);
        Vector3 newCameraDir = portalRotationalDifference * playerCamTransform.forward;
        //print("newCameraDir: " + newCameraDir);
        cam.transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);

        Vector3 playerOffsetFromPortal = playerCamTransform.position - GO_outputPortal.transform.position;
        //Vector3 playerOffsetFromPortal = GO_outputPortal.transform.position-playerCamTransform.position;
        //camTransform.position = transform.position + playerOffsetFromPortal;

        camTransform.position = transform.position + portalRotationalDifference * playerOffsetFromPortal;
        camTransform.RotateAround(transform.position, Vector3.up, portalRotationalDifference.eulerAngles.y);
    }

    void SetTexture()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        cam = GetComponentInChildren<Camera>();
        outCam = GO_outputPortal.GetComponentInChildren<Camera>();

        if (outCam.targetTexture != null)
        {
            outCam.targetTexture.Release();
        }
        outCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        meshRenderer.material.SetTexture("_MainTexture", outCam.targetTexture);
    }

    void Teleport()
    {
        if (teleported)
        {
            print("return");
            return;
        }
        GO_player.SetActive(false);
        float rotDiff = Quaternion.Angle(transform.rotation, GO_outputPortal.transform.rotation);
        rotDiff += 180;
        playerController.m_MouseLook.m_CharacterTargetRot *= Quaternion.Euler(0, rotDiff, 0);

        Vector3 portalToPlayer = GO_player.transform.position - transform.position;
        Vector3 positionOffset = Quaternion.Euler(0, rotDiff, 0) * portalToPlayer;
        print(_DebugPortalNumber + "- PositionOffset: " + positionOffset);
        GO_player.transform.position = GO_outputPortal.transform.position + portalToPlayer;
        GO_player.SetActive(true);

        print("Teleported from " + _DebugPortalNumber);
        outputPortal.teleported = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Teleport();
            SceneManager.LoadScene("Puzzle2");
        }
    }

    IEnumerator Delay()
    {
        coroutineInProcess = true;
        yield return new WaitForSeconds(_PortalDelay);
        coroutineInProcess = false;
        teleported = false;
    }
}
