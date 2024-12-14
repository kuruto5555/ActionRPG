﻿//======================================================================================================================
//
// ステートパターン[State.cs]
//
//---- 詳細 ------------------------------------------------------------------------------------------------------------
// ステートパターンクラスを定義する。
// 
//----------------------------------------------------------------------------------------------------------------------
// 更新日     更新者        バージョン 更新内容
// ---------- ------------- ---------- ---------------------------------------------------------------------------------
// yyyy/MM/dd anonymous     xx.xx.xx   -
// 2024/12/15 大行佑也      00.01.00   新規作成
//======================================================================================================================
using UnityEngine;

namespace BTLGeek.DesignPattern
{
    /// <summary>
    /// ステートクラス
    /// </summary>
    /// <typeparam name="T">ステートの所持者</typeparam>
    public abstract class State<T> : MonoBehaviour where T : MonoBehaviour
    {
        //---- プロパティ ----------------------------------------------------------------------------------------------
        [field: Header("所持者")]
        [field: Tooltip("ステートから参照したいオブジェクトを設定してください")]
        [field: SerializeField]
        protected T Owner { get; private set; } = null;

        //---- メソッド ------------------------------------------------------------------------------------------------
        /// <summary>
        /// スタート関数
        /// </summary>
        protected virtual void Start()
        {
            // オーナーチェック
            if (null == Owner) {
                Debug.LogError($"{name}にオーナーが設定されていません！");
            }
        }

        /// <summary>
        /// ステート変更
        /// </summary>
        /// <typeparam name="S">変更するステート</typeparam>
        protected void LFnChangeState<S>() where S : State<T>, new()
        {
            // 次のステートを生成し、オーナーを教える
            gameObject.AddComponent<S>().Owner = Owner;

            // 現在のステートを破棄
            Destroy(this);
        }

        #region エディター上の機能
        /// <summary>
        /// アタッチ時に呼ばれる
        /// </summary>
        private void Reset()
        {
            // オーナーの取得
            Owner = GetComponent<T>();
        }
        #endregion
    }
}