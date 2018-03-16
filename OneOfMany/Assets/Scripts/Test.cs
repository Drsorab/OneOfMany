//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//public class Test : MonoBehaviour {

//    int[,] grid = new int[5, 5];
//    Cell myPos = new Cell(-1,-1);
//    Cell hisPos = new Cell(-1, -1);
//    static int gridSize = 5;
//    static int player = 0;
//    // Use this for initialization
//    void Start () {
//        //for (int i = 0; i < grid.GetLength(0); i++) {
//        //    for (int j = 0; j < grid.GetLength(1); j++) {
//        //        grid[i, j] = 0;
//        //    }
//        //}
//        grid[0, 0] = 0;
//        grid[1, 0] = 0;
//        grid[2, 0] = 0;
//        grid[3, 0] = 0;
//        grid[4, 0] = 0;
//        //grid[5, 0] = 0;
//        //grid[6, 0] = 0;

//        grid[0, 1] = 0;
//        grid[1, 1] = 0;
//        grid[2, 1] = 0;
//        grid[3, 1] = 0;
//        grid[4, 1] = 0;
//        //grid[5, 1] = 0;
//        //grid[6, 1] = 0;

//        grid[0, 2] = 0;
//        grid[1, 2] = 1;
//        grid[2, 2] = 1;
//        grid[3, 2] = 0;
//        grid[4, 2] = 0;
//        //grid[5, 2] = 0;
//        //grid[6, 2] = 0;

//        grid[0, 3] = 0;
//        grid[1, 3] = 0;
//        grid[2, 3] = 1;
//        grid[3, 3] = 1;
//        grid[4, 3] = 0;
//        //grid[5, 3] = 0;
//        //grid[6, 3] = 0;

//        grid[0, 4] = 0;
//        grid[1, 4] = 0;
//        grid[2, 4] = 0;
//        grid[3, 4] = 0;
//        grid[4, 4] = 0;
//        //grid[5, 4] = 0;
//        //grid[6, 4] = 0;

//        //grid[0, 5] = 0;
//        //grid[1, 5] = 0;
//        //grid[2, 5] = 0;
//        //grid[3, 5] = 0;
//        //grid[4, 5] = 0;
//        //grid[5, 5] = 0;
//        //grid[6, 5] = 0;

//        //grid[0, 6] = 0;
//        //grid[1, 6] = 0;
//        //grid[2, 6] = 0;
//        //grid[3, 6] = 0;
//        //grid[4, 6] = 0;
//        //grid[5, 6] = 0;
//        //grid[6, 6] = 0;

//        myPos = new Cell( 2,3);
//        hisPos = new Cell(1,2);

//        //Game newGame = Minimax(new Game(grid, myPos, hisPos, null, 0),0,0);
//        Move fmove = AvailiableMoves(new Game(grid, myPos, hisPos, null, 0), myPos, hisPos);
//        int p = 0;
//    }
	
//	// Update is called once per frame
//	void Update () {
	
//	}

//    //static Game Minimax(Game game, int depth, int player)
//    //{
//    //    List<Move> availiableMoves = new List<Move>();
//    //    Cell curPlayerPos = null;
//    //    if (player == 0) {
//    //        availiableMoves = AvailiableMoves(game, game.playerPos, game.enemyPos);
//    //        curPlayerPos = game.playerPos;
//    //    }
//    //    else {
//    //        availiableMoves = AvailiableMoves(game, game.enemyPos, game.playerPos);
//    //        curPlayerPos = game.enemyPos;
//    //    }

//    //    int winCheck = CheckForWinner(game, availiableMoves.Count);
//    //    if ((winCheck > 90 || winCheck < -90) || availiableMoves.Count == 0 || depth == 1)
//    //    {
//    //        game.score = ScoreMe(game, availiableMoves.Count, depth, curPlayerPos);
//    //        return new Game((int[,])game.grid.Clone(), game.playerPos, game.enemyPos, game.buildingPos, game.score);
//    //    }



//    //    depth += 1;
//    //    List<Game> scores = new List<Game>();
//    //    Game gameClone = new Game((int[,])game.grid.Clone(), game.playerPos, game.enemyPos, game.buildingPos, game.score);
//    //    gameClone.score = ScoreMe(gameClone, availiableMoves.Count, depth, curPlayerPos);
//    //    for (int i = 0; i < availiableMoves.Count; i++)
//    //    {
//    //        Move move = availiableMoves[i];


