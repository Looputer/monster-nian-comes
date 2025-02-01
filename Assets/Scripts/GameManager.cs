using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int _playerLifes = 10;

    public int PlayerLifes
    {
        get { return _playerLifes; }
        set
        {
            _playerLifes = value;
            if (_playerLifes <= 0)
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }
}
