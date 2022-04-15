using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_Trap : MonoBehaviour
{
    SUD_Died sUD_Died;
    SUD_GetHit sUD_GetHit;
    public Player player;
    public Animator playerAni;
    public int damage;
    public Renderer[] renderers;
    public Vector3 attackVelocity;
    public GameObject bloodEffect;
    GameObject blood;

    void Awake() {
        bloodEffect = GameObject.Find("HitEffect");
        sUD_Died = GameObject.Find("Died").GetComponent<SUD_Died>();
        sUD_GetHit = GameObject.Find("GetHit").GetComponent<SUD_GetHit>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerAni = player.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            attackVelocity = (other.gameObject.transform.position - gameObject.transform.position).normalized;
            playerAni.SetTrigger("isUnBeatTime");
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(attackVelocity.x * 5, 0, attackVelocity.z * 5), ForceMode.Impulse);
            blood = Instantiate(bloodEffect, other.gameObject.transform.position, gameObject.transform.rotation);
            Invoke("Delete", 0.5f);
            player.hp -= damage;
            if (player.hp > 1) {
                sUD_GetHit.GetHitSound();
                player.isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
            else {
                sUD_GetHit.gameObject.GetComponent<AudioSource>().Stop();
                sUD_Died.GetDiedSound();
                playerAni.SetTrigger("Dead");
            }
        }
    }

    IEnumerator UnBeatTime() {
        int countTime = 0;

        while (countTime < 10) {
            if (countTime % 2 == 0)
                for (int i = 0; i < renderers.Length; i++)
                    renderers[i].material.color = new Color32(255,255,255,90);
            else
                for (int i = 0; i < renderers.Length; i++)
                    renderers[i].material.color = new Color32(255,255,255,180);
            yield return new WaitForSeconds(0.1f);

            countTime++;
        }
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].material.color = new Color32(255,255,255,255);

        player.isUnBeatTime = false;
        yield return null;
    }

    void Delete() {
        if (blood)
            Destroy(blood);
    }

}
