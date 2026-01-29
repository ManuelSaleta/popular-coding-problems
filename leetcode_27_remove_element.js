function removeElement(nums, val) {
    var temp = nums.filter(function (el) { return el !== val; });
    nums.length = 0;
    nums.push.apply(nums, temp);
    return nums.length;
}
;
