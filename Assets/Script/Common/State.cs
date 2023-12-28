using UnityEngine;

namespace BTLGeek.Common
{
    /// <summary>
    /// ステートクラス
    /// </summary>
    /// <typeparam name="T">ステートの所持者</typeparam>
    public abstract class State<T> : MonoBehaviour where T : MonoBehaviour
    {
        /*---- プロパティ ----*/
        /// <summary>
        /// 所持者
        /// </summary>
        [field:Header("所持者")]
        [field:Tooltip("ステートから参照したいクラスを設定してください")]
        [field:SerializeField]
        protected T Owner { get; set; } = null;

        /*---- メソッド ----*/
        protected virtual void Start()
        {
            // オーナーチェック
            if (null == Owner) {
                Debug.LogError(name + "にオーナーが設定されていません！");
            }
        }

        /// <summary>
        /// ステート変更
        /// </summary>
        /// <typeparam name="S">変更するステート</typeparam>
        protected void ChangeState<S>() where S : State<T>, new()
        {
            // 次のステートを生成
            State<T> state = gameObject.AddComponent<S>();

            // 次のステートに所有者を設定
            state.Owner = Owner;

            // 現在のStateを破棄
            Destroy(this);
        }
    }
}
