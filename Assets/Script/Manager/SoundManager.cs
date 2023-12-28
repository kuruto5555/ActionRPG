using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTLGeek.Common
{
    public class SoundManager : Singleton<SoundManager>
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
