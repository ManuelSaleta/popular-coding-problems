function modifiedMatrix(matrix: number[][]): number[][] {
  // matrix[0].length --> nbrCols

  // minus one coordinates
  const coords: number[][] = [];
  const highest: number[] = [];

  // init highest
  for (let i = 0; i < matrix[0].length; i++) {
    // num of cols
    highest.push(0);
  }

  matrix.forEach((row, indexX) => {
    // find the repalcement and its position
    row.forEach((rowItem, indexY) => {
      if (rowItem === -1) {
        // found item to replce

        coords.push([indexX, indexY]);
      }

      if (rowItem > highest[indexY]) {
        highest[indexY] = rowItem;
      }
    });
  });
  coords.forEach((xy) => {
    // if the the indexX is same as coords second val replace
    // xy = [0, 2]
    matrix[xy[0]][xy[1]] = highest[xy[1]];
  });

  return matrix;
}
const arr = [
  [1, 2, -1],
  [4, -1, 6],
  [7, 8, 9],
];

//[
// [1,2,-1],
// [4,-1,6],
// [7,8,9]
// loop through rows
// loop through cols
console.log(modifiedMatrix(arr));
