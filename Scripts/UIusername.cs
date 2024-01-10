using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class UIManager : MonoBehaviour
{
    public Text usernameText;

    void Start()
    {
        // 在这里调用一个函数，该函数用于获取用户信息并更新 UI
        GetPlayerInfoAndUpdateUI();
    }

    void GetPlayerInfoAndUpdateUI()
    {
        // 使用 PlayFab API 获取用户信息
        var request = new GetPlayerProfileRequest();
        PlayFabClientAPI.GetPlayerProfile(request, OnGetPlayerProfileSuccess, OnFail);
    }

    // 获取用户信息成功的回调
    private void OnGetPlayerProfileSuccess(GetPlayerProfileResult result)
    {
        // 检查结果是否包含有效数据
        if (result.PlayerProfile != null)
        {
            // 获取玩家的显示名称（可以用作用户名）
            string username = result.PlayerProfile.DisplayName;

            // 更新 UI 中的 Text 组件
            if (usernameText != null)
            {
                usernameText.text = username ;
            }
        }
        else
        {
            Debug.LogError("玩家资料为空或缺少数据。");
        }
    }

    // 请求失败的回调
    private void OnFail(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}