const fs = require('fs');

const litteralsDigits = [
    'one',
    'two',
    'three',
    'four',
    'five',
    'six',
    'seven',
    'eight',
    'nine'
]

function getAllDigitsFrom(line) {
    const result = []
    for(let i = 0; i < line.length; i++) {
        const char = line[i]
        const num = Number(char);
        if (!isNaN(num)) {
            result.push(num);
        } else {
            litteralsDigits.forEach((litteralDigit, indexLitteralDigit) => {
                // console.log('litteralDigit', litteralDigit, 'line.substring', line.substring(i))
                if (litteralDigit.length <= line.substring(i).length) {
                    // console.log('its less')
                    if(litteralDigit === line.substring(i, i + litteralDigit.length)){
                        const num = indexLitteralDigit + 1;
                        result.push(num);
                    }
                }
            })
        }
    }
    return result
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

    let calibrationSum = 0;
    const allLines = text.split('\n');
    console.log('allLines', allLines)
    allLines.forEach((line) => {
        const allDigitsOfLine = getAllDigitsFrom(line);
        console.log(allDigitsOfLine)
        const firstDigit = allDigitsOfLine[0];
        const lastDigit = allDigitsOfLine[allDigitsOfLine.length - 1];
        calibrationSum += firstDigit * 10 + lastDigit;
    })
    
    console.log('calibration sum', calibrationSum);
})()

