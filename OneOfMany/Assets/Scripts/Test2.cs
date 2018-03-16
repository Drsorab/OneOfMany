//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//public class Test2 : MonoBehaviour
//{

//    int[,] grid = new int[6, 6];
//    Cell myPos1 = new Cell(-1, -1);
//    Cell hisPos1 = new Cell(-1, -1);
//    Cell myPos2 = new Cell(-1, -1);
//    Cell hisPos2 = new Cell(-1, -1);
//    static int gridSize = 6;
//    static int player = 0;

//    // Use this for initialization
//    void Start()
//    {
//        //for (int i = 0; i < grid.GetLength(0); i++) {
//        //    for (int j = 0; j < grid.GetLength(1); j++) {
//        //        grid[i, j] = 0;
//        //    }
//        //}
//        grid[0, 0] = -1;
//        grid[1, 0] = 0;
//        grid[2, 0] = 0;
//        grid[3, 0] = 0;
//        grid[4, 0] = 0;
//        grid[5, 0] = 0;
//        //grid[6, 0] = -1;


//        grid[0, 1] = 0;
//        grid[1, 1] = 0;
//        grid[2, 1] = -1;
//        grid[3, 1] = -1;
//        grid[4, 1] = 0;
//        grid[5, 1] = 0;
//        //grid[6, 1] = -1;



//        grid[0, 2] = -1;
//        grid[1, 2] = 0;
//        grid[2, 2] = 0;
//        grid[3, 2] = 0;
//        grid[4, 2] = 0;
//        grid[5, 2] = -1;
//        //grid[6, 2] = -1;


//        grid[0, 3] = 3;
//        grid[1, 3] = 3;
//        grid[2, 3] = 0;
//        grid[3, 3] = 0;
//        grid[4, 3] = 3;
//        grid[5, 3] = 2;
//        //grid[6, 3] = 0;


//        grid[0, 4] = 1;
//        grid[1, 4] = 3;
//        grid[2, 4] = 3;
//        grid[3, 4] = 0;
//        grid[4, 4] = 0;
//        grid[5, 4] = 0;
//        //grid[6, 4] = -1;

//        grid[0, 5] = 0;
//        grid[1, 5] = 0;
//        grid[2, 5] = 0;
//        grid[3, 5] = 0;
//        grid[4, 5] = 0;
//        grid[5, 5] = 0;
//        //grid[6, 5] = -1;

//        //grid[0, 6] = -1;
//        //grid[1, 6] = -1;
//        //grid[2, 6] = -1;
//        //grid[3, 6] = 0;
//        //grid[4, 6] = -1;
//        //grid[5, 6] = -1;
//        //grid[6, 6] = -1;


//        myPos1 = new Cell(1, 5);
//        myPos2 = new Cell(1, 4);
//        hisPos1 = new Cell(4, 0);
//        hisPos2 = new Cell(5, 3);
//        List<Cell> myPawns = new List<Cell>();
//        List<Cell> enemyPawns = new List<Cell>();
//        myPawns.Add(myPos1);
//        myPawns.Add(myPos2);
//        enemyPawns.Add(hisPos1);
//        enemyPawns.Add(hisPos2);

//        //Game newGame = Minimax(new Game(grid, myPos, hisPos, null, 0, 0, 0),0,0);
//        Move fmove = AvailiableMoves(new Game(grid, myPawns, enemyPawns, null, 0), myPawns, enemyPawns);
//        int p = 0;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    static Move AvailiableMoves(Game g, List<Cell> curPlayerPos, List<Cell> curEnemyPos)
//{
//    List<List<Cell>> neighbours = FindNeighbours(g, curPlayerPos);

//    neighbours = RefineNeighbours(g, neighbours, curPlayerPos, curEnemyPos, true);

//    List<Move> moves = FindMoves(g, neighbours, curPlayerPos, curEnemyPos);

//    List<Move> ks = PushHim(g, curPlayerPos, curEnemyPos);

//    moves.AddRange(ks);

//    Move finalMove = PickTheBest(g, moves, curPlayerPos, curEnemyPos);

//    return finalMove;
//}
//static Move PickTheBest(Game g, List<Move> moves, List<Cell> curPlayerPos, List<Cell> curEnemyPos)
//{
//    List<Finalist> finalist = new List<Finalist>();

