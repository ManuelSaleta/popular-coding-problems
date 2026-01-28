function mySqrt(x: number): number {
    let half = Math.floor(x/2);
    if (x < 2) return x;
    while ((half*half) > x) {
        half--;
    }
    return half;
};j
// 16
// half = 8
// 8*8 =64
// 64 >= 16
//half--
// half = 7
// 7*7 = 49
// 49 >= 16
// half = 6
// 6*6 =36
// 36 >= 16
// half = 5
// _ = 25
// 25 >= 16
