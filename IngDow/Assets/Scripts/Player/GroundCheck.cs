using System;
using UnityEngine;

namespace Player {
    public class GroundCheck : MonoBehaviour {
        private GameObject Player;

        private void Start() {
            Player = gameObject.transform.parent.gameObject;
        }

        
    }
}