//    foreach (Move m in moves)
//    {
//        //if i dont push....i move
//        if (m.who > -1)
//        {
//            double dist1 = 100;
//            double dist2 = 100;
//            if (curEnemyPos[0].x > -1)
//                dist1 = Math.Pow(curPlayerPos[m.who].x - curEnemyPos[0].x, 2) + Math.Pow(curPlayerPos[0].y - curEnemyPos[0].y, 2);
//            if (curEnemyPos[1].x > -1)
//                dist2 = Math.Pow(curPlayerPos[m.who].x - curEnemyPos[1].x, 2) + Math.Pow(curPlayerPos[1].y - curEnemyPos[1].y, 2);

//            int prescore = g.grid[m.pos.x, m.pos.y];
//            if (g.grid[m.pos.x, m.pos.y] == g.grid[curPlayerPos[m.who].x, curPlayerPos[m.who].y] + 1)
//            {
//                prescore += 3;
//            }
//            if (g.grid[m.pos.x, m.pos.y] < g.grid[curPlayerPos[m.who].x, curPlayerPos[m.who].x])
//            {
//                prescore -= 3;
//            }
//            if (g.grid[m.pos.x, m.pos.y] == 3 && (dist1 > 3 || dist2 > 3))
//            {
//                prescore += 10;
//            }
//            foreach (Cell bp in m.buildingCells)
//            {
//                if (bp.x == 1 && bp.y == 3 && m.pos.x == 2 && m.pos.y == 4)
//                    Debug.Log("s");
//                int bscore = prescore;
//                //if we are on the same lvl
//                if (g.grid[bp.x, bp.y] + 1 == g.grid[m.pos.x, m.pos.y])
//                {
//                    bscore += 1;// (g.grid[bp.x, bp.y] + 1) * 2;
//                }
//                //if it is +1 from me
//                if (g.grid[bp.x, bp.y] == g.grid[m.pos.x, m.pos.y] && g.grid[bp.x, bp.y] != 3)
//                {
//                    bscore += 1;
//                }
//                //if i can score in the next move
//                if (g.grid[bp.x, bp.y] + 1 == 3 && g.grid[m.pos.x, m.pos.y] == 2)
//                {
//                    bscore += 1;
//                }
//                if (g.grid[bp.x, bp.y] + 1 == 3 && (dist1 < 3 || dist2 < 3))
//                {
//                    bscore -= 3;
//                }
//                //if i destroy a 3ari and enemies arent close
//                if (g.grid[bp.x, bp.y] == 3 /*&& g.grid[m.pos.x, m.pos.y] == 2*/ && dist1 > 3 && dist2 > 3)
//                {
//                    bscore -= 10;
//                }
//                //if i destroy a 3ari and enemies are close
//                if (g.grid[bp.x, bp.y] == 3 && g.grid[m.pos.x, m.pos.y] == 2 && (dist1 < 3 || dist2 < 3))
//                {
//                    bscore += 10;
//                }

//                finalist.Add(new Finalist(new Move(m.pos, new List<Cell> { bp }, m.who), prescore + bscore));
//                //best building
//            }
//        }
//        else
//        {
//            int curPlayer = 0;
//            if (m.who == -1)
//                curPlayer = 0;
//            if (m.who == -2)
//                curPlayer = 1;

//            int score = g.grid[m.pos.x, m.pos.y];
//            if (m.buildingCells.Count > 0)
//            {
//                score += 3 - g.grid[m.buildingCells[0].x, m.buildingCells[0].y];
//                if (g.grid[m.buildingCells[0].x, m.buildingCells[0].y] == g.grid[m.pos.x, m.pos.y] - 2)
//                {
//                    score += 1;
//                }
//                if (g.grid[curPlayerPos[curPlayer].x, curPlayerPos[curPlayer].y] < g.grid[m.pos.x, m.pos.y])
//                {
//                    score += 1;
//                }
//                if (g.grid[m.pos.x, m.pos.y] == 3)
//                {
//                    score += 1;
//                }
//            }
//            else
//            {
//                score -= 100;
//            }
//            finalist.Add(new Finalist(m, score));
//        }
//    }
//    int winner = finalist.Max(x => x.y);


