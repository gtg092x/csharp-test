using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class MatrixDecomposition {

	public static List<System.Object> DecomposeMatrix(System.Object[][] matrix){
		// unwind matrix
		// row then column [x][y]
		List<System.Object> result = new List<System.Object>();
		List<IntPoint> traversed = new List<IntPoint>();

		// start by facing right
		Direction direction = Direction.Right;
		// start off map
		IntPoint pos = new IntPoint{x=-1,y=0};

		// if pather turns too many times, its stuck
		int turns = 0;

		while(true){
			IntPoint nextPos = new IntPoint();
			switch(direction){
				case Direction.Right:
					nextPos = new IntPoint{x=pos.x+1,y=pos.y};
					break;
				case Direction.Down:
					nextPos = new IntPoint{x=pos.x,y=pos.y+1};
					break;
				case Direction.Left:
					nextPos = new IntPoint{x=pos.x-1,y=pos.y};
					break;
				case Direction.Up:
					nextPos = new IntPoint{x=pos.x,y=pos.y-1};
					break;
			}
			//rows first
			if(outOfBounds(nextPos,matrix, pos) || isTraversed(nextPos,traversed)){
				direction = nextDirection(direction);
				if(turns ++>3){
					break;
				}else{
					continue;
				}
			}
			// add spooled value
			result.Add(matrix[nextPos.y][nextPos.x]);
			// add used value to traversed
			traversed.Add (nextPos);
			// current pos is now next pos
			pos = nextPos;
			// turns are reset
			turns = 0;
		}

		return result;

	}

	static bool isTraversed(IntPoint nextPos, List<IntPoint> traversed){
		return traversed.Any (point=>point.x == nextPos.x && point.y == nextPos.y);
	}

	static bool outOfBounds(IntPoint nextPos, System.Object[][] matrix, IntPoint pos){
		return nextPos.y >= matrix.Length || nextPos.x >= matrix[pos.y].Length
			|| nextPos.y < 0 || nextPos.x < 0;
	}

	static Direction nextDirection(Direction direction){
		switch(direction){
			case Direction.Right:
				return Direction.Down;
			break;
			case Direction.Down:
				return Direction.Left;
			break;
			case Direction.Left:
				return Direction.Up;
			break;		
			case Direction.Up:
			default:
				return Direction.Right;				
			break;
		}
	}

	struct IntPoint{
		public int x;
		public int y;
	}

	enum Direction{
		Right,
		Down,
		Left,
		Up
	}
}
