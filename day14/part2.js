const fs = require('fs');

const CYCLE_COUNT = 1000000000;
const FILE_PATH = "input.txt";

const text = fs.readFileSync(FILE_PATH, 'utf8')

const allLines = text.trim().split('\n')
const puzzle = []

for(const line of allLines){
    puzzle.push(line.trim().split(""))
}

const height = puzzle.length
const width = puzzle[0].length

/* ---------------------------------------- TO NORTH ---------------------------------------- */
function sendRocksToNorth() {
    for(let i = 1; i < height; i++){
        for(let j = 0; j < width; j++) {
            if(puzzle[i][j] === 'O'){
                sendRockToNorth(i, j)
            }
        }
    }
}

function sendRockToNorth(rowIndex, colIndex){
    while(puzzle[rowIndex - 1][colIndex] === '.'){
        puzzle[rowIndex - 1][colIndex] = 'O'
        puzzle[rowIndex][colIndex] = '.'

        if(rowIndex - 2 >= 0){
            rowIndex--;
        }
    }
}

/* ---------------------------------------- TO SOUTH ---------------------------------------- */
function sendRocksToSouth() {
    for(let i = height - 2; i >= 0; i--){
        for(let j = 0; j < width; j++) {
            if(puzzle[i][j] === 'O'){
                sendRockToSouth(i, j)
            }
        }
    }
}

function sendRockToSouth(rowIndex, colIndex){

    while(puzzle[rowIndex + 1][colIndex] === '.'){
        puzzle[rowIndex + 1][colIndex] = 'O'
        puzzle[rowIndex][colIndex] = '.'

        if(rowIndex + 2 < height) {
            rowIndex++;
        }
    }
}

/* ---------------------------------------- TO WEST ---------------------------------------- */
function sendRocksToWest() {
    for(let i = 0; i < height; i++){
        for(let j = 1; j < width; j++) {

            if(puzzle[i][j] === 'O'){
                sendRockToWest(i, j)
            }
        }
    }
}

function sendRockToWest(rowIndex, colIndex){
    while(puzzle[rowIndex][colIndex - 1] === '.') {
        puzzle[rowIndex][colIndex - 1] = 'O'
        puzzle[rowIndex][colIndex] = '.'

        if(colIndex - 2 >= 0){
            colIndex--;
        }
    }
}

/* ---------------------------------------- TO EAST ---------------------------------------- */
function sendRocksToEast() {
    for(let i = 0; i < height; i++) {
        for(let j = width - 2; j >= 0; j--) {

            if(puzzle[i][j] === 'O'){
                sendRockToEast(i, j)
            }
        }
    }
}

function sendRockToEast(rowIndex, colIndex){
    while(puzzle[rowIndex][colIndex + 1] === '.'){
        puzzle[rowIndex][colIndex + 1] = 'O'
        puzzle[rowIndex][colIndex] = '.'

        if(colIndex + 2 < width){
            colIndex++;
        }
    }
}

function doCycle(){
    sendRocksToNorth();
    sendRocksToWest();
    sendRocksToSouth();
    sendRocksToEast();
}

function getNumberOfRocksInRow(row){
    return row.filter((cell) => cell === 'O').length
}

const allHash = []

for(let i = 0; i < CYCLE_COUNT; i++){
    doCycle()

    const str = puzzle.join('')
    const indexStr = allHash.indexOf(str)
    if(indexStr === -1) {
        allHash.push(str)
    } else {
        const diff = i - indexStr;
        while(i < (CYCLE_COUNT-diff)){
            i += diff;
        }
    }

    console.log('i', i)
}

let result = 0;
for(let indexRow = 0; indexRow < height; indexRow++) {
    const multiplicator = height - indexRow;
    const row = puzzle[indexRow];
    const numberOfRocks = getNumberOfRocksInRow(row);
    result += numberOfRocks * multiplicator;
}

console.log('Result :', result);