//    return finalist.Where(p => p.y == winner).FirstOrDefault().x;
//}

//static List<Move> PushHim(Game g, List<Cell> curPlayerPos, List<Cell> curEnemyPos)
//{
//    List<Move> moves = new List<Move>();

//    int kickerIdx = -1;
//    if (curEnemyPos[0].x != -1 && curEnemyPos[0].y != -1)
//    {
//        double dist00 = Math.Pow(curPlayerPos[0].x - curEnemyPos[0].x, 2) + Math.Pow(curPlayerPos[0].y - curEnemyPos[0].y, 2);
//        double dist10 = Math.Pow(curPlayerPos[1].x - curEnemyPos[0].x, 2) + Math.Pow(curPlayerPos[1].y - curEnemyPos[0].y, 2);
//        if (dist00 < 3)
//        {
//            moves.Add(new Move(curEnemyPos[0], new List<Cell>(), -1));
//        }
//        if (dist10 < 3)
//        {
//            moves.Add(new Move(curEnemyPos[0], new List<Cell>(), -2));
//        }
//    }
//    if (curEnemyPos[1].x != -1 && curEnemyPos[1].y != -1)
//    {
//        double dist11 = Math.Pow(curPlayerPos[1].x - curEnemyPos[1].x, 2) + Math.Pow(curPlayerPos[1].y - curEnemyPos[1].y, 2);
//        double dist01 = Math.Pow(curPlayerPos[0].x - curEnemyPos[1].x, 2) + Math.Pow(curPlayerPos[0].y - curEnemyPos[1].y, 2);
//        if (dist11 < 3)
//        {
//            moves.Add(new Move(curEnemyPos[1], new List<Cell>(), -2));
//        }
//        if (dist01 < 3)
//        {
//            moves.Add(new Move(curEnemyPos[1], new List<Cell>(), -1));
//        }
//    }

//    foreach (Move m in moves)
//    {
//        int curPlayer = 0;
//        if (m.who == -1)
//            curPlayer = 0;
//        if (m.who == -2)
//            curPlayer = 1;

//        List<Cell> landingPlaces = FindBuildingNeighbours(g, m.pos, curPlayerPos, curEnemyPos, kickerIdx);
//        landingPlaces = RefineLandingPlaces(g, landingPlaces, curPlayerPos[curPlayer], m.pos, curPlayerPos, curEnemyPos);
//        m.buildingCells = landingPlaces;
//    }
//    return moves;
//}

//static List<List<Cell>> FindNeighbours(Game g, List<Cell> pos)
//{
//    List<List<Cell>> neighbours = new List<List<Cell>>();


//    for (int c = 0; c < pos.Count; c++)
//    {
//        List<Cell> nei = new List<Cell>();
//        for (int i = -1; i < 2; i++)
//        {
//            for (int j = -1; j < 2; j++)
//            {
//                if (
//                    pos[c].x + i > -1 && pos[c].y + j > -1
//                    && pos[c].x + i < gridSize && pos[c].y + j < gridSize && g.grid[pos[c].x, pos[c].y] != -1)
//                {
//                    nei.Add(new Cell(pos[c].x + i, pos[c].y + j));
//                }
//            }
//        }
//        Cell itemToRemove = nei.Single(r => r.x == pos[c].x && r.y == pos[c].y);
//        nei.Remove(itemToRemove);
//        neighbours.Add(nei);
//    }

//    return neighbours;
//}

