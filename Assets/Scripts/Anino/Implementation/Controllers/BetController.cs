using Anino.Framework;
using Zenject;

namespace Anino.Implementation
{
    public class BetController : IBetController
    {
        const int BASE_BET = 100;
        const int MAX_BET = 20;
        
        public long betAmount => _betAmount;
        private long _betAmount;
        private int _multiplier;
        private IBetView _view;
        [Inject] ICurrencyService _currencyService;
        
        public BetController()
        {
            _multiplier = 1;
            _betAmount = BASE_BET * _multiplier;
        }

        public void SetView(IBetView view)
        {
            _view = view;
            _view.UpdateBet(_betAmount);   
            _currencyService.SetBet(_betAmount); 
        }

        public void IncreaseBet()
        {
            _multiplier++;
            if(_multiplier>=MAX_BET)
                _multiplier = MAX_BET;
            
            _betAmount = BASE_BET * _multiplier;
            _view.UpdateBet(_betAmount);
            _currencyService.SetBet(_betAmount);
        }

        public void DecreaseBet()
        {
            _multiplier--;
            if(_multiplier<=0)
                _multiplier = 1;
                
            _betAmount = BASE_BET * _multiplier;
            _view.UpdateBet(_betAmount);
            _currencyService.SetBet(_betAmount);
        }
    }
}