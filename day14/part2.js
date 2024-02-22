const fs = require('fs');

function getAllIndexes(arr, val) {
    const indexes = []
    let i = -1;
    while ((i = arr.indexOf(val, i+1)) !== -1){
        indexes.push(i);
    }
    return indexes;
}

function tiltColumnToNorth(column) {
    const allRocksIndex = getAllIndexes(column, 'O');
    
    allRocksIndex.forEach((index) => {
        let isRockMoving;
        let j = index;
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
    }) 
    return column
}

function tiltColumnToSouth(column) {
    const allRocksIndex = getAllIndexes(column, 'O');
    
    allRocksIndex.forEach((index) => {
        let isRockMoving;
        let j = index;
        do{
            const isCellBelowEmpty = column[j+1] === '.';
            const isCellBelowNotTheEdge = j+1 < column.length;
            isRockMoving = isCellBelowEmpty && isCellBelowNotTheEdge;

            if(isRockMoving) {
                    column[j] = '.';
                    column[j+1] = 'O';
                    j++;
                }
        } while(isRockMoving)
    })
    return column
}

const tiltRowToWest = tiltColumnToNorth;
const tiltRowToEast = tiltColumnToSouth;

function getColumn(allRows, colIndex) {
    const result = []
    for(let i = 0; i < allRows.length; i++) {
        result.push(allRows[i][colIndex])
    }
    return result;
}

const getRow = getColumn;

function getAllColumns(allRows){
    const allColumns = []
    for(let indexColumn = 0; indexColumn < allRows[0].length; indexColumn++) {
        allColumns.push(getColumn(allRows, indexColumn))
    }
    return allColumns;
}

const getAllRows = getAllColumns;

function getAllRowsAfterACycle(allRows){
    // displayRows(allRows)
    
    const allColumns = getAllColumns(allRows);
    const allColumnsTiltedToNorth = allColumns.map((col) => {
        return tiltColumnToNorth(col)
    })
    
    const allRowsTiltedToNorth = getAllRows(allColumnsTiltedToNorth);
    
    // displayRows(allRowsTiltedToNorth);
    
    const allRowsTiltedToWest = allRowsTiltedToNorth.map((row) => {
        return tiltRowToWest(row)
    })
    
    // displayRows(allRowsTiltedToWest);
    
    const allColumnsTiltedToWest = getAllColumns(allRowsTiltedToWest);
    const allColumnsTiltedToSouth = allColumnsTiltedToWest.map((col) => {
        return tiltColumnToSouth(col)
    })
    
    
    const allRowsTiltedToSouth = getAllRows(allColumnsTiltedToSouth);
    
    // displayRows(allRowsTiltedToSouth);
    
    const allRowsTiltedToEast = allRowsTiltedToSouth.map((row) => {
        return tiltRowToEast(row)
    })

    // displayRows(allRowsTiltedToEast);
    
    return allRowsTiltedToEast;
}

//Part 2
function getNumberOfRocksInRow(row){
    return row.filter((cell) => cell === 'O').length
}

function displayRows(rows){
    console.log("==========")
    const puzzle = rows.map((row) => row.join(""))
    puzzle.forEach((row) => console.log(row))
    console.log("==========")
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

    const rowCount = allRows.length;
    const colCount = allRows[0].length;

    let allTiltedRows = allRows;
    let timestamp = new Date();
    const triggerLine = 10000;
    for(let i = 0; i < 1000 * 1000 * 1000; i++){
        if(i % (triggerLine) === 0) {
            console.log('i : ', i);
            const currentTime = new Date();
            const timeFor10000Exec = currentTime - timestamp;
            console.log('Seconds for 10 000 : ', timeFor10000Exec / 1000);
            console.log('Remeaning time : ', (timeFor10000Exec / 1000) * ((1000000000 - i) / triggerLine) , ' secondes');
            timestamp = currentTime;
        }
        allTiltedRows = getAllRowsAfterACycle(allRows);
    }
    
    let result = 0;
    for(let indexRow = 0; indexRow < rowCount; indexRow++) {
        const multiplicator = rowCount - indexRow;
        const row = allTiltedRows[indexRow];
        const numberOfRocks = getNumberOfRocksInRow(row);
        result += numberOfRocks * multiplicator;
    }
    
    console.log('Result :', result);
})()