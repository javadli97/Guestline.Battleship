using Guestline.Battleship.BLL.GameLogic;
using Guestline.Battleship.BLL.Requests;
using Guestline.Battleship.BLL.Responses;

namespace Guestline.Battleship
{
    public class GameFlow
    {
        GameState gm;

        public GameFlow()
        {
            gm = new GameState() { Board = new Board() };
        }

        public void Start()
        {
            GameSetup GameSetup = new GameSetup(gm);

            do
            {
                GameSetup.SetBoard();
                FireShotResponse shotresponse;
                do
                {
                    ControlOutput.ResetScreen();
                    ControlOutput.DrawHistory(gm.Board);
                    Coordinate ShotPoint = new Coordinate(1, 1);
                    shotresponse = Shot(gm.Board, out ShotPoint);
                    
                    ControlOutput.ShowShotResult(shotresponse, ShotPoint, "");                  
                } while (shotresponse.ShotStatus != ShotStatus.Victory);

            } while (ControlInput.CheckQuit());
        }


        private FireShotResponse Shot(Board board, out Coordinate ShotPoint)
        {
            FireShotResponse fire; Coordinate WhereToShot;
            do
            {

                WhereToShot = ControlInput.GetShotLocationFromUser();
                fire = board.FireShot(WhereToShot);
                if (fire.ShotStatus == ShotStatus.Invalid || fire.ShotStatus == ShotStatus.Duplicate)
                    ControlOutput.ShowShotResult(fire, WhereToShot, "");                
            } while (fire.ShotStatus == ShotStatus.Duplicate || fire.ShotStatus == ShotStatus.Invalid);
            ShotPoint = WhereToShot;
            return fire;
        }
    }
}
