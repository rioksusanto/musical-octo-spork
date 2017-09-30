using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f; // Default speed sensitivity
    public ProjectileController projectilePrefab;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
        }*/
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mouseScreenPos = Input.mousePosition;
            float distanceFromCameraToXZPlane = Camera.main.transform.position.y;
            Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
            Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

            ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
            p.transform.position = this.transform.position;
            p.velocity = (fireToWorldPos - this.transform.position).normalized * 10.0f;
        }
    }
}
