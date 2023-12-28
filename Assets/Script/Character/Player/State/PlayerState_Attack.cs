using UnityEngine;

namespace BTLGeek.Character.Player.State
{
    public class PlayerState_Attack : Common.State<Player>
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
        protected override void Start()
        {
            // 基底クラスのStartメソッドを先に実行する。
            base.Start( );
            // 
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {

        }
    }
}