//    //        for (int j = 0; j < move.buildingCells.Count; j++)
//    //        {
//    //            gameClone.grid = GetNewState(gameClone.grid, move.buildingCells[j]);
//    //            if (player == 0)
//    //            {
//    //                gameClone.playerPos = move.pos;
//    //                gameClone.buildingPos = move.buildingCells[j];
//    //            }
//    //            else
//    //            {
//    //                gameClone.enemyPos = move.pos;
//    //            }
//    //            curPlayerPos = move.pos;
//    //            gameClone.score = ScoreMe(gameClone, availiableMoves.Count, depth,curPlayerPos)- gameClone.score;
//    //            Game endGame = Minimax(gameClone, depth, player == 0 ? 1 : 0);
//    //            scores.Add(endGame);
//    //            gameClone.grid = (int[,])game.grid.Clone();
//    //            gameClone.playerPos = game.playerPos;
//    //            gameClone.enemyPos = game.enemyPos;
//    //            gameClone.score = game.score;
//    //        }
//    //    }

//    //    if (player == 1)
//    //    {

//    //        int item = scores.Min(x => x.score);
//    //        int index = scores.IndexOf(scores.Where(p => p.score == item).FirstOrDefault());
//    //        return scores[index];
//    //    }
//    //    else
//    //    {
//    //        int item = scores.Max(x => x.score);
//    //        int index = scores.IndexOf(scores.Where(p => p.score == item).FirstOrDefault());
//    //        return scores[index];
//    //    }
//    //}

//    static int ScoreMe(Game g, int availiablemoves, int depth, Cell curPlayerPos)
//    {
//        int scr = CheckForWinner(g, availiablemoves);
//        if (scr == 2)
//            return depth - 100;
//        else if (scr == 3)
//            return 100 - depth;
//        else
//        {
//            /*if (g.playerScore <= g.enemyScore) {
//                return CapturePoints(g);
//            }else
//                return 0;*/
//            return CapturePoints(g, curPlayerPos);
//        }
//    }

//    static int CheckForWinner(Game g, int availiablemoves)
//    {
//        if (availiablemoves == 0 && player == 1)
//        {
//            return 3;
//        }
//        if (availiablemoves == 0 && player == 0)
//        {
//            return 2;
//        }
//        else
//        {
//            return 0;
//        }
//    }

//    static Move AvailiableMoves(Game g, Cell curPlayerPos, Cell curEnemyPos)
//    {
//        List<Cell> neighbours = FindNeighbours(g, curPlayerPos);

//        neighbours = RefineNeighbours(g, neighbours, curPlayerPos, curEnemyPos, true);

//        List<Move> moves = FindMoves(g, neighbours, curPlayerPos, curEnemyPos);

//        Move move = ScoreMoves(g,moves,curPlayerPos);
        
//        return move;
//    }

//    static Move ScoreMoves(Game g,List<Move> moves, Cell curPlayerPos) {
//        List<int> score = new List<int>();
//        Move finalMove = new Move(null,null);
//        int maxScore = 0;
//        foreach (Move m in moves) {
//            int mScr = 0;
//            if (g.grid[m.pos.x, m.pos.y] < g.grid[curPlayerPos.x, curPlayerPos.y]) {
//                mScr -= 1;
//            }
//            if (g.grid[m.pos.x, m.pos.y] == g.grid[curPlayerPos.x, curPlayerPos.y] + 1) {
//                mScr += 2;
//            }
//            if (g.grid[m.pos.x, m.pos.y] == g.grid[curPlayerPos.x, curPlayerPos.y])
//            {
//                mScr += 1;
//            }
//            if (g.grid[m.pos.x, m.pos.y] == 3)
//            {
//                mScr += 3;
//            }
//            if (m.buildingCells.Count==0)
//            {
//                mScr -= 100;
//            }
//            if (m.buildingCells.Count == 1)
//            {
//                mScr -= 10;
//            }
//            foreach (Cell b in m.buildingCells)
//            {
//                int bScore = 0;
//                if (g.grid[b.x, b.y]+1 == g.grid[m.pos.x, m.pos.y])
//                {
//                    bScore += 1;
//                }
//                if (g.grid[b.x, b.y] + 1 ==2 && g.grid[m.pos.x, m.pos.y]==1)
//                {
//                    bScore += 1;
//                }
//                if (g.grid[b.x, b.y] + 1 == 3 && g.grid[m.pos.x, m.pos.y]==2)
//                {
//                    bScore += 2;
//                }
//                if (g.grid[b.x, b.y] == 3 && g.grid[m.pos.x, m.pos.y]==2)
//                {
//                    bScore += 3;
//                }


