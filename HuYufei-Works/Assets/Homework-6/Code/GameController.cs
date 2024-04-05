

namespace Game.CLS6
{
    using UnityEngine;
    using UnityEngine.UI;
    
    public class GameController: MonoBehaviour
    {

        private static GameController _instance;
        public static GameController Instance => _instance;

        private static bool _initOnce;

        public UIPlayerIcon _playerIcon;
        public UIPlayerIcon _aiIcon;
        public Button _btnBU;
        public Button _btnJD;
        public Button _btnST;
        public Text _score;
        

        void Awake()
        {
            InitGame();
        }

        private void InitGame()
        {
            if (_initOnce) return;
            _initOnce = true;
            _instance = this;
            
            GlobalState.AiScore = 0;
            GlobalState.PlayerScore = 0;
            
            _btnBU.onClick.AddListener(()=>OnPlayerCall(IconType.BU));
            _btnJD.onClick.AddListener(()=>OnPlayerCall(IconType.JD));
            _btnST.onClick.AddListener(()=>OnPlayerCall(IconType.ST));
        }



        public void OnPlayerCall(IconType type)
        {
            var host = type;
            _playerIcon.SetIcon(host);
            
            var guest = GetAiCall();
            _aiIcon.SetIcon(guest);
            
            int result = OnRoundResult(host, guest);
            if (result == 1)
            {
                GlobalState.PlayerScore++;
            }
            else if (result == -1)
            {
                GlobalState.AiScore++;
            }
            
            _score.text = $"{GlobalState.PlayerScore} : {GlobalState.AiScore}";
        }


        private IconType GetAiCall()
        {
            int t = Random.Range(0, 3);
            return (IconType) t;
        }


        public int OnRoundResult(IconType host, IconType guest)
        {
            var hostVal = (int)host;
            var guestVal = (int)guest;
            
            if (hostVal == 2 && guestVal ==0) return -1;
            if (hostVal == 0 && guestVal == 2) return 1;
            if (hostVal == guestVal) return 0;
            if (hostVal > guestVal)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


    }
}