using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTLGeek.Common
{
    public class ApplicationManager : MonoBehaviour
    {
        /*---- メンバ変数 ----*/
        public string       m_exeName      = string.Empty;      // 実行ファイル名
        public string       m_exeDir       = string.Empty;      // プログラムの実行ディレクトリフルパス


        /// <summary>
        /// プログラム起動時に呼ばれる。
        /// </summary>
        /// <remarks>
        /// プログラム起動後の、ウィンドウが開かれる前に実行される。
        /// 以下を処理を実行
        /// ・各マネージャークラスの作成。
        /// ・セーブデータの読み込み。
        /// ・リソースファイルの読み込み
        /// </remarks>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
//        [RuntimeInitializeOnLoadMethod]
        private static void Main()
        {
            // 各マネージャークラスの作成
            CreateManager( );

            // セーブデータの読み込み
            LoadingSaveData( );

            // 共通リソースファイルの読み込み

        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 各マネージャークラスの作成
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        private static int CreateManager()
        {
            // アプリケーションマネージャー
            GameObject gameObject;
            gameObject = new GameObject("ApplicationManager");
            gameObject.AddComponent<ApplicationManager>();
            DontDestroyOnLoad(gameObject);

            // 入力マネージャ
            gameObject = new GameObject("InputManager");
            gameObject.AddComponent<InputManager>( );
            DontDestroyOnLoad(gameObject);

            // サウンドマネージャー
            gameObject = new GameObject("SoundManager");
            gameObject.AddComponent<SoundManager>( );
            DontDestroyOnLoad(gameObject);

            return Const.RETURN_OK;
        }

        /// <summary>
        /// セーブデータの読み込み
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        public static int LoadingSaveData()
        {
            return Const.RETURN_OK;
        }

        /// <summary>
        /// セーブデータの保存
        /// </summary>
        /// <returns>実行結果(0:正常 -1:異常)</returns>
        public static int SavingSaveData()
        {
            return Const.RETURN_OK;
        }
    }
}