//                if (mScr + bScore > maxScore) {
//                    maxScore = mScr + bScore;
//                    finalMove = new Move(m.pos, new List<Cell> { b });
//                }
//            }
//        }
//        return finalMove;
//    }

//    static List<Cell> FindNeighbours(Game g, Cell pos)
//    {
//        List<Cell> neighbours = new List<Cell>();

//        for (int i = -1; i < 2; i++)
//        {
//            for (int j = -1; j < 2; j++)
//            {
//                if (
//                    pos.x + i > -1 && pos.y + j > -1
//                    && pos.x + i < gridSize && pos.y + j < gridSize && g.grid[pos.x, pos.y] != -1)
//                {
//                    neighbours.Add(new Cell(pos.x + i, pos.y + j));
//                }
//            }
//        }
//        Cell itemToRemove = neighbours.Single(r => r.x == pos.x && r.y == pos.y);
//        neighbours.Remove(itemToRemove);
//        return neighbours;
//    }

//    static List<Cell> RefineNeighbours(Game g, List<Cell> nei,Cell curPlayerPos, Cell curEnemyPos, bool moveRefine) {
//        for (int i=nei.Count-1; i>=0; i--) {
//            //too high
//            if (g.grid[nei[i].x, nei[i].y] == 4 || 
//                // no cell there
//                g.grid[nei[i].x, nei[i].y] == -1 || 
//                //enemy is there
//                (curEnemyPos.x == nei[i].x && curEnemyPos.y == nei[i].y) ||
//                //player is there
//                (nei[i].x == curPlayerPos.x && nei[i].y == curPlayerPos.y)) {
//                nei.RemoveAt(i);
//                continue;
//            }
//            //higher than 1 from my cell
//            if ((g.grid[nei[i].x, nei[i].y] > g.grid[curPlayerPos.x, curPlayerPos.y] + 1) && moveRefine) {
//                nei.RemoveAt(i);
//                continue;
//            }

//        }

//        return nei;
//    }

//    static List<Move> FindMoves(Game g, List<Cell> neighbours, Cell curPlayerPos, Cell curEnemyPos)
//    {

//        List<Move> moves = new List<Move>();
//        List<Cell> buildingPlaces = new List<Cell>();

//        if (neighbours.Count > 6)
//        {
//            Cell item = neighbours.FirstOrDefault(r => g.grid[r.x, r.y] == g.grid[curPlayerPos.x, curPlayerPos.y] + 1);
//            if (item != null)
//            {
//                buildingPlaces.Add(curPlayerPos);
//                moves.Add(new Move(neighbours[neighbours.IndexOf(item)], buildingPlaces));
//                return moves;
//            }
//        }

//        double calc = Mathf.Pow(curPlayerPos.x - curEnemyPos.x, 2) + Mathf.Pow(curPlayerPos.y - curEnemyPos.y, 2);

//        for (int i = neighbours.Count - 1; i >= 0; i--)
//        {

//            buildingPlaces = FindBuildingPlaces(g, neighbours[i], curPlayerPos, curEnemyPos);

//            if (buildingPlaces.Count == 1 && g.grid[buildingPlaces[0].x, buildingPlaces[0].y] == 3)
//            {
//                moves.Clear();
//                moves.Add(new Move(CanIGoHigher(g, neighbours, i), buildingPlaces));
//                return moves;
//            }
//            if (buildingPlaces.Count != 0)
//            {
//                Move m = new Move(neighbours[i], buildingPlaces);
//                moves.Add(m);
//            }
//            if (g.grid[neighbours[i].x, neighbours[i].y] == 3 && buildingPlaces.Count != 0)
//            {
//                moves.Clear();
//                moves.Add(new Move(neighbours[i], buildingPlaces));
//                return moves;
//            }

//        }

//        return moves;
//    }

