using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ButtonMessageScript : MonoBehaviour
{
    public Button clickMeButton;                // Reference to the button
    public Text infoText;                       // Reference to the information text
    public GameObject imageTarget1;             // Reference to the first Image Target (Greeting card with audio)
    public GameObject imageTarget2;             // Reference to the second Image Target (Dance model)

    private ObserverBehaviour observer1;        // Observer for image target 1
    private ObserverBehaviour observer2;        // Observer for image target 2

    private void Start()
    {
        // Attach the OnClick event to the button
        clickMeButton.onClick.AddListener(ShowInfoMessage);

        // Ensure the infoText is initially hidden
        infoText.gameObject.SetActive(false);

        // Get the ObserverBehaviour components for both Image Targets
        observer1 = imageTarget1.GetComponent<ObserverBehaviour>();
        observer2 = imageTarget2.GetComponent<ObserverBehaviour>();

        // Disable tracking at the start
        if (observer1 != null)
        {
            observer1.enabled = false;
        }
        if (observer2 != null)
        {
            observer2.enabled = false;
        }
    }

    // Method to display the information message and enable tracking
    private void ShowInfoMessage()
    {
        // Set the message text
        infoText.text = "Scan the greeting card to see the surprise!";

        // Display the text
        infoText.gameObject.SetActive(true);

        // Hide the button after clicking
        clickMeButton.gameObject.SetActive(false);

        // Start a coroutine to enable tracking after showing the message for 5 seconds
        StartCoroutine(EnableTrackingAfterDelay(5f));
    }

    private IEnumerator EnableTrackingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide the info text after the delay
        infoText.gameObject.SetActive(false);

        // Enable Vuforia tracking on both Image Targets
        if (observer1 != null)
        {
            observer1.enabled = true;
        }
        if (observer2 != null)
        {
            observer2.enabled = true;
        }
    }
}



/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMessageScript : MonoBehaviour
{
    public Button clickMeButton;      // Reference to the button
    public Text infoText;             // Reference to the information text

    private void Start()
    {
        // Attach the OnClick event to the button
        clickMeButton.onClick.AddListener(ShowInfoMessage);

        // Ensure the infoText is initially hidden
        infoText.gameObject.SetActive(false);
    }

    // Method to display the information message and hide the button
    private void ShowInfoMessage()
    {
        // Set the message text
        infoText.text = "Scan the greeting card for a surprise!";
        
        // Display the text
        infoText.gameObject.SetActive(true);

        // Hide the button after clicking
        clickMeButton.gameObject.SetActive(false);

        // Start a coroutine to hide the message after 5 seconds
        StartCoroutine(HideInfoMessageAfterDelay(5f));
    }

    private IEnumerator HideInfoMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Hide the info text after the delay
        infoText.gameObject.SetActive(false);
    }
}

*/