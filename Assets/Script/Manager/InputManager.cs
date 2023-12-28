using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace BTLGeek.Common
{
    public class InputManager : Singleton<InputManager>
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt)) {
                Cursor.visible = true;
                // フルスクリーンか？
//                if () {
//                    // フルスクリーンの場合は画面内の移動に固定
//                    Cursor.lockState = CursorLockMode.Confined;
//                }
//                else {
                    // ウィンドウ・仮想フルスクリーンの場合は制限なし
                    Cursor.lockState = CursorLockMode.None;
//                }
            }
            if (Input.GetKeyUp(KeyCode.LeftAlt)) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