//    static Cell CanIGoHigher(Game g, List<Cell> nei, int index)
//    {
//        Cell c = nei[index];
//        foreach (Cell n in nei)
//        {
//            if (g.grid[n.x, n.y] > g.grid[nei[index].x, nei[index].y])
//            {
//                c = n;
//            }
//        }
//        return c;
//    }

//    static bool BlockingNeighbours(Game g, Cell target)
//    {
//        List<Cell> bn = FindNeighbours(g, target);
//        foreach (Cell n in bn)
//        {
//            if ((g.grid[n.x, n.y] - g.grid[target.x, target.y]) < 2)
//                return false;
//        }
//        return true;
//    }

//    static List<Cell> FindBuildingPlaces(Game game, Cell buildingSite, Cell curPlayerPos, Cell curEnemyPos)
//    {

//        List<Cell> buildNeighbours = FindNeighbours(game, buildingSite);
//        buildNeighbours = RefineNeighbours(game, buildNeighbours, curPlayerPos, curEnemyPos, false);

//        List<Cell> buildingCells = new List<Cell>();
//        Cell block = CanIBlockHim(game, curEnemyPos);

//        foreach (Cell n in buildNeighbours)
//        {
//            if (block != null && block.x == n.x && block.y == n.x)
//            {
//                buildingCells.Clear();
//                buildingCells.Add(n);
//                break;
//            }

//            //double calc = Mathf.Pow(n.x - curEnemyPos.x, 2) + Mathf.Pow(n.y - curEnemyPos.y, 2);
//            //double calc2 = Mathf.Pow(curPlayerPos.x - curEnemyPos.x, 2) + Mathf.Pow(curPlayerPos.y - curEnemyPos.y, 2);
//            buildingCells.Add(n);
        
//        }

//        return buildingCells;

//    }

//    static List<Cell> RefineBuildingSites(Game g) {


//        return new List<Cell>();
//    }

//    static Cell CanIBlockHim(Game g, Cell curEnemyPos)
//    {
//        List<Cell> buildNeighbours = FindNeighbours(g, curEnemyPos);
//        if (buildNeighbours.Count == 1 && g.grid[buildNeighbours[0].x, buildNeighbours[0].y]> g.grid[curEnemyPos.x, curEnemyPos.y]+1)
//            return buildNeighbours[0];
//        else
//            return null;
//    }

//    static int[,] GetNewState(int[,] game, Cell whereToBuild)
//    {

//        game[whereToBuild.x, whereToBuild.y] += 1;

//        return game;
//    }

//    static int CapturePoints(Game g, Cell curPlayerPos)
//    {
//        int scr = 0;

//        scr += g.grid[curPlayerPos.x, curPlayerPos.y]*2;

//        List<Cell> nei = FindNeighbours(g, curPlayerPos);
//        foreach (Cell n in nei)
//        {
//            if (g.grid[n.x, n.y] > g.grid[g.playerPos.x, g.playerPos.y] + 1)
//            {
//                scr -= 1;
//                //break;
//            } else if (g.grid[n.x, n.y] < g.grid[g.playerPos.x, g.playerPos.y]) {
//                //scr -= 1;
//            } else if ((g.grid[n.x, n.y] == g.grid[g.playerPos.x, g.playerPos.y]) || (g.grid[n.x, n.y] == g.grid[g.playerPos.x, g.playerPos.y] + 1)) {
//                scr += 2;
//            }
//        }

//        return scr;
//    }
//}
//public class Cell
//{
//    public int x;
//    public int y;
//    public Cell(int _x, int _y)
//    {
//        x = _x;
//        y = _y;
//    }
//}

//public class Move
//{
//    public Cell pos;
//    public List<Cell> buildingCells;
//    public Move(Cell _pos, List<Cell> _buildingCells)
//    {
//        pos = _pos;
//        buildingCells = _buildingCells;
//    }
//}
//public class Game
//{
//    public int[,] grid;
//    public Cell playerPos;
//    public Cell enemyPos;
//    public Cell buildingPos;
//    public int score;

//    public Game(int[,] _grid, Cell _playerPos, Cell _enemyPos, Cell _buildingPos, int _score)
//    {
//        grid = _grid;
//        playerPos = _playerPos;
//        enemyPos = _enemyPos;
//        buildingPos = _buildingPos;
//        score = _score;
//    }
//}
