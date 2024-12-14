//======================================================================================================================
//
// アプリケーションマネージャークラス[Application.cs]
//
//---- 詳細 ------------------------------------------------------------------------------------------------------------
// アプリケーションを管理するクラスを作成する。
// 
//----------------------------------------------------------------------------------------------------------------------
// 更新日     更新者        バージョン 更新内容
// ---------- ------------- ---------- ---------------------------------------------------------------------------------
// yyyy/MM/dd anonymous     xx.xx.xx   -
// 2024/12/15 大行佑也      00.00.01   新規作成
//======================================================================================================================
using System;
using UnityEngine;

namespace BTLGeek
{
    public class ApplicationManager : MonoBehaviour
    {
        //---- フィールド ----------------------------------------------------------------------------------------------

        //---- メソッド ------------------------------------------------------------------------------------------------
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            Com.g_strExeName = Application.productName;
            Com.g_strExeDir = Application.dataPath;

            // 各マネージャークラスの作成
            var ret = ApplicationManager.CreateManager();
            if (Com.GC_NG == ret) {
                // メッセージ出してプログラム終了
                Com.GFn_MessageBox($"起動に失敗しました。\nゲームを終了します。", Com.EMsgBoxButton.OK, Com.EMsgBoxIcon.Error);
                Application.Quit();
            }

            // セーブデータの読み込み


            // 共通リソースファイルの読み込み

        }
        /// <summary>
        /// 各マネージャークラスの作成
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        public static int CreateManager()
        {
            var rtn = Com.GC_OK;

            try {
                // アプリケーションマネージャー
                GameObject gameObject;
                gameObject = new GameObject("ApplicationManager");
                gameObject.AddComponent<ApplicationManager>();
                DontDestroyOnLoad(gameObject);
            }
            catch (Exception e) {
                Debug.LogException(e);
                rtn = Com.GC_NG;
            }

            return rtn;
        }

        /// <summary>
        /// セーブデータの読み込み
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        public static int LoadingSaveData()
        {
            return Com.GC_OK;
        }

        /// <summary>
        /// セーブデータの保存
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        public static int SavingSaveData()
        {
            return Com.GC_OK;
        }
    }
}
