using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessloidBlock : MonoBehaviour {

    Tesseloid tesseloid;
    public LayerMask collisionMask;

	// Use this for initialization
	void Start () {
        tesseloid = GetComponentInParent<Tesseloid>();
	}


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, collisionMask);

        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 1f));

        if (hit.collider != null && !tesseloid.placed) {
            if (hit.collider.tag == "Block") {
                Debug.Log("Hitting block...");
                Tesseloid hitTesseloid = hit.collider.gameObject.GetComponent<TessloidBlock>().tesseloid;

                if (!hitTesseloid.placed) {
                    Debug.Log("Hit own block...do nothing.");
                    return;
                }

                Debug.Log("Hit placed block - place me!");
                tesseloid.placed = true;
                return;
            } else if (hit.collider.tag == "Ground") {
                Debug.Log("Hit ground - place me!");

                tesseloid.placed = true;
            }

        }
    }

}