//static List<List<Cell>> RefineNeighbours(Game g, List<List<Cell>> nei, List<Cell> curPlayerPos, List<Cell> curEnemyPos, bool moveRefine)
//{
//    for (int c = 0; c < nei.Count; c++)
//    {
//        for (int i = nei[c].Count - 1; i >= 0; i--)
//        {
//            //too high
//            if (g.grid[nei[c][i].x, nei[c][i].y] == 4 ||
//                // no cell there
//                g.grid[nei[c][i].x, nei[c][i].y] == -1)
//            {
//                nei[c].RemoveAt(i);
//                continue;
//            }
//            //higher than 1 from my cell
//            if ((g.grid[nei[c][i].x, nei[c][i].y] > g.grid[curPlayerPos[c].x, curPlayerPos[c].y] + 1) && moveRefine)
//            {
//                nei[c].RemoveAt(i);
//                continue;
//            }
//            foreach (Cell enemy in curEnemyPos)
//            {
//                //enemy is there
//                if ((nei.ElementAtOrDefault(c) != null && nei[c].ElementAtOrDefault(i) != null) && (enemy.x == nei[c][i].x && enemy.y == nei[c][i].y))
//                {
//                    nei[c].RemoveAt(i);
//                    break;
//                }
//            }
//            foreach (Cell player in curPlayerPos)
//            {
//                //player is there
//                if ((nei.ElementAtOrDefault(c) != null && nei[c].ElementAtOrDefault(i) != null) && (nei[c][i].x == player.x && nei[c][i].y == player.y))
//                {
//                    nei[c].RemoveAt(i);
//                    break;
//                }
//            }
//        }
//    }
//    return nei;
//}

//static List<Cell> RefineLandingPlaces(Game g, List<Cell> lp, Cell kicker, Cell victim, List<Cell> playerPawns, List<Cell> enemyPawns)
//{
//    string pos = "";

//    pos = Orientation(victim, kicker);

//    for (int l = lp.Count - 1; l >= 0; l--)
//    {
//        if (g.grid[lp[l].x, lp[l].y] > g.grid[victim.x, victim.y] + 1)
//        {
//            lp.RemoveAt(l);
//            continue;
//        }
//        if (pos == "NE" && (Orientation(lp[l], victim) == "N" || Orientation(lp[l], victim) == "E" || Orientation(lp[l], victim) == "NE"))
//        {
//            continue;
//        }
//        if (pos == "NW" && (Orientation(lp[l], victim) == "N" || Orientation(lp[l], victim) == "NW" || Orientation(lp[l], victim) == "W"))
//        {
//            continue;
//        }
//        if (pos == "N" && (Orientation(lp[l], victim) == "N" || Orientation(lp[l], victim) == "NE" || Orientation(lp[l], victim) == "NW"))
//        {
//            continue;
//        }
//        if (pos == "S" && (Orientation(lp[l], victim) == "S" || Orientation(lp[l], victim) == "SE" || Orientation(lp[l], victim) == "SW"))
//        {
//            continue;
//        }
//        if (pos == "E" && (Orientation(lp[l], victim) == "NE" || Orientation(lp[l], victim) == "E" || Orientation(lp[l], victim) == "SE"))
//        {
//            continue;
//        }
//        if (pos == "W" && (Orientation(lp[l], victim) == "W" || Orientation(lp[l], victim) == "NW" || Orientation(lp[l], victim) == "SW"))
//        {
//            continue;
//        }
//        if (pos == "SE" && (Orientation(lp[l], victim) == "S" || Orientation(lp[l], victim) == "SE" || Orientation(lp[l], victim) == "E"))
//        {
//            continue;
//        }
//        if (pos == "SW" && (Orientation(lp[l], victim) == "S" || Orientation(lp[l], victim) == "SW" || Orientation(lp[l], victim) == "W"))
//        {
//            continue;
//        }

//        else
//        {
//            bool found1 = false;
//            bool found2 = false;
//            foreach (Cell p in playerPawns)
//            {
//                if (lp[l].x == p.x && lp[l].y == p.y)
//                {
//                    found1 = true;
//                    break;
//                }
//            }
//            foreach (Cell p in enemyPawns)
//            {
//                if (lp[l].x == p.x && lp[l].y == p.y)
//                {
//                    found2 = true;
//                    break;
//                }
//            }
//            if ((found1 || found2) || (!found1 && !found2))
//                lp.RemoveAt(l);
//        }

//    }
//    if (lp.Count > 1)
//    {
//        Cell c = lp[0];
//        for (int i = 1; i < lp.Count; i++)
//        {
//            if (g.grid[c.x, c.y] > g.grid[lp[i].x, lp[i].y])
//            {
//                c = lp[i];
//            }
//        }
//        lp.Clear();
//        lp.Add(c);
//    }
//    return lp;
//}

//static string Orientation(Cell victim, Cell kicker)
//{

//    string pos = "";

