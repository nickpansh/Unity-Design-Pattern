using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DirtyFlag
{
    public class UnsavedChangesController : MonoBehaviour
    {
        public Player player;


        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.Move(Vector3.forward);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.Move(-Vector3.forward);
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.Move(-Vector3.right);
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.Move(Vector3.right);
            }
            //
            player.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
        }



        private void OnGUI()
        {
            if (GUILayout.Button("Save"))
            {
                Debug.Log("Game was saved");
                player.OnSaved();

            }

            if (!player.isSaved)
            {
                GUILayout.Box("Warning you have unsaved changes");
            }
        }
    }
}