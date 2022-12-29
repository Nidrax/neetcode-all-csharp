/*
 * https://leetcode.com/problems/valid-sudoku/description/
 *
 * Determine if a `9 x 9` Sudoku board is valid. Only the filled cells need
 * to be validated *according to the following rules*:
 *
 * - Each row must contain the digits `1-9` without repetition.
 * - Each column must contain the digits `1-9` without repetition.
 * - Each of the nine `3 x 3` sub-boxes of the grid must contain
 *   the digits `1-9` without repetition.
 *
 * Note:
 * - A Sudoku board (partially filled) could be valid but is not
 *   necessarily solvable.
 * - Only the filled cells need to be validated according to the
 *   mentioned rules.
 *
 * Example 1:
 * [img](https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Sudoku-by-L2G-20050714.svg/250px-Sudoku-by-L2G-20050714.svg.png)
 * Input: board =
 * [["5","3",".",".","7",".",".",".","."],
 *  ["6",".",".","1","9","5",".",".","."],
 *  [".","9","8",".",".",".",".","6","."],
 *  ["8",".",".",".","6",".",".",".","3"],
 *  ["4",".",".","8",".","3",".",".","1"],
 *  ["7",".",".",".","2",".",".",".","6"],
 *  [".","6",".",".",".",".","2","8","."],
 *  [".",".",".","4","1","9",".",".","5"],
 *  [".",".",".",".","8",".",".","7","9"]]
 * Output: true
 *
 * Example 2:
 * Input: board =
 * [["8","3",".",".","7",".",".",".","."],
 *  ["6",".",".","1","9","5",".",".","."],
 *  [".","9","8",".",".",".",".","6","."],
 *  ["8",".",".",".","6",".",".",".","3"],
 *  ["4",".",".","8",".","3",".",".","1"],
 *  ["7",".",".",".","2",".",".",".","6"],
 *  [".","6",".",".",".",".","2","8","."],
 *  [".",".",".","4","1","9",".",".","5"],
 *  [".",".",".",".","8",".",".","7","9"]]
 * Output: false
 * Explanation: Same as Example 1, except with the 5 in the top left
 * corner being modified to 8. Since there are two 8's in the top left
 * 3x3 sub-box, it is invalid.
 *
 * Constraints:
 * - `board.length == 9`
 * - `board[i].length == 9`
 * - `board[i][j]` is a digit or `'.'`.
 */

// ReSharper disable once CheckNamespace
namespace NeetCodeAllCSharp.ArraysHashing.ValidSudoku;

public interface ISolution
{
    bool IsValidSudoku(char[][] board);
}

public class Solution : ISolution
{
    private static bool Validate(string s)
    {
        s = s.Replace(".","");
        return !s.GroupBy(x => x).Any(g => g.Count() > 1);
    }

    // OJ score: 114 ms, 51.8 MB
    public bool IsValidSudoku(char[][] board) {
        for(var i=0; i<9; ++i)
        {
            // This could be also implemented using Dictionaries and HashSets,
            // as suggested on NeetCode.io, but overall Dictionaries approach
            // only uses a bit less memory for no time performance gain.
            var si="";
            var sj="";

            for(var j=0; j<9; ++j)
            {
                si += board[i][j];
                sj += board[j][i];
            }

            if(!Validate(si)) return false;
            if(!Validate(sj)) return false;
        }

        for(var i=1; i<9; i+=3)
        {
            for(var j=1; j<9; j+=3)
            {
                var s = "";
                
                for(var k=i-1; k<i+2; ++k)
                for(var l=j-1; l<j+2; ++l)
                    s += board[k][l];

                if(!Validate(s)) return false;
            }
        }

        return true;
    }
}
