using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DebugLogViewer : MonoBehaviour
{
    // デバッグ用のテキストオブジェクト
    private Text debugText;

    // ログの最大表示数
    [SerializeField]
    private int maxLogs = 5;

    // 表示されるログを保持するリスト
    private List<string> logList = new List<string>();

    // アプリケーション起動時に実行される処理
    void Start()
    {
        // アプリケーションのログを取得するためのハンドラーを設定
        Application.logMessageReceived += ConsoleLogHandler;

        // デバッグ用のテキストオブジェクトを生成
        CreateDebugText();
    }

    // フレーム毎に実行される処理
    void Update()
    {
        // デバッグ用のテキストを更新
        UpdateDebugText();
    }

    // デバッグ用のテキストを生成する
    void CreateDebugText()
    {
        // デバッグ用のキャンバスを生成
        GameObject canvasGameObject = new GameObject("DebugCanvas");
        Canvas canvas = canvasGameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasGameObject.AddComponent<GraphicRaycaster>();

        // デバッグ用のテキストオブジェクトを生成し、キャンバスに配置する
        debugText = new GameObject("DebugText").AddComponent<Text>();
        debugText.rectTransform.SetParent(canvas.transform);
        debugText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        debugText.color = Color.grey;
        debugText.fontSize = 24;
        debugText.alignment = TextAnchor.MiddleCenter;
        debugText.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        debugText.rectTransform.anchoredPosition = Vector2.zero;
    }

    // デバッグ用のテキストを更新する
    void UpdateDebugText()
    {
        // ログリストの内容をテキストに反映する
        string logText = "";
        for (int i = logList.Count - 1; i >= 0; i--)
        {
            logText += logList[i] + "\n";
        }
        debugText.text = logText;
    }

    // アプリケーションのログを取得するためのハンドラー
    void ConsoleLogHandler(string logText, string stackTrace, LogType type)
    {
        // ログリストにログを追加する
        logList.Add(logText);
        // ログリストが最大表示数を超えた場合、先頭の要素を削除する
        if (logList.Count > maxLogs)
        {
            logList.RemoveAt(0);
        }
    }
}