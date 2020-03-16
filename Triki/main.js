const BuildBoard = (size) => {
    const boxes = new Array(size).fill("-")
    return boxes
}


var app = new Vue({
    el: "#app",
    data: () => {
        return {
            playerOneName: "",
            playerTwoName: "",
            turn: 1,
            boxes: BuildBoard(9)
        }
    },
    methods: {
        onClickBox(posx) {
            if (this.boxes[posx] === "-") {
                if (this.turn === 1) {
                    this.boxes[posx] = "X";
                    this.turn = 2;
                }
                else {
                    this.boxes[posx] = "O";
                    this.turn = 1;
                }
                let winner = this.validarGanador()
                if (winner !== undefined && winner !== "-" && winner != false) {

                    if (winner === "O" || winner === "X") {
                        alert("Ganador: " + winner +" -> "+ (this.turn === 1 ? this.playerOneName : this.playerTwoName))

                    }
                    if (winner === true) {
                        alert("Empate!");
                    }
                    this.boxes = BuildBoard(9)
                }


            } else {
                alert("Tablero ocupado!")
            }
        },

        validarGanador() {
            let actualBoard = this.boxes
            let winners = [
                [0, 1, 2],
                [3, 4, 5],
                [6, 7, 8],
                [0, 3, 6],
                [1, 4, 7],
                [2, 5, 8],
                [0, 4, 8],
                [2, 4, 6],
            ]
            for (let i = 0; i < winners.length; i++) {
                const [a, b, c] = winners[i];
                if (actualBoard[a] && actualBoard[a] === actualBoard[b] && actualBoard[a] === actualBoard[c]) {
                    return actualBoard[a];
                }
            }
            let ocupado = []
            for (const key in this.boxes) {
                if (this.boxes[key] != "-")
                    ocupado.push(this.boxes[key]);
            }
            return ocupado.length === this.boxes.length
        }
    }
})

