function removeDuplicates(nums: number[]): number {
    nums.length = 0
    nums = [... new Set(nums)];
    return nums.length;
};