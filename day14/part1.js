const fs = require('fs');

// Part 1 : Get the new tilted platform
// Part 2 : Get the number of rocks in one row
// Part 3 : Make the sum of all the weight

function tiltColumn(column) {
    for(let i = 0; i < column.length; i++) {
        if(column[i] === 'O') {
            let isRockMoving;
            let j = i;
            do{
                const isCellAboveEmpty = column[j-1] === '.';
                const isCellAboveNotTheEdge = j-1 >= 0;
                isRockMoving = isCellAboveEmpty && isCellAboveNotTheEdge;
                
                if(isRockMoving) {
                    column[j-1] = 'O';
                    column[j] = '.';
                    j--;
                }
            } while(isRockMoving)
        }
    }
    return column
}

function getColumn(puzzle, colIndex) {
    const result = []
    for(let i = 0; i < puzzle.length; i++) {
        result.push(puzzle[i][colIndex])
    }
    return result;
}

//Part 2
function getNumberOfRocksInRow(row){
    return row.split("").filter((cell) => cell === 'O').length
}

(async () => {
    const text = await new Promise((resolve, reject) => {
        fs.readFile('input.txt', 'utf8', (err, data) => {
            if (err) {
                reject(err)
            } else {
                resolve(data)
            }
        })
    })
    
    
    //Part 1 :
    const allRows = text.split('\n');

    console.log(allRows)
    
    const rowCount = allRows.length;
    const colCount = allRows[0].length;
    
    const allColumns = []
    for(let indexColumn = 0; indexColumn < colCount; indexColumn++) {
        allColumns.push(getColumn(allRows, indexColumn))
    }
    const allTiltedColumns = allColumns.map((col) => tiltColumn(col))
    
    //Part 3 :
    const allTiltedRows = []
    for(let indexRow = 0; indexRow < rowCount; indexRow++){
        let tiltedRow = "";
        allTiltedColumns.forEach((col) => {
            tiltedRow += col[indexRow];
        })
        allTiltedRows.push(tiltedRow)
    }
    
    console.log(allTiltedRows);
    
    let result = 0;
    for(let indexRow = 0; indexRow < rowCount; indexRow++) {
        const multiplicator = rowCount - indexRow;
        const row = allTiltedRows[indexRow];
        const numberOfRocks = getNumberOfRocksInRow(row);
        result += numberOfRocks * multiplicator;
    }
    
    console.log('Result :', result);
})()