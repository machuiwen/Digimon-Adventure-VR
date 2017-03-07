using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {
    public string AnimationName;
    public Animator stateMachine;

    private bool created = false;

    void Awake() {
        if (GvrViewer.Instance == null) {
            GvrViewer.Create();
            created = true;
        }
    }

    void Start() {
        if (created) {
            foreach (Camera c in GvrViewer.Instance.GetComponentsInChildren<Camera>()) {
                c.enabled = false; // to use the Gvr SDK without adding cameras we have to disable them
            }
        }

    }

    void Update() {
        GvrViewer.Instance.UpdateState(); //need to update the data here otherwise we dont get mouse clicks; this is because we are automatically creating the GVRSDK (seems like a bug)
        if (GvrViewer.Instance.Triggered)
            stateMachine.SetTrigger(AnimationName);
    }

}