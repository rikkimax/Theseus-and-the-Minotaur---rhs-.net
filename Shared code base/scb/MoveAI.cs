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
            // if so make it.
            
            // if theseus had a turn the minotaur must now (twice).
            // if (MinotaurTurn(board, entities)) MinotaurTurn(board, entities);
            return false;
        }

        /**
         * Makes the Minotaurs turn given a gameboard and entity positions.
         */
        private static bool MinotaurTurn(ref GameBoard board, ref Dictionary<EntityType, Point> entities)
        {
            // how about that ai now?
            return false;
        }
    }
}