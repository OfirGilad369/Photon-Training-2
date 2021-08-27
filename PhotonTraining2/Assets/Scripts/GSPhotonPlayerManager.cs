using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GSPhotonPlayerManager : MonoBehaviour
{
    // Public Variable
    public MonoBehaviour[] mbScripts;

    // Private Variables
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        // Define the Photon View
        photonView = GetComponent<PhotonView>();

        // If this photon is NOT my view
        if (!photonView.IsMine)
        {
            // Loop through ALL other photon views and disable all the scripts on them
            foreach (var scriptToDisable in mbScripts)
            {
                // Disable The Scripts
                scriptToDisable.enabled = false;
            }
        }
    }
}
