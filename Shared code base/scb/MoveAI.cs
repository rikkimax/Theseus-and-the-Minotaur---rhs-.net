using System.Windows;
using System.Collections.Generic;
using TATM.SCB.models;

namespace TATM.SCB {
    public class MoveUtil {

        /**
         * Given a game board, entity, entity positions and the direction to move, say can they make that move.
         */
        public static bool CanMakeMove(ref GameBoard board, EntityType entity, ref Dictionary<EntityType, Point> entities, Direction direction)
        {
            // how about we go do some checking about the game board state and where the entity wants to go?
            /* Peusdo-Code action: 
             * at the start of the turn
             * reference the cell the entity occupied at the start of their turn Entity.theX, Entity.theY
             * use a nested if tree of logic (assuming top left is X:0 Y:0 for cell numbering or whatever)
             * 
             * If (the cell is the first one from the roof) -invalidate potential move up as it would result going off screen
             *      else take current cell number -1 to get the cell above, and test that cell for a barrier down, if true invalidate potential move up
             * If (the cell is the first from the left)- invalidate potential left movement as it would result in going off screen
             *      else take current cell number -1 to get the cell left and test that cell for a barrier right, c
             * If the entity wants to move right, check current cell for right wall being blocked, if true invalidate potential move right
             * If the unit wants to go down, check the current cell for the down wall being blocked, if true invalidate potential move down
             */
            return false;
        }
    }

    public class MakeMove
    {
        /**
         * Given a game board, entity positions and a direction that theseus wants to move in either perform or not.
         * Includes call to minotaurs turns.
         */
        public static bool TheseusTurn(ref GameBoard board, ref Dictionary<EntityType, Point> entities, Direction direction)
        {
            // can theseus make the turn?
            // cross reference arrow keys or WASD keys against validated move options
            // if valid and asked for commit the move, and turn -1. If invalid do we give user feedback? but still has tun to try different direction
            
            // when Theseus had a turn run comparison (is Entity.theX == theExit.theX && Entity.theY == theExit.theY?) if so level is over;
            //      else: the minotaur must now move(twice).
            // if (MinotaurTurn(board, entities)) MinotaurTurn(board, entities);
            return false;
        }

        /**
         * Makes the Minotaurs turn given a gameboard and entity positions.
         * Minotaur movement logic: primary movement left/right secondary movement up/down. seek Theseus where possible -else back up a step or two
         * if T.theY = M.theY dont worry about left/right
         * elseif T.theY > M.theY, go right
         * else
         */
        private static bool MinotaurTurn(ref GameBoard board, ref Dictionary<EntityType, Point> entities)
        {
            // how about that ai now?
            return false;
        }
    }
}