//    if (victim.y - kicker.y < 0)
//    {
//        pos += "N";
//    }
//    else if (victim.y - kicker.y > 0)
//    {
//        pos += "S";
//    }
//    if (victim.x - kicker.x > 0)
//    {
//        pos += "E";
//    }

//    if (victim.x - kicker.x < 0)
//    {
//        pos += "W";
//    }
//    return pos;
//}

//static List<Move> FindMoves(Game g, List<List<Cell>> neighbours, List<Cell> curPlayerPos, List<Cell> curEnemyPos)
//{
//    List<Move> moves = new List<Move>();

//    for (int c = 0; c < neighbours.Count; c++)
//    {
//        List<Cell> buildingPlaces = new List<Cell>();

//        double calc = Math.Pow(curPlayerPos[c].x - curEnemyPos[c].x, 2) + Math.Pow(curPlayerPos[c].y - curEnemyPos[c].y, 2);

//        for (int i = neighbours[c].Count - 1; i >= 0; i--)
//        {

//            buildingPlaces = FindBuildingPlaces(g, neighbours[c][i], curPlayerPos, curEnemyPos, c);

//            Move m = new Move(neighbours[c][i], buildingPlaces, c);
//            moves.Add(new Move(neighbours[c][i], buildingPlaces, c));
//        }
//    }
//    return moves;
//}

//static List<Cell> FindBuildingPlaces(Game game, Cell buildingSite, List<Cell> curPlayerPos, List<Cell> curEnemyPos, int curPawn)
//{
//    List<Cell> buildNeighbours = FindBuildingNeighbours(game, buildingSite, curPlayerPos, curEnemyPos, curPawn);

//    List<Cell> buildingCells = new List<Cell>();

//    foreach (Cell n in buildNeighbours)
//    {
//        buildingCells.Add(n);
//    }

//    return buildingCells;

//}

//static List<Cell> FindBuildingNeighbours(Game g, Cell site, List<Cell> myPawns, List<Cell> enemyPawns, int curPawn)
//{
//    int other = curPawn == 0 ? 1 : 0;
//    List<Cell> buildingSites = new List<Cell>(0);

//    for (int i = -1; i < 2; i++)
//    {
//        for (int j = -1; j < 2; j++)
//        {
//            if (
//                site.x + i > -1 &&
//                site.y + j > -1 &&
//                site.x + i < gridSize &&
//                site.y + j < gridSize &&
//                g.grid[site.x + i, site.y + j] != -1 &&
//                g.grid[site.x + i, site.y + j] < 4 &&
//                (site.x + i != myPawns[other].x || site.y + j != myPawns[other].y) && /*(site.x + i != myPawns[1].x || site.y + j != myPawns[1].y) &&*/
//                (site.x + i != enemyPawns[0].x || site.y + j != enemyPawns[0].y) && (site.x + i != enemyPawns[1].x || site.y + j != enemyPawns[1].y)
//                )
//            {
//                buildingSites.Add(new Cell(site.x + i, site.y + j));
//            }
//        }
//    }

//    Cell itemToRemove = buildingSites.FirstOrDefault(r => r.x == site.x && r.y == site.y);
//    if (itemToRemove != null)
//        buildingSites.Remove(itemToRemove);
//    return buildingSites;
//}

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

//public class Finalist
//{
//    public Move x;
//    public int y;
//    public Finalist(Move _x, int _y)
//    {
//        x = _x;
//        y = _y;
//    }
//}

//public class Move
//{
//    public Cell pos;
//    public List<Cell> buildingCells;
//    public int who;
//    public Move(Cell _pos, List<Cell> _buildingCells, int _who)
//    {
//        pos = _pos;
//        buildingCells = _buildingCells;
//        who = _who;
//    }
//}
//public class Game
//{
//    public int[,] grid;
//    public List<Cell> playerPos;
//    public List<Cell> enemyPos;
//    public Cell buildingPos;
//    public int score;

//    public Game(int[,] _grid, List<Cell> _playerPos, List<Cell> _enemyPos, Cell _buildingPos, int _score)
//    {
//        grid = _grid;
//        playerPos = _playerPos;
//        enemyPos = _enemyPos;
//        buildingPos = _buildingPos;
//        score = _score;
//    }
//}
