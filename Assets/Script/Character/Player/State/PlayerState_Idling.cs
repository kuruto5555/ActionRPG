using UnityEngine;

namespace BTLGeek.Character.Player.State
{
    public class PlayerState_Idling : Common.State<Player>
    {
        /// <summary>
        /// インスタンス生成時に呼ばれる
        /// </summary>
        void Awake()
        {

        }

        /// <summary>
        /// Updateが初めて呼ばれる際に一度だけ呼ばれる
        /// </summary>
        void Start()
        {
            // オーナーチェック
            if (null == Owner) {
                Debug.LogError(name + "にオーナーが設定されていません！");
            }
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {

        }
    }
}
