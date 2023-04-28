import { Component } from '@angular/core';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent {
  board: string[][] = [
    ['', '', ''],
    ['', '', ''],
    ['', '', '']
  ];
  currentPlayer: string = 'X';
  gameOver: boolean = false;
  winner: string | null = null;

  makeMove(row: number, col: number): void {
    if (this.board[row][col] || this.gameOver) {
      return;
    }

    this.board[row][col] = this.currentPlayer;
    this.checkForWin();
    
    if (!this.gameOver) {
      this.currentPlayer = this.currentPlayer === 'X' ? 'O' : 'X';
    }
  }

  checkForWin(): void {
    const lines = [
      // Rows
      ...this.board,
      // Columns
      [this.board[0][0], this.board[1][0], this.board[2][0]],
      [this.board[0][1], this.board[1][1], this.board[2][1]],
      [this.board[0][2], this.board[1][2], this.board[2][2]],
      // Diagonals
      [this.board[0][0], this.board[1][1], this.board[2][2]],
      [this.board[0][2], this.board[1][1], this.board[2][0]],
    ];

    for (const line of lines) {
      if (line.every(cell => cell === this.currentPlayer)) {
        this.gameOver = true;
        this.winner = this.currentPlayer;
        return;
      }
    }

    // Check for a draw
    if (this.board.every(row => row.every(cell => cell))) {
      this.gameOver = true;
      this.winner = null;
    }
  }

  resetGame(): void {
    this.board = [
      ['', '', ''],
      ['', '', ''],
      ['', '', '']
    ];
    this.currentPlayer = 'X';
    this.gameOver = false;
    this.winner = null;
  }
}
