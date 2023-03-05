using UnityEngine;

public class RandomStringGenerator : MonoBehaviour
{
    private string[] adjectives = { "青い", "美味しい", "大きい", "小さい", "新しい", "古い", "柔らかい", "硬い", "速い", "遅い" };
    private string[] nouns = { "猫", "犬", "本", "山", "海", "空", "花", "鳥", "音楽", "夢" };

    private void Update(){
        string randomString = GenerateRandomString();
        Debug.Log(randomString);

    }
    private string GenerateRandomString()
    {
        string adjective = adjectives[Random.Range(0, adjectives.Length)];
        string noun = nouns[Random.Range(0, nouns.Length)];
        int number = Random.Range(1, 100);

        string randomString = $"私は{adjective} {noun}が好きです。{number}回も見ました！";
        return randomString;
    }
}