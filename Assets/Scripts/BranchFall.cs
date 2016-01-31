using UnityEngine;
using System.Collections;

public class BranchFall : MonoBehaviour {
    private bool falling = false;
    private Vector3 position;
    private float startPosTriggered;
    private float startPosOk;
    private Sprite newSprite;
    private GameObject triggeredBranch;
    public static BranchFall thisBranchFall;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            toggle_branches();
            falling = true;
            
        }
    }

    // Use this for initialization
    void Start () {
        thisBranchFall = this;
        triggeredBranch = GameObject.Find("branch_triggered");
        this.startPosTriggered = triggeredBranch.transform.position.y;
        this.startPosOk = this.transform.position.y;
        reset();
    }

    void toggle_branches()
    {
        triggeredBranch = GameObject.Find("branch_triggered");
        triggeredBranch.GetComponent<SpriteRenderer>().enabled = true;

        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // reset everything back to start
    public void reset()
    {
        triggeredBranch = GameObject.Find("branch_triggered");
        falling = false;

        triggeredBranch.transform.position.Set(triggeredBranch.transform.position.x, this.startPosTriggered, triggeredBranch.transform.position.z);
        GameObject branchOk = GameObject.Find("branch_ok");
        branchOk.GetComponent<Collider2D>().enabled = true;
        branchOk.GetComponent<SpriteRenderer>().enabled = true;
        branchOk.transform.position.Set(branchOk.transform.position.x, this.startPosOk, branchOk.transform.position.z);

        SpriteRenderer sprender;
        sprender = triggeredBranch.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }

	// Update is called once per frame
	void Update () {
	    if (falling && triggeredBranch != null && triggeredBranch.transform.position.y > -2.4)
        {
            this.position = triggeredBranch.transform.position;
            this.position.y -= 0.1f;
            triggeredBranch.transform.position = this.position;
        }
	}
}
