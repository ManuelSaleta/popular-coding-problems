function searchInsert(nums, target) {
    if (nums.includes(target)) {
        return nums.indexOf(target);
    }
    nums.forEach(function (n, index) {
        if (n > target) {
            console.log('n ', n);
            return index;
        }
    });
    return -1;
}
;
