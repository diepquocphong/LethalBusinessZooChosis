using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomComment : MonoBehaviour
{

    public TextMeshProUGUI commentText;  // Text component to display comments
    private string[] comments = new string[] {
        "Awesome stream!", "Great job!", "Wow, amazing!", "This is so cool!", "Love it!",
        "Keep it up!", "You're doing great!", "So entertaining!", "Can't stop watching!",
        "Fantastic!", "You're a legend!", "Nice moves!", "This is epic!", "I'm impressed!",
        "Hilarious!", "Best stream ever!", "You're on fire!", "Go for it!", "Unbelievable!",
        "So much fun!", "You're killing it!", "Amazing skills!", "Great content!",
        "This is awesome!", "Such talent!", "I'm hooked!", "You're amazing!", "This is insane!",
        "So good!", "Incredible!", "Loving this!", "Wow, just wow!", "You rock!", "Keep going!",
        "Pure gold!", "You're the best!", "This is hilarious!", "Can't get enough!",
        "Mind-blowing!", "Awesome work!", "So entertaining!", "You're a star!", "Keep crushing it!",
        "Too funny!", "Absolutely brilliant!", "This is wild!", "Loving the energy!",
        "Keep up the good work!", "Epic stream!", "You're so talented!", "This is amazing!",
        "Laughing so hard!", "You're incredible!", "This is great!", "So much talent!",
        "Loving this stream!", "You're a genius!", "This is gold!", "Keep rocking!", "So good!",
        "Fantastic stream!", "You're unstoppable!", "This is epic!", "Hilarious content!",
        "You're on point!", "Loving the vibes!", "Amazing!", "You're a pro!", "Can't look away!",
        "Best content ever!", "This is fire!", "Keep it up!", "Loving this!", "You're on fire!",
        "Wow, incredible!", "So entertaining!", "You nailed it!", "Pure talent!", "This is awesome!",
        "Keep going strong!", "You're the best!", "This is hilarious!", "So much fun!",
        "Wow, just wow!", "You're amazing!", "This is insane!", "Loving every minute!",
        "You're killing it!", "This is brilliant!", "Amazing stream!", "Can't stop laughing!",
        "You're incredible!", "This is great!", "So much talent!", "Loving the stream!",
        "You're a legend!", "This is gold!", "Keep it up!", "So good!", "Fantastic!",
        "You're unstoppable!", "This is epic!", "Hilarious!", "You're on point!", "Loving the vibes!",
        "Amazing content!", "You're a pro!", "Can't look away!", "Best stream ever!", "This is fire!",
        "Keep it up!", "Loving this!", "You're on fire!", "Wow, incredible!", "So entertaining!",
        "You nailed it!", "Pure talent!", "This is awesome!", "Keep going strong!", "You're the best!",
        "This is hilarious!", "So much fun!", "Wow, just wow!", "You're amazing!", "This is insane!",
        "Loving every minute!", "You're killing it!", "This is brilliant!", "Amazing stream!",
        "Can't stop laughing!", "You're incredible!", "This is great!", "So much talent!",
        "Loving the stream!", "You're a legend!", "This is gold!", "Keep it up!", "So good!",
        "Fantastic!", "You're unstoppable!", "This is epic!", "Hilarious!", "You're on point!",
        "Loving the vibes!", "Amazing content!", "You're a pro!", "Can't look away!", "Best stream ever!",
        "This is fire!", "Keep it up!", "Loving this!", "You're on fire!", "Wow, incredible!",
        "So entertaining!", "You nailed it!", "Pure talent!", "This is awesome!", "Keep going strong!",
        "You're the best!", "This is hilarious!", "So much fun!"
    };
    public void SelectRandomConmment()
    {
        // Kiểm tra xem danh sách tên có phần tử hay không
        if (comments.Length > 0)
        {
            // Chọn một tên ngẫu nhiên từ danh sách
            string randomComment = comments[Random.Range(0, comments.Length)];

            // Thay đổi text của biến đối tượng public nameText
            if (commentText != null)
            {
                commentText.text = randomComment;
            }
            else
            {
                Debug.LogWarning("Bạn chưa gán đối tượng TextMeshPro cho biến nameText.");
            }
        }
        else
        {
            Debug.LogWarning("Danh sách tên trống. Vui lòng thêm các tên vào danh sách.");
        }
    }
}
